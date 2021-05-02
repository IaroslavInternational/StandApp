/* Библиотеки для работы с АЦП HX711 */

#include <HX711.h>

/*************************************/

/* Библиотеки для работы с датчиком BMP/E 280 */

#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>

/**********************************************/

/* Библиотека для работы с двигателем */

#include <Servo.h>

/**************************************/

/* Настройки */

#include "Headers/commands.h" // Команды

String sub_command = "";

#define MODULES_UPDATE_TIME 5000
#define DELAY_TIME 1

float current_modules_time = 0;

/* Настройки для АЦП HX711 */

// Пин данных для АЦП HX711
#define DOUT 7 

// Пин clock для АЦП HX711
#define CLK 6  

// Объект АЦП
HX711 hx711;

float calibration_factor = 10.50; // Калибровочный множитель
float units;                      // Значение
float kg_press;                   // Кг
float hx_scale = 0.035274;        // Множитель для перевода в граммы

// Если АЦП доступен
bool IsHX_Valid = false;

/****************************/

/* Настройки для датчика BMP/E 280 */

// Давление на высоте уровня моря в гектопаскалях для Чёрного моря
#define SEALEVELPRESSURE_HPA (999.92)

// Объект датчика
Adafruit_BME280 bme;

// Если датчик доступен
bool IsBMP_E_Valid = false;
 
/***********************************/

/* Настройки для двигателя */

#define ENGINE_PIN 12

Servo engine;

int engine_value = 0;
int new_value = 0;

bool IsEngine_Valid = false;

/***************************/

/*************/

// Инициализация датчика BMP/E 280
void bmeSetup()
{
  if (!bme.begin(0x76)) 
  {                                                   
    Serial.println(BMP_E_NOT_VALID);
  }
  else
  {
     Serial.println(BMP_E_VALID);
     IsBMP_E_Valid = true;
  }
}

// Инициализация АЦП HX711
void hxSetup()
{
  hx711.begin(DOUT, CLK);
  hx711.set_scale(calibration_factor);
  hx711.tare();
  
  IsHX_Valid = true;
}

// Инициализация двигателя
void EngineSetup()
{
  engine.attach(ENGINE_PIN);

  if(engine.attached())
  {
    IsEngine_Valid = true; 
  }
}

// Метод для отправки данных с датчиков, АЦП и пр.
void Send_Device_InData_Info(String header, String val)
{
  Serial.print(header);
  Serial.print(SPLITTER_SIGN);
  Serial.print(val);

  Serial.println();
}

// Установка
void setup()
{    
  // Установка скорости обмена данными
  Serial.begin(9600);
  Serial.setTimeout(10);
  
  // Цикл для тестового подключения
  while(true)
  {
    if (Serial.available() > 0) 
    {
      String data = Serial.readString();

      // Тестовое подключение
      if(data == TEST_QUERY)
      { 
        Serial.println(TEST_QUERY_SUCCESS);
      }

      // Рабочий режим
      if(data == WORK_MODE_ACTIVE)
      { 
        Serial.println(WORK_MODE_ACTIVATING);
        break;
      }
    }
  }

  bmeSetup();     // Установка датчика BMP/E 280
  hxSetup();      // Установка АЦП HX711
  EngineSetup();  // Установка двигателя
}

// Главный цикл
void loop()
{

  // Если порт доступен
  if (Serial.available() > 0) 
  {
    String command = Serial.readString();
    
    // Если спящий режим
    if(command == SHUTDOWN)
    {
      setup();
    } 
    else if(command.indexOf(SPLITTER_SIGN) != -1) 
    {
      sub_command = command.substring(0, command.indexOf(SPLITTER_SIGN));

      // Если команда двигателя
      if(sub_command == ENGINE_WRITE)
      {
        engine_value = command.substring(command.indexOf(SPLITTER_SIGN) + 1).toInt();
      }
    }
  }

  {
    current_modules_time = current_modules_time + DELAY_TIME;
    // Если доступен датчик BMP/E 280
    if(IsBMP_E_Valid)
    {
      if(current_modules_time == MODULES_UPDATE_TIME)
      {
        Send_Device_InData_Info(BMP_E_TEMP, (String) bme.readTemperature());
        Send_Device_InData_Info(BMP_E_PRES, (String)(bme.readPressure() / 997.5));
        Send_Device_InData_Info(BMP_E_HUM,  (String) bme.readHumidity()); 
      }
    }
  
    // Если доступен АЦП HX711
    if(IsHX_Valid)
    {
      if(current_modules_time == MODULES_UPDATE_TIME)
      {
        units = hx711.get_units(), 10;
        
        if (units < 0)
        {
          units = 0.00;
        }
        
        kg_press = units * hx_scale;
    
        Send_Device_InData_Info(HX711_PRES, (String)kg_press);

        current_modules_time = 0;
      }
    }
  }

  if(IsEngine_Valid)
  {
    new_value = map(engine_value, 0, 1000, 544, 2400);
    engine.writeMicroseconds(new_value);
  }
  
  delay(DELAY_TIME);
}
