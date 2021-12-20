/* Команды:
 * [Work mode] - запустить основный цикл
 * [Reset] - прервать основной цикл
 * [Engine write]| - подать сигнал на двигатель (после '|' указать число мкс от 544 до 2400)
 * [Servo write]| - подать сигнал на серво (после '|' указать число градусов)
 * [Wait] - режим ожидания линии
 * [Stop wait] - остановка режима ожидания линии
*/

#include "commands.h"

#include <Servo2.h>

#define ENGINE_PIN 12 // Пин двигателя
#define SERVO_PIN  11 // Пин сервопривода
#define OPT_PIN    7  // Пин оптодатчика

#define GET_BACK   0    // Угол, на который поворачивается привод, при достижении линии
#define SOURCE     120  // Исходный угол привода

Servo2 engine;
Servo2 servo;

int engine_val = 544;
int servo_val = 0;

String sub_command = "";

bool IsWaitMode = false;
bool Stopped = false;

void setup() 
{
  Serial.begin(9600);
  Serial.setTimeout(10);

  while (true)
  {
    if (Serial.available() > 0)
    {
      String data = Serial.readString();

      if (data == TEST_QUERY)
      {
        Serial.println(TEST_QUERY_SUCCESS);
      }

      if (data == WORK_MODE_ACTIVE)
      {
        Serial.println(WORK_MODE_ACTIVATING);
        break;
      }
    }
  }

  pinMode(OPT_PIN, INPUT);
  engine.attach(ENGINE_PIN);
  servo.attach(SERVO_PIN);

  servo.write(SOURCE);
}

void loop() 
{
  if (Serial.available() > 0)
  {
    String command = Serial.readString();

    if (command == SHUTDOWN)
    {
      Serial.println("Closing...");
      setup();
    }
    else if (command == WAIT)
    {
      Serial.println("Start waiting opt. sensor");
      IsWaitMode = true;
    }
    else if (command == STOP_WAIT)
    {
      Serial.println("Stop waiting opt. sensor");
      IsWaitMode = false;
      Stopped = false;

      servo.write(SOURCE);
      engine.writeMicroseconds(1000);
    }
    else if (command.indexOf(SPLITTER_SIGN) != -1)
    {
      sub_command = command.substring(0, command.indexOf(SPLITTER_SIGN));

      if (sub_command == ENGINE_WRITE)
      {
        engine_val = (command.substring(command.indexOf(SPLITTER_SIGN) + 1).toInt());
      }
      else if (sub_command == SERVO_WRITE)
      {
        servo_val = (command.substring(command.indexOf(SPLITTER_SIGN) + 1).toInt());
        servo.write(servo_val);
      }
    }
  }

  if (IsWaitMode && !Stopped)
  {
    if (digitalRead(OPT_PIN) == HIGH)
    {
      Serial.print("OPT: ");
      Serial.println(digitalRead(OPT_PIN));

      servo.write(GET_BACK);
      engine.writeMicroseconds(544);

      Serial.println("Stoping engine...");

      Stopped = true;
    }
  }
  else if(!IsWaitMode)
  {
    engine.writeMicroseconds(engine_val);
  }
}
