void PaymentProcess:: automatonOfStates()
{
  while(currentState != terminalStatus::EXIT)
  {
    //Serial.println("Current State: " + getCurrentStateString());
    switch(currentState)
    {
      case terminalStatus::CONNECT_TERMINAL_TO_SERVER:
        currentState = terminalStatus::WAITING_INPUT_PRICE;
        comPortConnect();
        break;

      case terminalStatus::WAITING_INPUT_PRICE:
        currentState = terminalStatus::WAITING_CARD;
        displayMessage("RUB", true, 13, 1);                         
        displayMessage("K oplate", false, 0, 0);                
        setPrice(keyboard());
        break;

      case terminalStatus::WAITING_CARD:
        displayMessage("Go card", true, 0, 0);
        rfidCard();
        currentState = terminalStatus::INPUT_PINCODE;
        break;
      
      case terminalStatus::INPUT_PINCODE:
        currentState = terminalStatus::PROCESSING_PAYMENT;
        displayMessage("Input pincode:", true, 0, 0);
        setPincode(keyboard());
        break;

      case terminalStatus::PROCESSING_PAYMENT:
        processPayment(price, uid);
        break;

      case terminalStatus::PAYMENT_SUCCESS:
        displayMessage("Payment", true, 0, 0);                 
        displayMessage("successful!", false, 2, 0);
        currentState = terminalStatus::EXIT;
        break;
      
      case terminalStatus::CARD_BLOCKED:
        displayMessage("Card is block", true, 0, 0);
        currentState = terminalStatus::EXIT;
      
      case terminalStatus::INVALID_PINCODE:
        displayMessage("invalid pincode", true, 0, 0);
        currentState = terminalStatus::WAITING_INPUT_PRICE;
        break;

      case terminalStatus::NO_MONEY:
        displayMessage("No money", true, 0, 0);
        currentState = terminalStatus::EXIT;
        break;
      
      case terminalStatus::ERROR_SERVER:
        displayMessage("Error server", true, 0, 0);
        currentState = terminalStatus::EXIT;
        break;

      case terminalStatus::EXIT:
        displayMessage("EXIT", true, 0, 0);
        break;

      default:
        displayMessage("Error terminal", true, 0, 0);
        currentState = terminalStatus::EXIT;
        break;
    }
  }
  //Serial.println("Current State: EXIT");
  displayMessage("ENDING JOB", true, 0, 0);
}