#include "System.h"

/*   System stuff   */

void System::InitiliazeModules()
{
	tenzo.Setup();
	bmp.Setup();
	engine.Setup();
	am.Setup();
}

void System::PreProcess(size_t b_rate, size_t t_out)
{
	// ��������� �������� ������ �������
	Serial.begin(b_rate);
	Serial.setTimeout(t_out);

	// ���� ��� ��������� �����������
	while (true)
	{
		if (Serial.available() > 0)
		{
			String data = Serial.readString();

			// �������� �����������
			if (data == TEST_QUERY)
			{
				Serial.println(TEST_QUERY_SUCCESS);
			}

			// ������� �����
			if (data == WORK_MODE_ACTIVE)
			{
				Serial.println(WORK_MODE_ACTIVATING);
				break;
			}
		}
	}
}

void System::ProcessCommands()
{
	// ���� ���� ��������
	if (Serial.available() > 0)
	{
		String command = Serial.readString();

		// ���� ������ �����
		if (command == SHUTDOWN)
		{
			setup();
		}
		else if (command.indexOf(SPLITTER_SIGN) != -1)
		{
			sub_command = command.substring(0, command.indexOf(SPLITTER_SIGN));

			// ���� ������� ���������
			if (sub_command == ENGINE_WRITE)
			{
				engine.SetVal(command.substring(command.indexOf(SPLITTER_SIGN) + 1).toInt());
			}
		}
	}
}

void System::Tick()
{
	current_modules_time = current_modules_time + DELAY_TIME;

	if (current_modules_time == MODULES_UPDATE_TIME)
	{
		bmp.Process();

		current_modules_time = 0;
	}
	else
	{
		rpmv.Process();
		am.Process();
		vm.Process();
		tenzo.Process();
		engine.Process();
	}
}

/* end System stuff */

/*   HX 711 stuff   */

hx711_adc::hx711_adc(float cal_factor, float scale)
	:
	calibration_factor(cal_factor),
	scale(scale)
{
}

void hx711_adc::Setup(size_t data_pin, size_t clock_pin)
{
	hx711.begin(data_pin, clock_pin);
	hx711.set_scale(calibration_factor);
	hx711.tare();

	IsHX_Valid = true;
}

void hx711_adc::SendData(String header, String value)
{
	Serial.print(header);
	Serial.print(SPLITTER_SIGN);
	Serial.print(value);

	Serial.println();
}

void hx711_adc::Process()
{
	if (IsHX_Valid)
	{
		units = hx711.get_units(), 10;

		if (units < 0)
		{
			units = 0.00;
		}

		kg_press = units * scale;

		SendData(HX711_PRES, (String)kg_press);
	}
}

/* end HX 711 stuff */

/*   BMP/E 280 stuff   */

void bmp_e_280::Setup(size_t adr)
{
	if (!bme.begin(adr))
	{
		Serial.println(BMP_E_NOT_VALID);
	}
	else
	{
		Serial.println(BMP_E_VALID);
		IsBMP_E_Valid = true;
	}
}

void bmp_e_280::SendData(String header, String value)
{
	Serial.print(header);
	Serial.print(SPLITTER_SIGN);
	Serial.print(value);

	Serial.println();
}

void bmp_e_280::Process()
{
	if (IsBMP_E_Valid)
	{
		SendData(BMP_E_TEMP, (String)bme.readTemperature());
		SendData(BMP_E_PRES, (String)(bme.readPressure() / 997.5));
		SendData(BMP_E_HUM,  (String)bme.readHumidity());
	}
}

/* end BMP/E 280 stuff */

/*   Engine stuff   */

void Engine::Setup(size_t pin)
{
	engine.attach(pin);

	if (engine.attached())
	{
		IsEngine_Valid = true;
	}
}

void Engine::Process()
{
	if (IsEngine_Valid)
	{
		new_value = map(engine_value, 0, 100, ENGINE_MIN_MCS, ENGINE_MAX_MCS);
		engine.writeMicroseconds(new_value);
	}
}

void Engine::SetVal(size_t value)
{
	engine_value = value;
}

/* end Engine stuff */

/*   voltmeter stuff   */

voltmeter::voltmeter(size_t pin)
{
	pinMode(pin, INPUT);

	IsVoltmeter_Vaild = true;
}

void voltmeter::SendData(String header, String value)
{
	Serial.print(header);
	Serial.print(SPLITTER_SIGN);
	Serial.print(value);

	Serial.println();
}

void voltmeter::Process()
{
	if (IsVoltmeter_Vaild)
	{
		SendData(V_DATA, (String)map(analogRead(V_PIN), 0, 1024, 0, MAX_V));
	}
}

/* end voltmeter stuff */

/*   ampermeter stuff   */

volatile bool drdyIntrFlag = true;

void drdyInterruptHndlr()
{
	drdyIntrFlag = true;
}

void enableInterruptPin()
{
	attachInterrupt(digitalPinToInterrupt(ADS1220_DRDY_PIN), drdyInterruptHndlr, FALLING);
}

void ampermeter::Setup()
{
	pc_ads1220.begin(ADS1220_CS_PIN, ADS1220_DRDY_PIN);

	pc_ads1220.set_data_rate(DR_330SPS);
	pc_ads1220.set_pga_gain(PGA_GAIN_1);

	pc_ads1220.set_conv_mode_single_shot(); 
}

void ampermeter::Process()
{
	adc_data = pc_ads1220.Read_SingleShot_SingleEnded_WaitForData(MUX_SE_CH0);

	if(convertToMilliV(adc_data) != 0.0)
		SendData(A0_DATA, (String)(convertToMilliV(adc_data) / SHUNT_1_RESISTANCE / 1000));

	adc_data = pc_ads1220.Read_SingleShot_SingleEnded_WaitForData(MUX_SE_CH1);

	if (convertToMilliV(adc_data) != 0.0)
		SendData(A1_DATA, (String)(convertToMilliV(adc_data) / SHUNT_2_RESISTANCE / 1000));
}

void ampermeter::SendData(String header, String value)
{
	Serial.print(header);
	Serial.print(SPLITTER_SIGN);
	Serial.print(value);

	Serial.println();
}

float ampermeter::convertToMilliV(int32_t i32data)
{
	return (float)((i32data * VFSR * 1000) / FULL_SCALE);
}

/* end ampermeter stuff */

/*   rpm stuff   */

bool haveData = false;
volatile int rpmvalue;

void receiveEvent(int howMany)
{
	if (howMany >= (sizeof rpmvalue))
	{
		I2C_read(rpmvalue);

		haveData = true;
	}
}

rpm_viewer::rpm_viewer(byte adr)
{
	Wire.begin(adr);
	Wire.onReceive(receiveEvent);

	IsRpm_Valid = true;
}

void rpm_viewer::Process()
{
	if (IsRpm_Valid && haveData)
	{	
		SendData(RPM_DATA, (String)rpmvalue);

		haveData = false;
	}
}

void rpm_viewer::SendData(String header, String value)
{
	Serial.print(header);
	Serial.print(SPLITTER_SIGN);
	Serial.print(value);

	Serial.println();
}

/* end rpm stuff */
