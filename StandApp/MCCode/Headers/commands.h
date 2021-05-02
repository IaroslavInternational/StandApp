#pragma once

#define SPLITTER_SIGN "|"

/* Список команд */

#define TEST_QUERY "[Test connection]\n"
#define WORK_MODE_ACTIVE "[Work mode]\n"
#define SHUTDOWN "[Reset]\n"
#define ENGINE_WRITE "[Engine write]"

/*****************/

/* Список ответов */

#define TEST_QUERY_SUCCESS "[Connection succeded]"
#define WORK_MODE_ACTIVATING "[Activating work mode]"

/* BMP/E 280 */

#define BMP_E_NOT_VALID "[BMP/E 280 is not valid]"
#define BMP_E_VALID "[BMP/E 280 was connected]"

#define BMP_E_TEMP "[BMP/E 280 temperature]"
#define BMP_E_PRES "[BMP/E 280 pressure]"
#define BMP_E_HUM "[BMP/E 280 humidity]"

/*************/

/* HX711 */

#define HX711_PRES "[HX 711 pressure]"

/*********/

/******************/