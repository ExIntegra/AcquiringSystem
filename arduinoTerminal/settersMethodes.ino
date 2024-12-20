void PaymentProcess::setUID(String uid)
{
  uint8_t maxLengthUID = 8;

  if(uid.length() == maxLengthUID){
    this->uid = uid;
  }

  else{
    displayMessage("Error uid card", true, 0, 0);
    delay(3000);
    currentState = terminalStatus::WAITING_INPUT_PRICE;
    }
}
////////////////////////////////////////////////////////////////////////////
void PaymentProcess::setPrice(int price)
{
  if(price > 0 || isDigit1(price)){
    this->price = price;
  }
            
  else{
    displayMessage("Error input price", true, 0, 0);
    delay(3000);
    currentState = terminalStatus::WAITING_INPUT_PRICE;
  }  
}
////////////////////////////////////////////////////////////////////////////
void PaymentProcess::setPincode(int pincode)
{
  if(pincode > 0 || isDigit1(pincode)){
    this->pincode = pincode;
  }

  else{
    displayMessage("Error set pincode", true, 0, 0);
    delay(3000);
    currentState = terminalStatus::WAITING_INPUT_PRICE;
    }
}
