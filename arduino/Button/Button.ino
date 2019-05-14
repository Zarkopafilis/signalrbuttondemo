const int buttonPin = 48;     // the number of the pushbutton pin

int buttonState = 1;

void setup() {
  Serial.begin(9600);  

  pinMode(buttonPin, INPUT_PULLUP);

  delay(300);
  
}

void loop() {
  int newstate = digitalRead(buttonPin);

  int changedState = newstate != buttonState ? 1 : 0;
  
  if (changedState == 1 && newstate == 0) {
      Serial.println("Press");
      delay(1000);
  }

  buttonState = newstate;
}
