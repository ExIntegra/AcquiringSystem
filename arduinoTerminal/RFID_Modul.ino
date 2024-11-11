/*************************************************************
* Функция для обработки RFID-метки (банковской карты)        *
*************************************************************/

void rfidCart(String &uidString){

  if (!rfid.PICC_IsNewCardPresent()) return false;  // Если новая метка не поднесена - вернуться в начало loop
  if (!rfid.PICC_ReadCardSerial()) return false;    // Если метка не читается - вернуться в начало loop
  
  for (uint8_t i = 0; i < 4; i++) {             
    uidString += String(rfid.uid.uidByte[i], HEX);
  }

  Serial.println(uidString);
  uidString = "0x";
}