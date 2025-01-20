void PaymentProcess:: automatonOfStates()
{
  while(currentState != terminalStatus::EXIT)
  {
    Serial.println("Current State: " + getCurrentStateString());
    switch(currentState)
    {
      case terminalStatus::CONNECT_TERMINAL_TO_SERVER:
        ComPortConnect();
        break;
      
      case terminalStatus::MENU:
        Menu();
        break;

      case terminalStatus::WAITING_INPUT_PRICE:
        displayMessage("RUB", true, 13, 1);                         
        displayMessage("To be paid:", false, 0, 0);     

        currentState = terminalStatus::WAITING_CARD;
        setPrice(keyboard());
        break;

      case terminalStatus::WAITING_CARD:
        currentState = terminalStatus::INPUT_PINCODE;
        rfidCard();
        break;
      
      case terminalStatus::INPUT_PINCODE:
        displayMessage("Input pincode:", true, 0, 0);

        currentState = terminalStatus::PROCESSING_PAYMENT;
        setPincode(keyboard());
        break;

      case terminalStatus::PROCESSING_PAYMENT:
        currentState = terminalStatus::MENU;
        processPayment();
        break;
      
      case terminalStatus::INVALID_PINCODE:
        currentState = terminalStatus::INPUT_PINCODE;
        break;

      case terminalStatus::EXIT:
        displayMessage("EXIT", true, 0, 0);
        delay(3000);
        break;

      default:
        displayMessage("Error terminal", true, 0, 0);
        delay(5000);
        currentState = terminalStatus::EXIT;
        break;
    }
  }
  currentState = terminalStatus::MENU;
}