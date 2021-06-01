#include "System.h"

// Объект системы
System sys;

void setup() 
{
  sys.PreProcess();         // Предпроцессор
  sys.InitiliazeModules();  // Инициализация 
}

void loop() 
{
  sys.ProcessCommands();    // Обработка входящих команд
  sys.Tick();               // Событие итерации
}
