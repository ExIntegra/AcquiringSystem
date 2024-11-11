/*************************************************************
* Функция отправляет на сервер запрос на платеж по карте и    *
* возвращает статус оплаты (true или false)                 *
*************************************************************/

void processPayment(  String &pincodeString, ///< pincodeString - буффер пинкода.
                      int &attemptCounter)   ///< attemptCounter - счетчик неудачных попыток.
{
  bool statusTransaction;                                 // Переменная, хранящая статус оплаты, отправляется на сервер и возврашает true или false.
  bool blockIsCart = false;                               // Переменная для блокировки карты
  bool pincodeNeed;

  displayMessage("Processing tran-", true, 0, 0, false);  // Вывод на дисплей.
  displayMessage("saction.Wait", false, 0, 1, false);     // Вывод на дисплей.

  for (int j = 0; j < 4; j++)                             // Цикл для выведения точек для имитации загрузки терминала.
  {
    lcd.print("."); 
    delay(1000);                                          // Задержка между появлениями точек.
  }

  // Отправляем пинкод, UID-карты и количество попыток на сервер и обрабатываем платеж.

  if(statusTransaction == true && blockIsCart == false && pincodeNeed == false)   // Проверяем одобрил ли сервер транзакции и не заблокирована ли карта.
  {
    displayMessage("Payment", true, 4, 0, false);         // Выводим сообщение.
    displayMessage("successful!", false, 2, 1, true);     // Выводим сообщение.
    pincodeString = "";                                   // Очищаем буффер пинкода у терминала.
  }

  else if(statusTransaction == true && blockIsCart == false && pincodeNeed == true)   // Проверяем одобрил ли сервер транзакции и не заблокирована ли карта.
  {
    displayMessage("Payment", true, 4, 0, false);         // Выводим сообщение.
    displayMessage("successful!", false, 2, 1, true);     // Выводим сообщение.
    pincodeString = "";                                   // Очищаем буффер пинкода у терминала.
  }
  
  else if(blockIsCart == true)                            // Проверяем не заблокирована ли "банковская карта".
  {
    displayMessage("Cart is block", true, 0,0, true);     // Выводим сообщение о блокировки карты, дальнейшая оплата по ней невозможна.
    pincodeString = "";                                 
  }

  else
  {
    displayMessage("No money", true, 0, 0, true);         // В случае отказа сервера в транзакции из-за нехватки средств выводим сообщение о отсуствие средств.
    attemptCounter++;                                     // Увеличиваем счетчик попыток оплаты "банковской картой".
    pincodeString = "";                                   
  }

}