# StandApp
Программа для управления тягой двигателей и анализа результатов.

## Информация по подключению к Arduino Mega.
Датчик BMP/E 280 -> Arduino Mega: <br/>
<pre>
VCC -> 3.3v <br/>
GND -> GND <br/>
SCL -> SCL <br/>
SDA -> SDA <br/>
</pre>

АЦП HX711 -> Arduino Mega: <br/>
<pre>
DT  -> Цифр. 7 <br/>
SCK -> Цифр. 6 <br/>
VCC -> 5.0v
</pre>

Двигатель -> Arduino Mega: <br/>
<pre>
Сигн. провод (жёлтый)  -> Цифр. 8 <br/>
GND                    -> GND <br/>
VCC                    -> 3.3v
</pre>
