/* Библиотека для работы с передачей данных */

#include "I2CTrans.h"

/********************************************/

#define IN_RPM_PIN 7
#define UNO_ADR    0x50
#define I2CSpeed   400000

int time_stop;  
int time;      
int count;     
int t1;
int t2;
int rpm = 0;

void setup() 
{
  Wire.begin();
  Wire.setClock(I2CSpeed);
  pinMode(IN_RPM_PIN, INPUT);
}

void loop() 
{
  count = 0;
  t1    = 0; 
  t2    = 0;
  
  time = millis();
  time_stop = time + 1000;

  while(time <= time_stop)
  {
    t1 = digitalRead(IN_RPM_PIN);

    if(t1 != t2)
    {
      if(t1 > t2)
      {
        count++;
      }
      
      t2 = t1;
    }
   
    time = millis();
  }

  rpm = count * 60;
  
  Wire.beginTransmission (UNO_ADR);
  I2C_write(rpm);
  Wire.endTransmission ();
}
