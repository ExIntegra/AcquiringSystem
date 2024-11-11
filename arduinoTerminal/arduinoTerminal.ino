#include <Wire.h>
#include <Key.h>
#include <Keypad.h>
#include <LiquidCrystal_I2C.h>
#include <SPI.h>
#include <MFRC522.h>

const int ROWS = 4; // Число строк клавиатуры
const int COLS = 3; // Число столбцов клавиатуры
const int RST_PIN = 9; // Пин rfid модуля RST (RFID_Modul.ino)
const int SS_PIN = 10; // Пин rfid модуля SS  (RFID_Modul.ino)
const int PIN_LENGTH = 4; // Длина пинкода (handlePinInput.ino)
const int threshold = 512; // Пороговое значение для преобразования аналогово пина в цифровой (смотреть smallFunctions.ino)
const int MAX_ATTEMPTS = 3; // Максимальное число попыток ввода пинкода
const char KEY_STAR = 0x2a; // Символ "*"
const char KEY_HASH = 0x23; // Символ "#"

MFRC522 rfid(SS_PIN, RST_PIN);   // Объект rfid модуля
MFRC522::MIFARE_Key key;         // Объект ключа
MFRC522::StatusCode status;      // Объект статуса

char hexaKeys[ROWS][COLS] = { // Масив символов из которых состоит клавиатура терминала
  {'1','2','3'},
  {'4','5','6'},
  {'7','8','9'},
  {'*','0','#'}
};

byte rowPins[ROWS] = {8, 7, 6, 5};          // К каким выводам подключаем управление строками
byte colPins[COLS] = {4, 3, 2};             // К каким выводам подключаем управление столбцами


LiquidCrystal_I2C lcd(0x27, 16, 2); //
Keypad customKeypad = Keypad(makeKeymap(hexaKeys), rowPins, colPins, ROWS, COLS); //


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
  for (byte i = 0; i < 6; i++) { // Наполняем ключ
    key.keyByte[i] = 0xFF;       // Ключ по умолчанию 0xFFFFFFFFFFFF
  }
}


void loop()
{
  static int i = 0;                         // Создание счетчика для передвижения курсора после введенного символа пинкода
  static String uidString = "0x";                 // Идентификатор карты
  static String priceString;                // Количество средств для оплаты по карте
  static String pincodeString = "";         // Буффер, который будет хранить пинкод                      
  static int attemptCounter = 1;            // Счетчик попыток для блокировки карты
  char customKey = customKeypad.getKey();
  lcd.setCursor(0,0);                       // Устанавливаем курсор на начало первой строки
  if(inputPrice(customKey, i, priceString)){
    rfidCart(uidString);
  }
} 
