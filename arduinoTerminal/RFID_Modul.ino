/*************************************************************
* Функция для обработки RFID-метки (банковской карты)        *
*************************************************************/

String rfidCart()
{
  int UIDsize = 4;                                // 4 - 
  String uidString = "0x";                        // UID карты в формате HEX
  while(true)                                     // Бесконечный цикл, пока карта не будет считана
  {
    if (!rfid.PICC_IsNewCardPresent() || !rfid.PICC_ReadCardSerial()) continue;  // Если новая метка не поднесена или метка не читается - вернуться в начало while
    for (int i = 0; i < 4; i++)                   // Если карта считана, то цикл пройдется по байтам и запишем в переменную uidString UID 
    {             
      uidString += String(rfid.uid.uidByte[i], HEX);
    }
    break;                                        // Выходим из цикла while()
  }
  return uidString;                               // Возвращаем UID
}
