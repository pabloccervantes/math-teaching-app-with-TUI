//--------------VARIABLES-----------------
String cadena_a_enviar;
//----------------------------------------

void setup() {
  //--------------------------------------
  cadena_a_enviar = "";//Se limpia cadena
  //--------------------------------------
  // SE DECLARAN LOS BOTONES COMO ENTRADAS
  pinMode(2, INPUT);
  pinMode(3, INPUT);
  pinMode(4, INPUT);
  pinMode(5, INPUT);
  pinMode(6, INPUT);
  pinMode(7, INPUT);
  pinMode(8, INPUT);
  pinMode(9, INPUT);
  pinMode(10, INPUT);
  pinMode(11, INPUT);
  //-------------------------------------
  //-----------Velocidad-----------------
  Serial.begin(9600);
  //-------------------------------------
}

void loop() {
  cadena_a_enviar = "";//Se limpia cadena
  //-------------------------------------------------------------
  //Se va generando cadena deacuerdo a los estados de los botones
  //-----Cadena resultante: xxxxxxxxxx donde x puede se 1 ó 0----
  if(digitalRead(2) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(3) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(4) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(5) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(6) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(7) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(8) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(9) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(10) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  if(digitalRead(11) == HIGH) {
    cadena_a_enviar+="1";
  } else {
    cadena_a_enviar+="0";
  }
  //-------------------------------------------------------------
  //------------Se envía la cadena generada----------------------
  Serial.println(cadena_a_enviar);
  //-------------------------------------------------------------
  delay(200);//Cinco veces por segundo -- cada 200 ms.
}
