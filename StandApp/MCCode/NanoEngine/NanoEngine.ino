/* Библиотека для работы с двигателем */

#include <Servo2.h>

/**************************************/

/* Библиотека для работы с передачей данных */

#include "I2CTrans.h"

/********************************************/

#define ENGINE_PIN     12
#define SEC_ENGINE_PIN 11
#define THIS_ADR       0x20
#define I2CSpeed       400000 

Servo2       engine;
Servo2       sec_engine;
bool         haveData = false;
volatile int val;

void receiveEvent(int howMany)
{
  if (howMany >= (sizeof val))
  {
    I2C_read(val);

    haveData = true;
  }
}

void setup()
{
  Wire.begin(THIS_ADR);
  Wire.setClock(I2CSpeed);
  Wire.onReceive(receiveEvent);
  
  engine.attach(ENGINE_PIN);
  engine.writeMicroseconds(544);
  sec_engine.attach(SEC_ENGINE_PIN);
  sec_engine.writeMicroseconds(544);
}

void loop()
{
  if(haveData)
  {
    engine.writeMicroseconds(val);

    if(sec_engine.attached())
    {
      sec_engine.writeMicroseconds(val);
    }
    
    haveData = false;
  }
  else
  {
    engine.writeMicroseconds(val);
    
    if(sec_engine.attached())
    {
      sec_engine.writeMicroseconds(val);
    }
  }
}
