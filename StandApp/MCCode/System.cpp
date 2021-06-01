#include "System.h"
#include "Headers\SpecialFuntions.hpp"

// Массив с данными падения напряжения на шунте за 
// C_DELAY итераций
float cData[C_DELAY];

/*   System stuff   */

bool haveData = false;
volatile int rpmvalue;

void receiveEvent(int howMany)
{
	if (howMany >= (sizeof rpmvalue))
	{
		SpecialFunctions::I2C_read(rpmvalue);

		haveData = true;
	}
}

System::System()
	:
	tenzo1(HX711_CAL_FACTOR, HX711_SCALE),
	tenzo2(HX711_CAL_FACTOR, HX711_SCALE),
	vm(V_PIN)
{
	Wire.begin(MAIN_ADDRESS);
	Wire.setClock(I2CSpeed);
	Wire.onReceive(receiveEvent);
}

void System::InitiliazeModules()
{
	tenzo1.Setup(HX711_DOUT, HX711_CLK);
	tenzo2.Setup(HX711_M_DOUT, HX711_M_CLK);
	bmp.Setup();
	amp.Setup();
}

void System::PreProcess(size_t b_rate, size_t t_out)
{
	// Установка скорости обмена данными
	Serial.begin(b_rate);
	Serial.setTimeout(t_out);

	// Цикл для тестового подключения
	while (true)
	{
		if (Serial.available() > 0)
		{
			String data = Serial.readString();

			// Тестовое подключение
			if (data == TEST_QUERY)
			{
				Serial.println(TEST_QUERY_SUCCESS);
			}

			// Рабочий режим
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
	// Если порт доступен
	if (Serial.available() > 0)
	{
		String command = Serial.readString();

		// Если спящий режим
		if (command == SHUTDOWN)
		{
			setup();
		}
		else if (command.indexOf(SPLITTER_SIGN) != -1)
		{
			sub_command = command.substring(0, command.indexOf(SPLITTER_SIGN));

			// Если команда двигателя
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
		bmp.Process(BMP_E_TEMP, BMP_E_PRES, BMP_E_HUM);

		current_modules_time = 0;
	}

	cData[current_time] = amp.GetVoltage();
	current_time = current_time + DELAY_TIME;

	if (current_time == C_DELAY)
	{
		amp.Process(A0_DATA);

		current_time = 0;
	}

	engine.Process(NANO_ADR);
	tenzo1.Process(HX711_PRES);
	tenzo2.Process(HX711_M_PRES);
	rpmv.Process(RPM_DATA);
	vm.Process(V_DATA);
}

/* end System stuff */

/*   BMP180 stuff   */

void BarHumManager::Setup()
{
	if (!bmp.begin())
	{
		Serial.println(BMP_E_NOT_VALID);
	}
	else
	{
		Serial.println(BMP_E_VALID);
		IsBMP_E_Valid = true;
	}

	htu.begin();
}

void BarHumManager::Process(String t_header, String p_header, String hum_header)
{
	if (IsBMP_E_Valid)
	{
		SpecialFunctions::SendData(t_header, (String)bmp.readTemperature());
		SpecialFunctions::SendData(p_header, (String)(bmp.readPressure() / 997.5));
		SpecialFunctions::SendData(hum_header, (String)htu.readHumidity());
	}
}

/* end BMP180 stuff */

/*   Engine stuff   */

void Engine::Process(const byte& adr)
{
	new_value = map(engine_value, 0, 100, 544, 2400);

	Wire.beginTransmission(adr);
	SpecialFunctions::I2C_write(new_value);
	Wire.endTransmission();
}

void Engine::SetVal(int value)
{
	engine_value = value;
}

/* end Engine stuff */

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
}

void hx711_adc::Process(String header)
{
	units = hx711.get_units(), 10;

	if (units < 0)
	{
		units = 0.00;
	}

	kg_press = units * scale;

	SpecialFunctions::SendData(header, (String)kg_press);
}

/* end HX 711 stuff */

/*   voltmeter stuff   */

voltmeter::voltmeter(uint8_t pin)
{
	pinMode(pin, INPUT);
}

void voltmeter::Process(String header)
{
	SpecialFunctions::SendData(header, (String)map(analogRead(this->pin), 0, 1023, 0, MAX_V));
}

/* end voltmeter stuff */

/*   ampermeter stuff   */

void ampermeter::Setup()
{
	if (!ina219.begin()) {
		Serial.println("Failed to find INA219 chip");
	}
}

void ampermeter::Process(String header)
{
	SpecialFunctions::SendData(header, (String)SpecialFunctions::mean(cData, C_DELAY));
}

float ampermeter::GetVoltage()
{
	return ina219.getShuntVoltage_mV();
}

/* end ampermeter stuff */

/*   rpm stuff   */

void rpm_viewer::Process(String header)
{
	if (haveData)
	{	
		SpecialFunctions::SendData(header, (String)rpmvalue);

		haveData = false;
	}
}

/* end rpm stuff */
