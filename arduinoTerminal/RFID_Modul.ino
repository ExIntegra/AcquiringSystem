/*************************************************************
* Функция для обработки RFID-метки (банковской карты)        *
*************************************************************/

String rfidCart()
{
  String uidString = "0x";                        // UID карты в формате HEX
  while(true)                                     // Бесконечный цикл, пока карта не будет считана
  {
    if (!rfid.PICC_IsNewCardPresent()) continue;  // Если новая метка не поднесена - вернуться в начало while
    if (!rfid.PICC_ReadCardSerial()) continue;    // Если метка не читается - вернуться в начало while
    for (int i = 0; i < 4; i++)                   // Если карта считана, то цикл пройдется по байтам и запишем в переменную uidString UID 
    {             
      uidString += String(rfid.uid.uidByte[i], HEX);
    }
    break;                                        // Выходим из цикла while()
  }
  return uidString;                               // Возвращаем UID
}