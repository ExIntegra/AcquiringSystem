#ifndef PAYMENT_PROCESSOR_H
#define PAYMENT_PROCESSOR_H

enum class terminalStatus{
  CONNECT_TERMINAL_TO_SERVER,
  WAITING_INPUT_PRICE,
  WAITING_CARD,
  INPUT_PINCODE,
  PROCESSING_PAYMENT,
  PAYMENT_SUCCESS,
  CARD_BLOCKED,
  INVALID_PINCODE,
  NO_MONEY,
  ERROR_SERVER,
  ERROR_TERMINAL,
  EXIT
};


class PaymentProcess{
  public:
    void automatonOfStates();
    PaymentProcess(): currentState(terminalStatus::CONNECT_TERMINAL_TO_SERVER)
    {}

  private:
    terminalStatus currentState;
    String uid = "2002 2014 2653 8942";
    int pincode = 1234;
    int price = 5021;

    String getCurrentStateString();
    int keyboard(void);
    bool isDigit1(int digits);
    void setPincode(int pincode);
    void setPrice(int price);
    void setUID(String uid);
    void rfidCard(void);
    void comPortConnect(void);
    void processPayment(int price, String uid);
    void displayMessage(const String& message, bool clear, uint8_t rows, uint8_t cols);
};

#endif