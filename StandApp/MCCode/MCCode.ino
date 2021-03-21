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


void setup()
{    
  Serial.begin(9600);

  while(true)
  {
    if (Serial.available() > 0) 
    {
      String data = Serial.readString();
      
      if(data == "[Test connection]\n")
      { 
        Serial.println("[Connection succeeded]");
        //break;
      }
    }
  }
}

void loop()
{
}
