#include "System.h"

System sys;

void setup() 
{
  sys.PreProcess();
  sys.InitiliazeModules();
}

void loop() 
{
  sys.ProcessCommands();
  sys.Tick();
  
  delay(DELAY_TIME);
}
