/*************************************************************
* Функция для обработки RFID-метки (банковской карты)        *
*************************************************************/

MFRC522 rfid(SS_PIN, RST_PIN);   // Объект rfid модуля
MFRC522::MIFARE_Key key;         // Объект ключа
MFRC522::StatusCode status;      // Объект статуса

void rfidCart(){
  static uint32_t rebootTimer = millis(); // Важный костыль против зависания модуля!
  if (millis() - rebootTimer >= 1000) {   // Таймер с периодом 1000 мс
    rebootTimer = millis();               // Обновляем таймер
    digitalWrite(RST_PIN, HIGH);          // Сбрасываем модуль
    delayMicroseconds(2);                 // Ждем 2 мкс
    digitalWrite(RST_PIN, LOW);           // Отпускаем сброс
    rfid.PCD_Init();                      // Инициализируем заного
  }
  if (!rfid.PICC_IsNewCardPresent()) return false;  // Если новая метка не поднесена - вернуться в начало loop
  if (!rfid.PICC_ReadCardSerial()) return false;    // Если метка не читается - вернуться в начало loop
  
  Serial.print("UID: ");
  for (uint8_t i = 0; i < 4; i++) {           // Цикл на 4 итерации
    Serial.print("0x");                       // В формате HEX
    Serial.print(rfid.uid.uidByte[i], HEX);   // Выводим UID по байтам
    Serial.print(", ");
  }
}
