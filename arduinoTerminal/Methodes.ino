void PaymentProcess::comPortConnect()
{
    uint8_t quantityPoints = 3;  
    uint16_t timerForConnect = millis();         // переменная таймера
    uint16_t waitingConnect = 30000;
    String messageForServer = "ConnectServer";
    String messageForArduino = "";
    //Serial.println("Fuction comPortConnect() started");

    while (millis() - timerForConnect <= waitingConnect)
    {
        displayMessage("Connect", false, 0, 0); // Отображаем сообщение о подключении
        for (uint8_t j = 0; j < quantityPoints; j++)                    // Цикл выведения точек для имитации загрузки терминала.
        {
          lcd.print(".");                                           // Выводим поочередно точки
          delay(500);                                              // Задержка между появлениями точек.
        }
        lcd.clear();
        lcd.print("Connect");

        Serial.println(messageForServer); // Отправляем сообщение
        delay(1000); // Задержка перед повторной отправкой

        if (Serial.available() > 0)
        {
            messageForArduino = Serial.readStringUntil('\n'); // Читаем ответ до новой строки
            if (messageForArduino == "ConnectArduino")
            {
              displayMessage("Connect", true, 0, 0); // Сообщение об успешном подключении
              delay(1000);
              return;
            }
        }
    }
    displayMessage("Error Conection", true, 0, 0); // Сообщение об успешном подключении
    //Serial.println("Error Conection");
    currentState = terminalStatus::EXIT;
    delay(5000);
}
////////////////////////////////////////////////////////////////

String PaymentProcess::getCurrentStateString() {
    switch (currentState) {
      case terminalStatus::CONNECT_TERMINAL_TO_SERVER:
        return "CONNECT_TERMINAL_TO_SERVER";
      case terminalStatus::WAITING_INPUT_PRICE:
        return "WAITING_INPUT_PRICE";
      case terminalStatus::WAITING_CARD:
        return "WAITING_CARD";
      case terminalStatus::INPUT_PINCODE:
        return "INPUT_PINCODE";
      case terminalStatus::PROCESSING_PAYMENT:
        return "PROCESSING_PAYMENT";
      case terminalStatus::PAYMENT_SUCCESS:
        return "PAYMENT_SUCCESS";
      case terminalStatus::CARD_BLOCKED:
        return "CARD_BLOCKED";
      case terminalStatus::INVALID_PINCODE:
        return "INVALID_PINCODE";
      case terminalStatus::NO_MONEY:
        return "NO_MONEY";
      case terminalStatus::ERROR_SERVER:
        return "ERROR_SERVER";
      case terminalStatus::ERROR_TERMINAL:
        return "ERROR_TERMINAL";
      case terminalStatus::EXIT:
        return "EXIT";
      default:
        return "UNKNOWN_STATE";
    }
}
////////////////////////////////////////////////////////////////

// Функция для вывода сообщения на LCD дисплей

void PaymentProcess::displayMessage(const String& message,  ///> message - сообщение для вывода.
                                    bool clear,             ///> clear - очистка предыдущих сообщений на дисплее.
                                    uint8_t rows,               ///> rows - столбец.
                                    uint8_t cols)               ///> cols - строка.
{
  if(clear)
  {
    lcd.clear();                       // Если clear == 1 - очищаем дисплей от всех символов.
  }                                                       
  lcd.setCursor(rows,cols);            // Установка курсора на дисплее для последующего ввода символов.                                   
  lcd.print(message);                  // Вывод сообщения на дисплей.                                      
}
////////////////////////////////////////////////////////////////


/************************************************************\
* Функция для обработки RFID-метки (банковской карты)        *
\************************************************************/

void PaymentProcess::rfidCard()
{
  uint16_t timerOfCard = millis();
  uint16_t waitingCard = 10000;
  uint8_t UIDsize = 4;                                // Число байт в UID 
  String uid = "";                        // UID карты в формате HEX

  displayMessage("Go Card", true, 0, 0);
  while(millis() - timerOfCard <= waitingCard)
  {
    if (!rfid.PICC_IsNewCardPresent() || !rfid.PICC_ReadCardSerial()) continue;  // Если новая метка не поднесена или метка не читается - вернуться в начало while

    for (uint8_t i = 0; i < UIDsize; i++)                                            // Если карта считана, то цикл пройдется по байтам и запишем в переменную uidString UID 
    {             
      uid += String(rfid.uid.uidByte[i], HEX);
    }
    setUID(uid);         
    return;                             
  }
  displayMessage("Error Card", true, 0, 0); // Сообщение об успешном подключении
  //Serial.println("Error Card");
  delay(5000);
  currentState = terminalStatus::EXIT;
}
////////////////////////////////////////////////////////////////


