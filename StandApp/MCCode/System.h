#pragma once

#include "Headers/commands.h"

/* ���������� ��� ������ � ��� */

#include <Adafruit_INA219.h>

 /******************************/

/* ���������� ��� ������ � BMP180 */

#include <Adafruit_BMP085.h>

/*************************************/

/* ���������� ��� ������ � HTU21D */

#include "SparkFunHTU21D.h"

/**********************************/

/* ���������� ��� ������ � ��� HX711 */

#include <HX711.h>

/*************************************/

/* ��������� */

/* ����� ��������� */

// ���-�� �������� ���������� ������ � INA219 ��� ����������
#define C_DELAY				 50	

// ���-�� �������� ���������� ������ � HX711 ��� ����������
#define T_DELAY				 10	

// ����� �������� ������ ������������ ������� � ��
#define MODULES_UPDATE_TIME	 5000		

// ����� �������� ���������� ��������� � ��
#define DELAY_TIME			 1			

/*******************/

/* ��������� ����������� */

// �������� ������ ������� c SerialPort
#define S_BAUD_RATE			 9600	

// ����� �������� ����� ������ �� SerialPort
#define S_TIMEOUT			 10			

/*************************/

/* �������� ���� */

// ��� clock ��� ��� HX711 1
#define HX711_CLK			 6			

// ��� ������ ��� ��� HX711 1
#define HX711_DOUT			 7			

// ��� clock ��� ��� HX711 2
#define HX711_M_CLK			 10			

// ��� ������ ��� ��� HX711 2
#define HX711_M_DOUT		 11			

/*****************/

/* ���������� ���� */

// ��� ����������
#define V_PIN				 A0			

/*******************/

/* ���� I2C */

// 0x77 - BMP180
// 0x40 - INA219

// �������� �������� �� I2C 400 ��/�
#define	   I2CSpeed			 400000

// ����� I2C ��� Arduino nano
#define	   NANO_ADR 		 0x20		

// ����� I2C ��� Arduino Uno
#define    MAIN_ADDRESS 	 0x50		

/************/

/* ��������� ������� */

// ������������� ����������� ��� ��� HX711
#define HX711_CAL_FACTOR	 1.0f		

// ����������� ��� �������� �. �. � ������ ��� ��� HX711
#define HX711_SCALE			 0.035274f	

// ������������ ��������� ���������� � �������
#define MAX_V				 50			

// ������������� ������� ����� (R = U / I) � ��
#define SHUNT_1_RESISTANCE	 0.0005		

// ������������� ������� ����� (R = U / I) � ��
#define SHUNT_2_RESISTANCE	 0.0005		

/*********************/

/*************/

// ���������
class voltmeter
{
public:
	voltmeter(uint8_t pin);
public:
	void Process(String header);
private:
	uint8_t pin;
};

// ���������
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

// ���������� �������� ��������
class rpm_viewer
{
public:
	void Process(String header);
};

// �������� ������� ��������, ��������� � �����������
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

// ���������� ��� HX711
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

// ���������� ����������
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

// ������� ����������
class System
{
public:
	System();
public:	
	// ������������� �������
	void InitiliazeModules();												
public:	
	// �������������
	void PreProcess(size_t b_rate = S_BAUD_RATE, size_t t_out = S_TIMEOUT); 

	// ���������� ������� ������
	void ProcessCommands();													
public:
	// ������� ��������
	void Tick();															
private:
	// ����������� 1
	hx711_adc tenzo1;

	// ����������� 2
	hx711_adc tenzo2;		

	// ���������
	Engine engine;															
	
	// ������ ��������, ����������� � ���������
	BarHumManager bmp;	

	// ���������
	voltmeter vm;			

	// ���������
	ampermeter amp;			

	// ���������� ��������
	rpm_viewer rpmv;														
private:
	// ������� ������ ������� ����� ��������� ������ ������������ �������
	size_t current_modules_time = 4990;			

	// ������� ������ ������� ����� ����������� ������ � �����
	size_t current_time = 0;			

	// ������� ������ ������� ����� ����������� ������ ����
	size_t current_t_time = 0;

	// ���������� 
	String sub_command = "";												
};