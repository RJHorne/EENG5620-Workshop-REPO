int interruptPin = 2;
volatile byte state = LOW;

void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
  pinMode(interruptPin, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(interruptPin), buttonPressed, CHANGE);
}

void loop() {
  int potRead = analogRead(A3); 
  Serial.println(potRead);
  delay(10);
}

void buttonPressed()
{
  state = !state;
  if(state == LOW)
  {
  Serial.println("d");
  }
  else
  {
    Serial.println("p");
  }
}
