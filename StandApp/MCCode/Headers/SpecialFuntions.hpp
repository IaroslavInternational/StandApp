#pragma once

#include <Arduino.h>
#include <Wire.h>
#include "commands.h"

namespace SpecialFunctions
{
	static void SendData(String header, String value)
	{
		Serial.print(header);
		Serial.print(SPLITTER_SIGN);
		Serial.print(value);

		Serial.println();
	}

    template<typename T>
    static int I2C_write(const T& value)
    {
        const byte* p = (const byte*)&value;
        unsigned int i;

        for (i = 0; i < sizeof value; i++)
            Wire.write(*p++);

        return i;
    }

    template<typename T> 
    static int I2C_read(T& value)
    {
        byte* p = (byte*)&value;
        unsigned int i;

        for (i = 0; i < sizeof value; i++)
            *p++ = Wire.read();

        return i;
    }

    template<typename T>
    static T mean(T* arr, size_t len)
    {
        T sum = (T)0.0;

        for (size_t i = 0; i < len; i++)
        {
            sum = sum + arr[i];
        }

        return T(sum / len);
    }
}