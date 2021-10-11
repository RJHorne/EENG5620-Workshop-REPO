const int ledPin1 = 9;      // the pin that the LED is attached to
const int ledPin2 = 10;
const int ledPin3 = 11;

boolean led1 = LOW;
boolean led2 = LOW;
boolean led3 = LOW;

int power = 255;

void setup() {

  // initialize the serial communication:

  Serial.begin(9600);

  // initialize the ledPin as an output:

  pinMode(ledPin1, OUTPUT);
  pinMode(ledPin2, OUTPUT);
  pinMode(ledPin3, OUTPUT);
}

void loop() {

  int brightness = 0;

  // check if data has been sent from the computer:

  if (Serial.available()) {
    
    // read the most recent byte (which will be from 0 to 255):

    brightness = Serial.read();
    if (brightness == 114)
    {

      if (led3 == LOW)
      {
        analogWrite(ledPin3, power);
        led3 = HIGH;
      }
      else
      {
        analogWrite(ledPin3, 0);
        led3 = LOW;
      }
    }
    
    if (brightness == 121)
    {

      if (led2 == LOW)
      {
        analogWrite(ledPin2, power);
        led2 = HIGH;
      }
      else
      {
        analogWrite(ledPin2, 0);
        led2 = LOW;
      }
    }
    
    if (brightness == 103)
    {

      if (led1 == LOW)
      {
        analogWrite(ledPin1, power);
        led1 = HIGH;
      }
      else
      {
        analogWrite(ledPin1, 0);
        led1 = LOW;
      }
    }
    if(brightness >= 48 && brightness <= 59)
    {
      brightness = brightness - 48;
      brightness = map(brightness, 0, 10, 0, 255);
      // set the brightness of the LED:
      power = brightness;

      if(led1 == HIGH)
      {
        analogWrite(ledPin1, power);
      }
       if(led2 == HIGH)
      {
        analogWrite(ledPin2, power);
      }
       if(led3 == HIGH)
      {
        analogWrite(ledPin3, power);
      }
    }
  
      if(brightness == 116)
      {
        traffic();
      }
  }
      

    
  
}

void traffic()
{
  analogWrite(ledPin3,0);
  analogWrite(ledPin2,0);
  analogWrite(ledPin1,0);
  delay(100);
  analogWrite(ledPin3, power);
  delay(1000);
  analogWrite(ledPin2, power);
  delay(1000);
  analogWrite(ledPin3, 0);
  analogWrite(ledPin2,0);
  analogWrite(ledPin1, power);
  delay(2000);
  analogWrite(ledPin2, power);
  analogWrite(ledPin1, 0);
  delay(1000);
  analogWrite(ledPin3, power);
  analogWrite(ledPin2,0);
  delay(1000);
  analogWrite(ledPin3,0);
  analogWrite(ledPin2,0);
  analogWrite(ledPin1,0);
  led1 = LOW;
  led2 = LOW;
  led3 = LOW;
  
}
