/*#include "Headers/HX711.h"

#define DOUT  7
#define CLK  6

HX711 scale;

float calibration_factor = 10.50; //-7050 worked for my 440lb max scale setup
float units;
float ounces;

void setup() {
  scale.begin(DOUT, CLK);
  Serial.begin(9600);
  Serial.println("HX711 calibration sketch");
  Serial.println("Remove all weight from scale");
  Serial.println("After readings begin, place known weight on scale");
  Serial.println("Press + or a to increase calibration factor");
  Serial.println("Press - or z to decrease calibration factor");

  scale.set_scale();
  scale.tare();	//Reset the scale to 0

  long zero_factor = scale.read_average(); //Get a baseline reading
  Serial.print("Zero factor: "); //This can be used to remove the need to tare the scale. Useful in permanent scale projects.
  Serial.println(zero_factor);
}

void loop() {

  scale.set_scale(calibration_factor); //Adjust to this calibration factor

  Serial.print("Reading: ");
  units = scale.get_units(), 10;
  if (units < 0)
  {
    units = 0.00;
  }
  ounces = units * 0.035274;
  Serial.print(ounces);
  Serial.print(" grams"); 
  Serial.print(" calibration_factor: ");
  Serial.print(calibration_factor);
  Serial.println();

  if(Serial.available())
  {
    char temp = Serial.read();
    if(temp == '+' || temp == 'a')
      calibration_factor += 0.1;
    else if(temp == '-' || temp == 'z')
      calibration_factor -= 0.1;
  }
}*/

// Настройки
#include "Headers/commands.h"

/* Библиотеки для работы с датчиком BMP/E 280 */

#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>

/**********************************************/

/* Настройки для датчика BMP/E 280 */

// Давление на высоте уровня моря в гектопаскалях
#define SEALEVELPRESSURE_HPA (999.92)

// Объект датчика
Adafruit_BME280 bme;

bool IsBMP_E_Valid = false;
 
/***********************************/

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

void Print_BMP_E_Info(String header, String val)
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

bmeSetup();
}

// Главный цикл
void loop()
{
  if (Serial.available() > 0) 
  {
    String data = Serial.readString();

    if(data == SHUTDOWN)
    {
      setup();
    }
  }
  
  if(IsBMP_E_Valid)
  {
    Print_BMP_E_Info(BMP_E_TEMP, (String)bme.readTemperature());
    Print_BMP_E_Info(BMP_E_PRES, (String)(bme.readPressure() / 133.0f));
    Print_BMP_E_Info(BMP_E_ALT, (String)bme.readAltitude(SEALEVELPRESSURE_HPA));
    Print_BMP_E_Info(BMP_E_HUM, (String)bme.readHumidity());
  }
  
  delay(250);
}
