#include <Arduino.h>
#include <Wire.h>

template <typename T> int I2C_write(const T& value)
{
    const byte* p = (const byte*)&value;
    unsigned int i;
    for (i = 0; i < sizeof value; i++)
        Wire.write(*p++);
    return i;
}

template <typename T> int I2C_read(T& value)
{
    byte* p = (byte*)&value;
    unsigned int i;
    for (i = 0; i < sizeof value; i++)
        *p++ = Wire.read();
    return i;
}