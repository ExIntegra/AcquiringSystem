#include <Wire.h>
#include <Key.h>
#include <Keypad.h>
#include <LiquidCrystal_I2C.h>
#include <SPI.h>
#include <MFRC522.h>

struct keyboard
{
  const int ROWS = 4; // Число строк клавиатуры
  const int COLS = 3; // Число столбцов клавиатуры
  const char KEY_STAR = 0x2a; // Символ "*"
  const char KEY_HASH = 0x23; // Символ "#"
  char hexaKeys[keyboard.ROWS][keyboard.COLS] = { // Масив символов из которых состоит клавиатура терминала
  {'1','2','3'},
  {'4','5','6'},
  {'7','8','9'},
  {'*','0','#'}
  };
};

const int RST_PIN = 9; // Пин rfid модуля RST (RFID_Modul.ino)
const int SS_PIN = 10; // Пин rfid модуля SS  (RFID_Modul.ino)
const int PIN_LENGTH = 4; // Длина пинкода (handlePinInput.ino)

MFRC522 rfid(SS_PIN, RST_PIN);   // Объект rfid модуля
MFRC522::MIFARE_Key key;         // Объект ключа
MFRC522::StatusCode status;      // Объект статуса

byte rowPins[keyboard.ROWS] = {8, 7, 6, 5};          // К каким выводам подключаем управление строками
byte colPins[keyboard.COLS] = {4, 3, 2};             // К каким выводам подключаем управление столбцами


LiquidCrystal_I2C lcd(0x27, 16, 2); //
Keypad customKeypad = Keypad(makeKeymap(keyboard.hexaKeys), rowPins, colPins, keyboard.ROWS, keyboard.COLS); //

void setup()
{
  Serial.begin(9600);
  lcd.init();                               // Инициализируем экран
  lcd.backlight();                          // Подсветка
  SPI.begin();                              // Инициализация SPI
  rfid.PCD_Init();                          // Инициализация модуля
  rfid.PCD_SetAntennaGain(rfid.RxGain_max); // Установка усиления антенны
  rfid.PCD_AntennaOff();                    // Перезагружаем антенну
  rfid.PCD_AntennaOn();                     // Включаем антенну

  String priceString = inputPrice();        // Вызываем функцию ввода суммы и сохраняем в переменную priceString (реазиция в inputPrice.ino)
  String uidString = rfidCart();            // Вызываем функцию сканирования rfid-метки (банковской карты) и сохраняем в переменную uidString (реализация RFID_Modul.ino)
  processPayment(priceString, uidString);   // Вызываем функцию обработки транзакции (реализация processPayment.ino)
}

void loop(){} 
