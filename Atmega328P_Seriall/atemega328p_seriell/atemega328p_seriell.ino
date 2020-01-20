char id[] = "box1";

byte columnPins[] = { 2, 3 };
byte rowPins[] = { 4, 5 };

const byte ledPin =  13;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);

  setupButtonMatrix();
  setupOfSwitch();
  setupOfoSwitch();
}

void loop() {
  loopButtonMatrix();
  loopOfSwitch();
  loopOfoSwitch();
}


void serialEvent() {
  int incomingByte = Serial.read();

  if (incomingByte == 97) {
    Serial.println(id);
  }
}
