/************************************************************\
* Метод для первичного подключения к терминалу               *
\************************************************************/

void PaymentProcess::ComPortConnect()
{
    uint8_t quantityPoints = 3;
    uint16_t timerForConnect = millis();
    uint16_t waitingConnect = 30000;
    String messageForServer = "ConnectServer";
    String messageForArduino = "";

    while (true)
    {
        displayMessage("Connect", false, 0, 0);         // Отображаем сообщение о подключении
        for (uint8_t j = 0; j < quantityPoints; j++)    // Цикл выведения точек для имитации загрузки терминала
        {
          lcd.print(".");                                        
          delay(500);                                              
        }
        lcd.clear();
        lcd.print("Connect");

        Serial.println(messageForServer); // Отправляем сообщение на сервер через последовательный порт
        delay(1000);                  

        if (Serial.available() > 0)       // Если в последовательный порт пришло сообщение от сервера, то проверяем его содержимое
        {
            messageForArduino = Serial.readStringUntil('\n'); // Читаем ответ до новой строки
            if (messageForArduino == "ConnectArduino")
            {
              displayMessage("Connect", true, 0, 0);
              delay(1000);
              currentState = terminalStatus::MENU;
              return;
            }
        }
    }
}


/************************************************************\
* Метод реализующий выбор в терминале между регистрацией     *
* карты через терминал или оплатой                           *
\************************************************************/

void PaymentProcess:: Menu(){

  terminalArduinoUNO.displayMessage("* Pay  0 Reload", true, 0, 0);
  terminalArduinoUNO.displayMessage("# Card registr.", false, 0, 1);

  uint16_t timerOfKeyboard = millis();
  uint16_t waitingKeyboard = 10000;                       // Время ожидания ввода 10 секунд 
  char customKey;                                         // Создаем переменную для хранения символа, введенного с клавиатуры

  while (millis() - timerOfKeyboard <= waitingKeyboard)   // Создаем бесконечный цикл для обновления хранимого символа в customKey
  {
    customKey = customKeypad.getKey(); // Получаем текущую нажатую клавишу

    if (!customKey) continue;          // Если кнопка не нажата, то завершаем итерацию

    else if (customKey == keyboard::KEY_STAR){
      currentState = terminalStatus::WAITING_INPUT_PRICE;
      typeOperation = "transaction:";

    }
    else if(customKey == keyboard::KEY_HASH){
      currentState = terminalStatus::WAITING_CARD;
      typeOperation = "registration:";
    }
    else if(customKey == '0'){    
      currentState = terminalStatus::WAITING_INPUT_PRICE;
      typeOperation = "reload:";
    }
  }
  currentState = terminalStatus::EXIT;
}


/************************************************************\
* Метод для отображения состояния терминала в режиме отладки.*
* В работе не используется.                                  *
\************************************************************/

String PaymentProcess::getCurrentStateString() {
    switch (currentState) {
      case terminalStatus::MENU:
        return "MENU";
      case terminalStatus::REGISTRATION_CARD:
        return "REGISTATION_CARD";
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
      case terminalStatus::INVALID_PINCODE:
        return "INVALID_PINCODE";
      case terminalStatus::EXIT:
        return "EXIT";
      default:
        return "UNKNOWN_STATE";
    }
}


/************************************************************\
* Метод для вывода сообщения на LCD терминала                *
\************************************************************/

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


/************************************************************\
* Функция для обработки RFID-метки (банковской карты)        *
\************************************************************/

