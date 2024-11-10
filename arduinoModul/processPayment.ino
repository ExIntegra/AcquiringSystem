/*************************************************************
* Функция отпавляет на сервер запрос на платеж по карте и    *
* возвращает статуса оплаты (true или false)                 *
*************************************************************/

void processPayment(  String &pincodeString, ///< pincodeString - буффер пинкода
                      int &attemptCounter)   ///< attemptCounter - счетчик неудачных попыток
{
  bool statusTransaction;
  bool blockIsCart = false;

  displayMessage("Processing tran-", true, 0, 0, false);
  displayMessage("saction.Wait", false, 0, 1, false);

  for (int j = 0; j < 4; j++)
  {
    lcd.print(".");
    delay(1000);
  }

  //отправляем пинкод, UID-карты и количество попыток на сервер и обрабатываем платеж

  if(statusTransaction == true && blockIsCart == false)
  {
    displayMessage("Payment", true, 4, 0, false);
    displayMessage("successful!", false, 2, 1, true);
    pincodeString = "";
  }
  
  else if(blockIsCart == true)
  {
    displayMessage("Cart is block", true, 0,0, true);
    pincodeString = "";
  }

  else
  {
    displayMessage("No money", true, 0, 0, true);
    attemptCounter++;
    pincodeString = "";
  }

}