/* Библиотеки для работы с АЦП HX711 */

#include <HX711.h>

/*************************************/

/* Библиотеки для работы с датчиком BMP/E 280 */

#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>

/**********************************************/

/* Настройки */

#include "Headers/commands.h" // Команды

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

  bmeSetup(); // Установка датчика BMP/E 280
  hxSetup();  // Установка АЦП HX711
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
  }

  // Если доступен датчик BMP/E 280
  if(IsBMP_E_Valid)
  {
    Send_Device_InData_Info(BMP_E_TEMP, (String)bme.readTemperature());
    Send_Device_InData_Info(BMP_E_PRES, (String)(bme.readPressure() / 997.5));
    Send_Device_InData_Info(BMP_E_HUM, (String)bme.readHumidity());
  }

  // Если доступен АЦП HX711
  if(IsHX_Valid)
  {
    units = hx711.get_units(), 10;
    
    if (units < 0)
    {
      units = 0.00;
    }
    
    kg_press = units * 0.000035274;

    Send_Device_InData_Info(HX711_PRES, (String)kg_press);
  }
  
  delay(250);
}
