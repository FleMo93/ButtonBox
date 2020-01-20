//7 8

byte ofColumns[] = { 7, 8 };
byte ofRows[] = { 9, 10 };

void setupOfSwitch() {
  for (byte c = 0; c < sizeof(ofColumns) / sizeof(ofColumns[0]); c++) {
    pinMode(ofColumns[c], OUTPUT);
    digitalWrite(ofColumns[c], LOW);
  }

  for (byte r = 0; r < sizeof(ofRows) / sizeof(ofRows[0]); r++) {
    pinMode(ofRows[r], INPUT_PULLUP);
  }
}

void loopOfSwitch() {

}
 
