#include <Wire.h>
#include <Key.h>
#include <Keypad.h>
#include <LiquidCrystal_I2C.h>
#include <SPI.h>
#include <MFRC522.h>

const int ROWS = 4; // число строк клавиатуры
const int COLS = 3; // число столбцов клавиатуры
const int RST_PIN = 9; // Пин rfid модуля RST
const int SS_PIN = 10; // Пин rfid модуля SS
const int PIN_LENGTH = 4; //длина пинкода
const int threshold = 512; // Пороговое значение для преобразования аналогово пина в цифровой
const int MAX_ATTEMPTS = 3; //максимальное число попыток ввода пинкода
const char KEY_STAR = 0x2a; //символ "*"
const char KEY_HASH = 0x23; //символ "#"

MFRC522 rfid(SS_PIN, RST_PIN);   // Объект rfid модуля
MFRC522::MIFARE_Key key;         // Объект ключа
MFRC522::StatusCode status;      // Объект статуса

/* Пороговое значение 512 так как оно является серединой диапазона значений для 10-битного
аналогового-цифрового преобразования (АЦП), который может выдавать значение от 0 до 1023.
Значение до 511 будет считаться низким (0), знасение от 512 до 1023 будет считаться высоким (1) */

char hexaKeys[ROWS][COLS] = { //масив символов из которых состоит клавиатура терминала
  {'1','2','3'},
  {'4','5','6'},
  {'7','8','9'},
  {'*','0','#'}
};

byte rowPins[ROWS] = {8, 7, 6, 5};          // к каким выводам подключаем управление строками
byte colPins[COLS] = {4, 3, 2};             // к каким выводам подключаем управление столбцами


LiquidCrystal_I2C lcd(0x27, 16, 2); //
Keypad customKeypad = Keypad(makeKeymap(hexaKeys), rowPins, colPins, ROWS, COLS); //


void setup()
{
  Serial.begin(9600);
  lcd.init();                               //Инициализируем экран
  lcd.backlight();                          //подсветка

  SPI.begin();                              // Инициализация SPI
  rfid.PCD_Init();                          // Инициализация модуля
  rfid.PCD_SetAntennaGain(rfid.RxGain_max); // Установка усиления антенны
  rfid.PCD_AntennaOff();                    // Перезагружаем антенну
  rfid.PCD_AntennaOn();                     // Включаем антенну
  for (byte i = 0; i < 6; i++){             // Наполняем ключ
    key.keyByte[i] = 0xFF;                  // Ключ по умолчанию 0xFFFFFFFFFFFF
  }
  
}


void loop()
{
  static int i = 0;                         //создание счетчика для передвижения курсора после введенного символа пинкода
  static String UID = "";                   //Идентификатор карты
  static String priceString;                //Количество средств для оплаты по карте
  static String pincodeString = "";         //буффер типа стринг, который будет хранить пинкод                      
  static int attemptCounter = 1;            //счетчик попыток для блокировки карты
  char customKey = customKeypad.getKey();
  lcd.setCursor(0,0);                       // устанавливаем курсор на начало первой строки

  inputPrice(customKey, i, priceString);
}
