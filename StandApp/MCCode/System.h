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

/* ���������� ��� ������ � ��������� ������ */

#include "I2CTrans.h"

/********************************************/

/* ���������� ��� ������ � ��� */

#include <Protocentral_ADS1220.h>

 /******************************/

/* ��������� */

byte MY_ADDRESS = 42;					// ����� �����

/* ����� ��������� */

#define MODULES_UPDATE_TIME	 5000		// ����� �������� ������ ������������ ������� � ��
#define DELAY_TIME			 1			// ����� �������� ���������� ��������� � ��

/*******************/

/* ��������� ����������� */

#define S_BAUD_RATE			 9600		// �������� ������ �������
#define S_TIMEOUT			 10			// ����� �������� ����� ������

/*************************/

/* �������� ���� */

#define HX711_CLK			 6			// ��� clock ��� ��� HX711
#define HX711_DOUT			 7			// ��� ������ ��� ��� HX711
#define ENGINE_PIN			 12			// ��� ���������� ��� ���������
#define ADS1220_DRDY_PIN	 4			// ��� ��� ���
#define ADS1220_CS_PIN		 53			// ��� ��� ���

/*****************/

/* ���������� ���� */

#define V_PIN				 A5			// ��� ����������

/*******************/

/* ���� I2C */

#define BMP_E_ADR			 0x76		// ��� I2C ��� ������� BMP/E 280 (�����)

/************/

/* ��������� ������� */

#define HX711_CAL_FACTOR	 1.0f		// ������������� ����������� ��� ��� HX711
#define HX711_SCALE			 0.035274f	// ����������� ��� �������� �. �. � ������ ��� ��� HX711
#define MAX_V				 50			// ������������ ��������� ���������� � �������
#define SHUNT_1_RESISTANCE	 0.0005		// ������������� ������� ����� (R = U / I) � ��
#define SHUNT_2_RESISTANCE	 0.0005		// ������������� ������� ����� (R = U / I) � ��
#define ENGINE_MIN_MCS		 1000		// ����������� ������ ���-������� ��� ��������� � ���
#define ENGINE_MAX_MCS		 2000		// ������������ ������ ���-������� ��� ��������� � ���
#define PGA					 1			// ����-� �������� ���
#define VREF				 2.048		// ���������� ���������� �� �����
#define VFSR				 VREF/PGA
#define FULL_SCALE			 (((long int)1<<23)-1)

/*********************/

/*************/

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
	float calibration_factor;												// ������������� ���������
	float scale;															// ��������� ��� �������� � ������
	float units = 0.0f;														// �������� ��������
	float kg_press = 0.0f;													// �������� � ��
private:
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
private:
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
private:
	bool IsEngine_Valid = false;			// ���� ��������� ��������
};

// ������ ����������
class voltmeter
{
public:
	voltmeter(size_t pin = V_PIN);
public:
	void Process();								// ��������� � �������� ������
private:
	void SendData(String header, String value);	// �������� ������
private:
	bool IsVoltmeter_Vaild = false;				// ���� ��������� ��������
};

// ������ ����������
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

// ������ ����������� �������� ��������
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

// ������� ����������
class System
{
public:
	System() = default;
public:	
	void InitiliazeModules();												// ������������� �������
public:	
	void PreProcess(size_t b_rate = S_BAUD_RATE, size_t t_out = S_TIMEOUT); // �����������, �������� �������
	void ProcessCommands();													// ��������� ������� ������
public:
	void Tick();															// ������� ��������
private:
	hx711_adc tenzo;														// �����������
	bmp_e_280 bmp;															// ������
	Engine engine;															// ���������
	voltmeter vm;															// ���������
	ampermeter am;															// ���������
	rpm_viewer rpmv;														// ���������� ��������
private:
	size_t current_modules_time = 4990;										// ������� ������ ������� ����� ��������� ������ ������������ �������
	String sub_command = "";												// ���������� 
};