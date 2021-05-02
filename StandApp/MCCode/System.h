#pragma once

#include "Headers/commands.h"

/* ���������� ��� ������ � ��� HX711 */

#include <HX711.h>

/*************************************/

/* ���������� ��� ������ � �������� BMP/E 280 */

#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>

/**********************************************/

/* ���������� ��� ������ � ���������� */

#include <Servo.h>

/**************************************/

/* ��������� */

#define MODULES_UPDATE_TIME	 5000		// ����� �������� ������ ������������ �������
#define DELAY_TIME			 1			// ����� �������� ���������� ���������
#define HX711_DOUT			 7			// ��� ������ ��� ��� HX711
#define HX711_CLK			 6			// ��� clock ��� ��� HX711
#define HX711_CAL_FACTOR	 10.50		// ������������� ����������� ��� ��� HX711
#define HX711_SCALE			 0.035274	// ����������� ��� �������� �. �. � ������ ��� ��� HX711
#define BMP_E_ADR			 0x76		// ��� I2C ��� ������� BMP/E 280
#define ENGINE_PIN			 12			// ��� ���������� ��� ���������
#define S_BAUD_RATE			 9600		// �������� ������ �������
#define S_TIMEOUT			 10			// ����� ����� ������

/*************/

class Serial;
class String;
class HX711;
class Adafruit_BME280;
class Servo;

// ������ ���������� ��� HX711
class hx711_adc
{
public:
	hx711_adc(float cal_factor = HX711_CAL_FACTOR, float scale = HX711_SCALE);
public:
	void Setup(size_t data_pin = HX711_DOUT, size_t clock_pin = HX711_CLK);	// ��������� ��� HX711
	void Process();															// ��������� � �������� ������
private:
	void SendData(String header, String value);								// �������� ������
private:
	HX711 hx711;															// ������ ���	
	const float calibration_factor;											// ������������� ���������
	const float scale;														// ��������� ��� �������� � ������
	float units = 0.0f;														// �������� ��������
	float kg_press = 0.0f;													// �������� � ��
	bool IsHX_Valid = false;												// ���� ��� ��������
};

// ������ ���������� �������� ��������, ��������� � �����������
class bmp_e_280
{
public:
	bmp_e_280() = default;
public:
	void Setup(size_t adr = BMP_E_ADR);			// ��������� ������� BMP/E 280
	void Process();								// ��������� � �������� ������
private:
	void SendData(String header, String value);	// �������� ������
private:
	Adafruit_BME280 bme;						// ������ �������
	bool IsBMP_E_Valid = false;					// ���� ������ ��������
};

// ������ ���������� ����������
class Engine
{
public:
	Engine() = default;
public:
	void Setup(size_t pin = ENGINE_PIN);	// ��������� ���������
	void Process();							// ��������� ������
	void SetVal(size_t value);				// ���������� �������� ��������
private:
	Servo engine;							// ������ ���������
	size_t engine_value = 0;				// �������� �������� ��� ���-�������
	size_t new_value = 0;					// ���������������� �������� ��� ���-�������
	bool IsEngine_Valid = false;			// ���� ��������� ��������
};

// ������� ����������
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
	hx711_adc tenzo;	// �����������
	bmp_e_280 bmp;		// ������
	Engine engine;		// ���������
private:
	size_t current_modules_time = 0;	// ������� ������ ������� ����� ��������� ������ ������������ �������
	String sub_command = "";			// ���������� 
};
