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

/* Библиотека для работы с передачей данных */

#include "I2CTrans.h"

/********************************************/

/* Библиотека для работы с АЦП */

#include <Protocentral_ADS1220.h>

 /******************************/

/* Настройки */

byte MY_ADDRESS = 42;					// Адрес платы

/* Общие настройки */

#define MODULES_UPDATE_TIME	 5000		// Время отправки данных переферийных модулей в мс
#define DELAY_TIME			 1			// Время задержки выполнения программы в мс

/*******************/

/* Настройки подключения */

#define S_BAUD_RATE			 9600		// Скорость обмена данными
#define S_TIMEOUT			 10			// Время ожидания приёма данных

/*************************/

/* Цифровые пины */

#define HX711_CLK			 6			// Пин clock для АЦП HX711
#define HX711_DOUT			 7			// Пин данных для АЦП HX711
#define ENGINE_PIN			 12			// Пин управления для двигателя
#define ADS1220_DRDY_PIN	 4			// Пин для АЦП
#define ADS1220_CS_PIN		 53			// Пин для АЦП

/*****************/

/* Аналоговые пины */

#define V_PIN				 A5			// Пин вольтметра

/*******************/

/* Шина I2C */

#define BMP_E_ADR			 0x76		// Пин I2C для датчика BMP/E 280 (адрес)

/************/

/* Настройки модулей */

#define HX711_CAL_FACTOR	 1.0f		// Калибровочный коэффициент для АЦП HX711
#define HX711_SCALE			 0.035274f	// Коэффициент для перевода е. и. в граммы для АЦП HX711
#define MAX_V				 50			// Максимальное измерямое напряжение в вольтах
#define SHUNT_1_RESISTANCE	 0.0005		// Сопротивление первого шунта (R = U / I) в Ом
#define SHUNT_2_RESISTANCE	 0.0005		// Сопротивление второго шунта (R = U / I) в Ом
#define ENGINE_MIN_MCS		 1000		// Минимальный барьер ШИМ-сигнала для двигателя в мкс
#define ENGINE_MAX_MCS		 2000		// Максимальный барьер ШИМ-сигнала для двигателя в мкс
#define PGA					 1			// Коэф-т усиления АЦП
#define VREF				 2.048		// Допустимое напряжение на входе
#define VFSR				 VREF/PGA
#define FULL_SCALE			 (((long int)1<<23)-1)

/*********************/

/*************/

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
	float calibration_factor;												// Калибровочный множитель
	float scale;															// Множитель для перевода в граммы
	float units = 0.0f;														// Принятое значение
	float kg_press = 0.0f;													// Давление в кг
private:
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
private:
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
private:
	bool IsEngine_Valid = false;			// Если двигатель доступен
};

// Объект вольтметра
class voltmeter
{
public:
	voltmeter(size_t pin = V_PIN);
public:
	void Process();								// Обработка и отправка данных
private:
	void SendData(String header, String value);	// Отправка данных
private:
	bool IsVoltmeter_Vaild = false;				// Если вольтметр доступен
};

// Объект амперметра
class ampermeter
{
public:
	ampermeter() = default;
public:
	void Setup();
	void Process();
private:
	void SendData(String header, String value);
	float convertToMilliV(int32_t i32data);
private:
	Protocentral_ADS1220 pc_ads1220;
	int32_t adc_data;
private:
	bool IsAmpermeter_Valid = false;
};

// Объект обработчика скорости оборотов
class rpm_viewer
{
public:
	rpm_viewer(byte adr = MY_ADDRESS);
public:
	void Process();
private:
	void SendData(String header, String value);
private:
	bool IsRpm_Valid = false;
};

// Система управления
class System
{
public:
	System() = default;
public:	
	void InitiliazeModules();												// Инициализация модулей
public:	
	void PreProcess(size_t b_rate = S_BAUD_RATE, size_t t_out = S_TIMEOUT); // Предпроцесс, ожидание запуска
	void ProcessCommands();													// Обработка входных команд
public:
	void Tick();															// Событие итерации
private:
	hx711_adc tenzo;														// Тензодатчик
	bmp_e_280 bmp;															// Датчик
	Engine engine;															// Двигатель
	voltmeter vm;															// Вольтметр
	ampermeter am;															// Амперметр
	rpm_viewer rpmv;														// Обработчик оборотов
private:
	size_t current_modules_time = 4990;										// Текущий отсчёт времени перед отправкой данных переферийных модулей
	String sub_command = "";												// Подкоманда 
};