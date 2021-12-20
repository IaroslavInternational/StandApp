#pragma once

#include "Headers/commands.h"

/* Библиотека для работы с АЦП */

#include <Adafruit_INA219.h>

 /******************************/

/* Библиотека для работы с BMP180 */

#include <Adafruit_BMP085.h>

/*************************************/

/* Библиотека для работы с HTU21D */

#include "SparkFunHTU21D.h"

/**********************************/

/* Библиотека для работы с АЦП HX711 */

#include <HX711.h>

/*************************************/

/* Настройки */

/* Общие настройки */

// Кол-во итерация считывания данных с INA219 для усреднения
#define C_DELAY				 50	

// Кол-во итерация считывания данных с HX711 для усреднения
#define T_DELAY				 10	

// Время отправки данных переферийных модулей в мс
#define MODULES_UPDATE_TIME	 5000		

// Время задержки выполнения программы в мс
#define DELAY_TIME			 1			

/*******************/

/* Настройки подключения */

// Скорость обмена данными c SerialPort
#define S_BAUD_RATE			 9600	

// Время ожидания приёма данных от SerialPort
#define S_TIMEOUT			 10			

/*************************/

/* Цифровые пины */

// Пин clock для АЦП HX711 1
#define HX711_CLK			 6			

// Пин данных для АЦП HX711 1
#define HX711_DOUT			 7			

// Пин clock для АЦП HX711 2
#define HX711_M_CLK			 10			

// Пин данных для АЦП HX711 2
#define HX711_M_DOUT		 11			

/*****************/

/* Аналоговые пины */

// Пин вольтметра
#define V_PIN				 A0			

/*******************/

/* Шина I2C */

// 0x77 - BMP180
// 0x40 - INA219

// Скорость передачи по I2C 400 кБ/с
#define	   I2CSpeed			 400000

// Адрес I2C для Arduino nano
#define	   NANO_ADR 		 0x20		

// Адрес I2C для Arduino Uno
#define    MAIN_ADDRESS 	 0x50		

/************/

/* Настройки модулей */

// Калибровочный коэффициент для АЦП HX711
#define HX711_CAL_FACTOR	 1.0f		

// Коэффициент для перевода е. и. в граммы для АЦП HX711
#define HX711_SCALE			 0.035274f	

// Максимальное измерямое напряжение в вольтах
#define MAX_V				 50			

// Сопротивление первого шунта (R = U / I) в Ом
#define SHUNT_1_RESISTANCE	 0.0005		

// Сопротивление второго шунта (R = U / I) в Ом
#define SHUNT_2_RESISTANCE	 0.0005		

/*********************/

/*************/

// Вольтметр
class voltmeter
{
public:
	voltmeter(uint8_t pin);
public:
	void Process(String header);
private:
	uint8_t pin;
};

// Амперметр
class ampermeter
{
public:
	void Setup();
public:
	void Process(String header);
	float GetVoltage();
private:
	Adafruit_INA219 ina219;
};

// Обработчик скорости оборотов
class rpm_viewer
{
public:
	void Process(String header);
};

// Менеджер датчика давления, влажности и температуры
class BarHumManager
{
public:
	void Setup();					
	void Process(String t_header, String p_header, String hum_header);	
private:
	Adafruit_BMP085 bmp;			
	HTU21D htu;
private:
	bool IsBMP_E_Valid = false;		
};

// Управление АЦП HX711
class hx711_adc
{
public:
	hx711_adc(float cal_factor, float scale);
public:
	void Setup(size_t data_pin, size_t clock_pin);	
	void Process(String header);			
	float GetUnits();
private:
	HX711 hx711;									
	float calibration_factor;						
	float scale;									
	float units =	 0.0f;								
	float kg_press = 0.0f;							
private:
	bool IsHX_Valid = false;						
};

// Управления двигателем
class Engine
{
public:
	void Process(const byte& adr);
	void SetVal(int value);		
private:
	int engine_value = 0;		
	int new_value = 0;			
private:
	bool IsEngine_Valid = false;
};

// Система управления
class System
{
public:
	System();
public:	
	// Инициализатор модулей
	void InitiliazeModules();												
public:	
	// Предпроцессор
	void PreProcess(size_t b_rate = S_BAUD_RATE, size_t t_out = S_TIMEOUT); 

	// Обработчик входных команд
	void ProcessCommands();													
public:
	// Событие итерации
	void Tick();															
private:
	// Тензодатчик 1
	hx711_adc tenzo1;

	// Тензодатчик 2
	hx711_adc tenzo2;		

	// Двигатель
	Engine engine;															
	
	// Датчик давления, температуры и влажности
	BarHumManager bmp;	

	// Вольтметр
	voltmeter vm;			

	// Амперметр
	ampermeter amp;			

	// Обработчик оборотов
	rpm_viewer rpmv;														
private:
	// Текущий отсчёт времени перед отправкой данных переферийных модулей
	size_t current_modules_time = 4990;			

	// Текущий отсчёт времени перед усреднением данных с шунта
	size_t current_time = 0;			

	// Текущий отсчёт времени перед усреднением данных тяги
	size_t current_t_time = 0;

	// Подкоманда 
	String sub_command = "";												
};