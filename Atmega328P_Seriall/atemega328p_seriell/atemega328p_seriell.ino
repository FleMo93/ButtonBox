char id[] = "box1";

byte columnPins[] = { 2, 3 }; //weiß
byte rowPins[] = { 4, 5 }; //gelb
bool btn1Down = false;

const byte ledPin =  13;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);

  for (byte c = 0; c < sizeof(columnPins)/sizeof(columnPins[0]); c++) {
    pinMode(columnPins[c], OUTPUT);
    digitalWrite(columnPins[c], LOW);
  }

  for (byte r = 0; r < sizeof(rowPins)/sizeof(rowPins[0]); r++) {
    pinMode(rowPins[r], INPUT_PULLUP);
  }
}

void loop() {
  loopButtonArray();
}

void loopButtonArray() {
  for (byte c = 0; c < sizeof columnPins/sizeof columnPins[0]; c++) {
    digitalWrite(columnPins[c], HIGH);    

    for (byte r = 0; r < sizeof rowPins/sizeof rowPins[0]; r++) {
      if (digitalRead(rowPins[r]) == HIGH)
        continue;

      Serial.print(rowPins[r]);
      Serial.println(columnPins[c]);
    }

    digitalWrite(columnPins[c], LOW);  
  }  
}

void serialEvent() {
  int incomingByte = Serial.read();

  if (incomingByte == 97) {
    Serial.println(id);
  }
}
