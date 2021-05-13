#include "I2CTrans.h"

#define IN_RPM_PIN 7

const byte SLAVE_ADDRESS = 42;

int time_stop;  
int time;      
int count;     
int t1, t2;
int rpm = 0;

void setup() 
{  
  pinMode(IN_RPM_PIN, INPUT);
}

void loop() 
{
  count = 0;
  t1 = 0; 
  t2 = 0;
  
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

  rpm = (count / 21) * 60;

  Wire.beginTransmission (SLAVE_ADDRESS);
  I2C_write(rpm);
  Wire.endTransmission ();
}
