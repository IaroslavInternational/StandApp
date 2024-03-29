# StandApp
Программа для управления тягой двигателей и анализа результатов.

## Советы.
1) При прошивке отключить питание Bluetooth-модуля;
2) Проверить номиналы резисторов на делителе входного напряжения;
3) Питание драйвера взять необходимое по его документации;
4) Подключать все модули строго по приложеной схеме.
5) Не менять пределы ШИМ-сигнала в программе StandApp, иначе есть возможность ошибки драйвера о ненулевом газе;
6) Отпаять шунт-резаистор на 0.1 Ом с INA219 и на его место подсоединить выводы желаемого шунта.

## Схема.
![Схема](https://user-images.githubusercontent.com/71713927/120311667-6f422200-c2e0-11eb-81b9-53a497d4dbf2.png)

## Внешний вид программы.
1) Главная
![image](https://user-images.githubusercontent.com/71713927/146807293-d578f60a-4013-4785-9a86-c68956579a35.png)
2) Настройки
![image](https://user-images.githubusercontent.com/71713927/146807369-de9225ed-2a83-416b-bce3-97537348a30c.png)
3) Подключение
![image](https://user-images.githubusercontent.com/71713927/146807499-7f59d195-64c2-4d72-a783-c989b38006e2.png)
4) Управление
![image](https://user-images.githubusercontent.com/71713927/146807575-1edde06e-273d-426a-98fa-6c3da7151bff.png)
