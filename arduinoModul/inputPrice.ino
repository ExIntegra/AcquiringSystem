void inputPrice(char customKey, int &i, String &priceString)
{
  static bool flag = true;
  lcd.print("To be paid:");
  displayMessage("RUB", false, 13, 1, false);
  if(customKey && flag == true)
  {
    if (customKey != KEY_HASH && customKey != KEY_STAR)   //проверяем на функциональные клавиши KEY_STAR == "*", KEY_HACH = "#""
    {
      lcd.setCursor(i, 1);                                //устанавливаем курсор на начало второй строки
      lcd.print(customKey);                               //выводим на экран введеный символ пинкода
      priceString += customKey;
      i++;                                                //прибавляем в счетчик для перемещения курсора экрана
    }

    else if (customKey == KEY_STAR)                       //удаление введенного символа в экране
    {
      if (i > 0)                                          // проверка на минимальное значение (возможно символов вовсе нет)
      {
        i--;
        lcd.setCursor(i, 1);                              // установка курсора под следующий введенный символ
        lcd.print(" ");                                   // заполнение строки на экране пустотой
        priceString.remove(priceString.length() - 1);
      }                                        
    }
    else
    {
      flag = false; //блокируем клавиатуру для ввода
    }
  }
}