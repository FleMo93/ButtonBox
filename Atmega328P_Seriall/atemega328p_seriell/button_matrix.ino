void setupButtonMatrix() {
  for (byte c = 0; c < sizeof(columnPins) / sizeof(columnPins[0]); c++) {
    pinMode(columnPins[c], OUTPUT);
    digitalWrite(columnPins[c], LOW);
  }

  for (byte r = 0; r < sizeof(rowPins) / sizeof(rowPins[0]); r++) {
    pinMode(rowPins[r], INPUT_PULLUP);
  }
}

void loopButtonMatrix() {
  for (byte c = 0; c < sizeof columnPins / sizeof columnPins[0]; c++) {
    digitalWrite(columnPins[c], HIGH);

    for (byte r = 0; r < sizeof rowPins / sizeof rowPins[0]; r++) {
      if (digitalRead(rowPins[r]) == HIGH)
        continue;

      Serial.print(rowPins[r]);
      Serial.println(columnPins[c]);
    }

    digitalWrite(columnPins[c], LOW);
  }
}
