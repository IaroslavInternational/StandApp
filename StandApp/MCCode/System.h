#pragma once

#include "Headers/commands.h"

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

#define MODULES_UPDATE_TIME	 5000		// Время отправки данных переферийных модулей
#define DELAY_TIME			 1			// Время задержки выполнения программы
#define HX711_DOUT			 7			// Пин данных для АЦП HX711
#define HX711_CLK			 6			// Пин clock для АЦП HX711
#define HX711_CAL_FACTOR	 10.50		// Калибровочный коэффициент для АЦП HX711
#define HX711_SCALE			 0.035274	// Коэффициент для перевода е. и. в граммы для АЦП HX711
#define BMP_E_ADR			 0x76		// Пин I2C для датчика BMP/E 280
#define ENGINE_PIN			 12			// Пин управления для двигателя
#define S_BAUD_RATE			 9600		// Скорость обмена данными
#define S_TIMEOUT			 10			// Время приёма данных

/*************/

class Serial;
class String;
class HX711;
class Adafruit_BME280;
class Servo;

// Объект управления АЦП HX711
class hx711_adc
{
public:
	hx711_adc(float cal_factor = HX711_CAL_FACTOR, float scale = HX711_SCALE);
public:
	void Setup(size_t data_pin = HX711_DOUT, size_t clock_pin = HX711_CLK);	// Установка АЦП HX711
	void Process();															// Обработка и отправка данных
private:
	void SendData(String header, String value);								// Отправка данных
private:
	HX711 hx711;															// Объект АЦП	
	const float calibration_factor;											// Калибровочный множитель
	const float scale;														// Множитель для перевода в граммы
	float units = 0.0f;														// Принятое значение
	float kg_press = 0.0f;													// Давление в кг
	bool IsHX_Valid = false;												// Если АЦП доступен
};

// Объект управления датчиком давления, влажности и температуры
class bmp_e_280
{
public:
	bmp_e_280() = default;
public:
	void Setup(size_t adr = BMP_E_ADR);			// Установка датчика BMP/E 280
	void Process();								// Обработка и отправка данных
private:
	void SendData(String header, String value);	// Отправка данных
private:
	Adafruit_BME280 bme;						// Объект датчика
	bool IsBMP_E_Valid = false;					// Если датчик доступен
};

// Объект управления двигателем
class Engine
{
public:
	Engine() = default;
public:
	void Setup(size_t pin = ENGINE_PIN);	// Установка двигателя
	void Process();							// Обработка данных
	void SetVal(size_t value);				// Установить принятое значение
private:
	Servo engine;							// Объект двигателя
	size_t engine_value = 0;				// Принятое значение для ШИМ-сигнала
	size_t new_value = 0;					// Масштабированное значение для ШИМ-сигнала
	bool IsEngine_Valid = false;			// Если двигатель доступен
};

// Система управления
class System
{
public:
	System();
public:
	void InitiliazeModules();
public:
	void PreProcess(size_t b_rate = S_BAUD_RATE, size_t t_out = S_TIMEOUT);
	void ProcessCommands();
public:
	void Tick();
public:
	hx711_adc tenzo;	// Тензодатчик
	bmp_e_280 bmp;		// Датчик
	Engine engine;		// Двигатель
private:
	size_t current_modules_time = 0;	// Текущий отсчёт времени перед отправкой данных переферийных модулей
	String sub_command = "";			// Подкоманда 
};
