#include <Keypad.h>
#include <LiquidCrystal_I2C.h>
#include <SPI.h>
#include <MFRC522.h>
#include "PaymentProcess.h"

struct keyboard // Структура для работы с клавиатурой 3x4
{
  static const uint8_t ROWS = 4; // Число строк клавиатуры
  static const uint8_t COLS = 3; // Число столбцов клавиатуры
  static const char KEY_STAR = 0x2a; // Символ "*"
  static const char KEY_HASH = 0x23; // Символ "#"
};

// Масив символов из которых состоит клавиатура терминала
char hexaKeys[keyboard::ROWS][keyboard::COLS] = {
  {'1','2','3'},
  {'4','5','6'},
  {'7','8','9'},
{keyboard::KEY_STAR,'0',keyboard::KEY_HASH}
};

byte rowPins[keyboard::ROWS] = {8, 7, 6, 5}; // К каким выводам подключаем управление строками
byte colPins[keyboard::COLS] = {4, 3, 2};    // К каким выводам подключаем управление столбцами

const uint8_t RST_PIN = 9; // Пин rfid модуля RST (RFID_Modul.ino)
const uint8_t SS_PIN = 10; // Пин rfid модуля SS  (RFID_Modul.ino)

MFRC522 rfid(SS_PIN, RST_PIN);   // Объект rfid модуля
MFRC522::MIFARE_Key key;         // Объект ключа
MFRC522::StatusCode status;      // Объект статуса


// Создаем объект lcd класса LiquidCrystal_I2C для работы с ЖК-дисплеем.
LiquidCrystal_I2C lcd(0x27, ///< Адрес устройства I2C, базовый адрес
                      16,   ///< Количество столбцов дисплея
                      2);   ///< Количество строк дисплея

// Создаем объект customKeypad класса Keypad для работы с матричной клавиатурой 3x4, считывая и обрабатывая нажатия клавиш.
Keypad customKeypad = Keypad(makeKeymap(hexaKeys), ///< makeKeypmap - функция, создающая карту клавиш
                            rowPins,               ///< Массив, содержащий пины для подключения к клавиатуре
                            colPins,               ///< Массив, содержащий пины для подключения к клавиатуре
                            keyboard::ROWS,        ///< Количество строк в клавиутуре
                            keyboard::COLS);       ///< Количество столбцов в клавиатуре

void setup()                                // Разовый запуск функции для установки значений и вызов функции processPayment
{
  Serial.begin(9600);                       // Инициализируем последовательный порт и задаем передачи данных (бит в сек.)
  lcd.init();                               // Инициал изируем экран
  lcd.backlight();                          // Подсветка
  SPI.begin();                              // Инициализация SPI
  rfid.PCD_Init();                          // Инициализация модуля
  rfid.PCD_SetAntennaGain(rfid.RxGain_max); // Установка усиления антенны
  rfid.PCD_AntennaOff();                    // Перезагружаем антенну
  rfid.PCD_AntennaOn();                     // Включаем антенну
  PaymentProcess terminalArduinoUNO;
  terminalArduinoUNO.automatonOfStates();
}

void loop(){}