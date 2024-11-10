/***********************************************************
*        Модуль для реализации небольших функций           *
************************************************************/

//функция для вывода сообщения на LCD дисплей
void displayMessage(  String message,  ///> message - сообщение для вывода
                      bool clear,      ///> clear - очистка предыдущих сообщений на дисплее
                      int rows,        ///> rows - столбец
                      int cols,        ///> cols - строка
                      bool del){       ///> del - задержка перед исчезновением или замены надписи                                                                             
  if(clear == 1){lcd.clear();}                                              
  lcd.setCursor(rows,cols);                                                  
  lcd.print(message);                                                         
  if(del == 1){delay(2000);}
}



//Функуия преобразования аналоговых пинов в цифровые, принимает в аргумент пин А0 - А%
void analogToDigitSignal(int analogPin)
{
  int analogValue = analogRead(analogPin);
  int digitalValue = (analogValue > threshold) ? 1 : 0; // Преобразование в цифровой сигнал
  Serial.println(digitalValue);
}