/**********************************************************\
* Функция для работы с клавиатурой, возвращает введенно    *
* сообщение типа String                                    *
\**********************************************************/

int PaymentProcess::keyboard()
{
  uint16_t timerOfKeyboard = millis();
  uint16_t waitingKeyboard = 20000;
  uint8_t  cursorPointer = 0;              // Указатель курсора для ввода символа
  char customKey;                      // Создаем переменную для хранения символа, введенного с клавиатуры
  String digitsString = "";                               // Буффер для хранения информации введеной с клавиатуры
  while (millis() - timerOfKeyboard <= waitingKeyboard)                         // Создаем бесконечный цикл для обновления хранимого символа в customKey
  {
    customKey = customKeypad.getKey(); // Получаем текущую нажатую клавишу
    if (!customKey)                    // Если клавиша нажата, то обрабатываем ее вывод и хранение в digitsString
    {
      continue;
    }
      
    if (customKey != keyboard::KEY_HASH && customKey != keyboard::KEY_STAR) // Проверяем на функциональные клавиши KEY_STAR == "*", KEY_HACH = "#""
    {
      lcd.setCursor(cursorPointer, 1);                    // Устанавливаем курсор на начало второй строки
      lcd.print(customKey);                               // Выводим на экран введеный символ пинкода
      cursorPointer++;                                    // Прибавляем в счетчик для перемещения курсора экрана
      digitsString += customKey;                          // Добавляем в буффер введенный символ
    }

    else if (customKey == keyboard::KEY_STAR)             // Если нажата на клавиатуре "*", то происходит удаление введенного последнего символа на экране
    {                                                     
      lcd.setCursor(--cursorPointer, 1);                  // Установка курсора на место последнего введенного символа
      lcd.print(" ");                                     // Заменяем последний введеный символ пустотой
      digitsString.remove(digitsString.length() - 1);     // Удаляем из буффера последний введный символ
    }

    else if(customKey == keyboard::KEY_HASH)              // Если нажата клавиша "#", то выходим из функции и  возвращаем буффер с цифрами
    {                            
      return digitsString.toInt();
    }

    else
    {
      displayMessage("Error keyboard", true, 0, 0);
      delay(5000);
      currentState = terminalStatus::ERROR_TERMINAL;
    }                          
  }
  displayMessage("Timer input", true, 0, 0);
  //Serial.println("Timer input");
  delay(5000);
  currentState = terminalStatus::EXIT;
}
////////////////////////////////////////////////////////////////

/*************************************************************
* Функция отправляет на сервер запрос на платеж по карте     *
*************************************************************/

void PaymentProcess::processPayment(int price,    ///< price - сумма к оплате
                                    String uid)   ///< uidString - уникальный номер rdif-метки (банковской карты)
{
  uint16_t timerProcessPayment = millis();
  uint16_t periodWaiting = 20000;
  String statusTransaction = "";
  String messageForServer = "transaction:" + (String)price + "," + uid + "," + (String)pincode;

  while(millis() - timerProcessPayment <= periodWaiting) //send to server uid price pincode and waiting answer
  {
    String answerServer = Serial.readStringUntil('\r');
    delay(1000);
    Serial.println(messageForServer);
    if(answerServer == messageForServer){
      Serial.println("Good");
    }
  }
  
  displayMessage("Processing tran-", true, 0, 0);             // Вывод на дисплей.
  displayMessage("saction.Wait", false, 0, 1);                // Вывод на дисплей.

  uint8_t quantityPoints = 4;                                     // Количество точек, последовательно выведенных на экран
  for (uint8_t j = 0; j < quantityPoints; j++)                    // Цикл выведения точек для имитации загрузки терминала.
  {
    lcd.print(".");                                           // Выводим поочередно точки
    delay(1000);                                              // Задержка между появлениями точек.
  }

  if(statusTransaction == "paymentSeccess"){
    currentState = terminalStatus::PAYMENT_SUCCESS;
  }
  
  else if(statusTransaction == "invalidPincode"){
    currentState = terminalStatus::INPUT_PINCODE;
  }

  else if(statusTransaction == "blockIsCard"){
    currentState = terminalStatus::CARD_BLOCKED;
  }

  else if(statusTransaction == "noMoney"){
    currentState = terminalStatus::NO_MONEY;
  }

  else{
    displayMessage("Error answer server", true, 0, 0);
    delay(5000);
    currentState = terminalStatus::ERROR_SERVER;
  }
}
/////////////////////////////////////////////////////////////////////////////////////

bool PaymentProcess::isDigit1(int digits){
  String digitsString = String(digits);
  uint8_t digitLegth = digitsString.length();

  for(uint8_t i = 0; i < digitLegth; i++){
    char element = digitsString[i];
    if(!isDigit(element)) return false;
  }
  return true;
}