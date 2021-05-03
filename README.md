# StandApp
Программа для управления тягой двигателей и анализа результатов.

## Информация по подключению к Arduino Mega.
Датчик GY-BMP/E 280 -> Arduino Mega: <br/>
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

Bluetooth-модуль HC-06 -> Arduino Mega: <br/>
<pre>
RX  -> TX0 <br/>
TX  -> RX0 <br/>
VCC -> 5.0v <br/>
GND -> GND <br/>
</pre>

Двигатель -> Arduino Mega: <br/>
<pre>
Сигн. провод           -> Цифр. 12 <br/>
GND                    -> GND <br/>
VCC                    -> 3.3v / 5.0v
</pre>

Делитель напряжения -> Arduino Mega <br/>
<pre>
Вход 1 (+)  ->> Вход R1
Вход 2 (-)  ->> Вход R2 -> GND
Выход R1                -> A5
Выход R2                -> A5
</pre>

## Советы.
1) При прошивке отключить питание Bluetooth-модуля;
2) Проверить номиналы резисторов на делителе входного напряжения;
3) Питание драйвера подбирать под свой драйвер;
4) Подключать все модули по приложеной схеме.
