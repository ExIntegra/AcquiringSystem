/***********************************************************
*        Модуль для реализации небольших функций.           *
************************************************************/

// Функция для вывода сообщения на LCD дисплей
void displayMessage(  String message,  ///> message - сообщение для вывода.
                      bool clear,      ///> clear - очистка предыдущих сообщений на дисплее.
                      int rows,        ///> rows - столбец.
                      int cols)        ///> cols - строка.
{
  if(clear)  // Если clear == True - очищаем дисплей от всех символов.
  {
    lcd.clear();
  }                                         
  lcd.setCursor(rows, cols);            // Установка курсора на дисплее для последующего ввода символов.                                   
  lcd.print(message);                  // Вывод сообщения на дисплей.                                      
}