void PaymentProcess::rfidCard()
{
  uint16_t timerOfCard = millis();
  uint16_t waitingCard = 15000;
  uint8_t UIDsize = 4;   // Число байт в UID 
  String uid = "";

  displayMessage("Go Card", true, 0, 0);

  while(millis() - timerOfCard <= waitingCard) // В цикле реализован таймер для ограничения по времени поднесения карты к терминалу
  {
    if (!rfid.PICC_IsNewCardPresent() || !rfid.PICC_ReadCardSerial()) continue;  // Если новая метка не поднесена или метка не читается - вернуться в начало цикла

    for (uint8_t i = 0; i < UIDsize; i++)   // Если карта считана, то цикл пройдется по байтам и запишет в переменную uidString UID нашей  карты
    {             
      uid += String(rfid.uid.uidByte[i], HEX);
    }
    setUID(uid);   
    Serial.println(uid); //Для отладки, в работе не используется   
    return;
  }
  displayMessage("Time", true, 0, 0);
  currentState = terminalStatus::MENU;  
  delay(5000);
}


/**********************************************************\
* Метод для работы с клавиатурой                           *
\**********************************************************/

String PaymentProcess::keyboard()
{ 
  uint16_t timerOfKeyboard = millis();
  uint16_t waitingKeyboard = 10000;                       // Время ожидания ввода 10 секунд    
  uint8_t  cursorPointer = 0;                             // Указатель курсора на дисплее для ввода символа
  char customKey;                                         // Создаем переменную для хранения символа, введенного с клавиатуры
  String digitsString = "";                               // Буффер для хранения информации введеной с клавиатуры
  while (millis() - timerOfKeyboard <= waitingKeyboard)   // Создаем цикл с ограничением по времени для ввода символов
  {
    customKey = customKeypad.getKey();                    // Получаем текущую нажатую клавишу
    if (!customKey)                                       // Если клавиша не нажата, то пропускам итерацию
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
      lcd.print(" ");                                     // Заменяем последний введеный символ пробелом
      digitsString.remove(digitsString.length() - 1);     // Удаляем из буффера последний введный символ
    }

    else if(customKey == keyboard::KEY_HASH)              // Если нажата клавиша "#", то выходим из функции и  возвращаем буффер с цифрами из метода
    {                            
      return  "," + digitsString;
    }

    else // В случае аномального поведения клавиатуры переводим автомат в состояние ошибки терминала
    {
      displayMessage("Error keyboard", true, 0, 0);
      delay(5000);
    }                        
  }
  currentState = terminalStatus::MENU;

}


/************************************************************\
* Метод отправляет на сервер запрос на операцию с картой     *
\************************************************************/

void PaymentProcess::processPayment()                                   
{
  uint16_t timerProcessPayment = millis();
  uint16_t periodWaiting = 20000;
  uint8_t quantityPoints = 4; 

  displayMessage("Processing tran-", true, 0, 0);
  displayMessage("saction.Wait", false, 0, 1);

  String messageForServer = typeOperation + uid + pincode + price;

  while(millis() - timerProcessPayment <= periodWaiting)
  {
    Serial.println(messageForServer);                   //отправляем на сервер
    String answerServer = Serial.readStringUntil('\r'); //принимает ответ от сервера
    lcd.print(".");

    if(answerServer == messageForServer){ //убеждаемся, что передача данных корректна
      Serial.println("GoodOperation");
      break;
    }
    delay(1000);
  }

  displayMessage("Waiting", true, 0,0);

  while(statusTransaction == ""){
    lcd.print(".");
    delay(1000);
    statusTransaction =  Serial.readStringUntil('\r');
  }

  if(statusTransaction == "pincode"){
    displayMessage("Invalid pincode", true, 0, 0);
    delay(5000);
    currentState = terminalStatus::INPUT_PINCODE;
  }

  else{
    displayMessage(statusTransaction, true, 0, 0);
  }
}


/************************************************************\
* Метод проверяет является ли аргумент типом int             *
\************************************************************/

bool PaymentProcess::isDigit1(int digits){
  String digitsString = String(digits);
  uint8_t digitLegth = digitsString.length();

  for(uint8_t i = 0; i < digitLegth; i++){
    char element = digitsString[i];
    if(!isDigit(element)) return false;
  }
  return true;
}

