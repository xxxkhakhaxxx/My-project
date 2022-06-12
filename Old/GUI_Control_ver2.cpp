#include "Arduino.h"
#include "GUI_Control_ver2.h"


// ---------------------- Sensor -----------------------------------------------------------
Sensor::Sensor(int pin)
{
  pinMode(pin,INPUT);

  this->_pin = pin;               // Save pin ID
  switch(pin)                     // Save port ID and bit ID base on pin
  {
    case 42:    // SENSOR_1       // PL7 - Port 12 - bit 128 (0b10000000)
      this->_port = 0b00001100;
      this->_bit  = 0b10000000;
      break;
    case 44:    // SENSOR_2       // PL5 - Port 12 - bit 32  (0b100000)
      this->_port = 0b00001100;
      this->_bit  = 0b00100000;
      break;
    case 46:    // SENSOR_3       // PL3 - Port 12 - bit 8   (0b1000)
      this->_port = 0b00001100;
      this->_bit  = 0b00001000;
      break;
    case 48:    // SENSOR_4       // PL1 - Port 12 - bit 2   (0b10)
      this->_port = 0b00001100;
      this->_bit  = 0b00000010;
      break;
  }
}
int Sensor::check()       // Read sensor's state directly from register of ATMmega2560
{
  if (*portInputRegister(this->_port) & this->_bit) return HIGH;
  return LOW;
}

// ---------------------- Motor -------------------------------------------------------------
Motor::Motor(int pulse_pin, int direction_pin, int alarm_pin, int servo_onoff_pin, int alarm_rst_pin, int encoder, int dpr, int stept)
{
	pinMode(pulse_pin,OUTPUT);              // 1 pulse = 1 step = move 1 resolution
	pinMode(direction_pin,OUTPUT);          // HIGH - FORWARD, LOW - BACKWARD
	pinMode(alarm_pin,INPUT);			          // HIGH when normal, LOW when have problem
	pinMode(servo_onoff_pin,OUTPUT);        // HIGH for cutting off power, LOW for powering
	pinMode(alarm_rst_pin,OUTPUT);          // Generate 1 pulse to cancel the alarm output
  // Save value
	this->_pulse = pulse_pin;
	this->_direction = direction_pin;
	this->_alarm = alarm_pin;
	this->_servo_onoff = servo_onoff_pin;
	this->_alarm_rst = alarm_rst_pin;
	this->_encoder = encoder;
  this->_dpr = dpr;                                            
  this->_resolution = float(this->_dpr)/float(this->_encoder);
  this->_stept = stept/2;
}
void Motor::init()    
{
	  digitalWrite(this->_pulse,LOW);         
	  digitalWrite(this->_direction,LOW);       // BACKWARD
	  //digitalWrite(this->_servo_onoff,LOW);	  // SERVO ON
	  digitalWrite(this->_alarm_rst,LOW);		    // NO RESET
}
void Motor::reset()
{
    if(digitalRead(this->_alarm))             // Check if alarm state is True or not, if True -> reset alarm and turn on motor
    {
        digitalWrite(this->_alarm_rst,HIGH);  // Reset alarm - one 150ms pulse
        delay(150);
        digitalWrite(this->_alarm_rst,LOW);
        digitalWrite(this->_servo_onoff,LOW); // Repower servo
    }
}
bool Motor::checkStopCmd()
{
    if(Serial.available()>=6)               // If have new command: check if that is stop command or not, if not -> ignore and delete that cmd
    {
        char cmd_buffer_term[18]={};
        Serial.readBytesUntil('\n',cmd_buffer_term,18);
        Serial.flush();                     // Clear serial buffer
        if((cmd_buffer_term[0] == 'A')&&(cmd_buffer_term[1] == '1'))    // If stop button
        {
            flag_auto = 0;
            Motor::off();                 // Stop the current motor
            digitalWrite(23,LOW);         // Old Relay off
            digitalWrite(43,LOW);   
            return 1;                     // return TRUE if Stop cmd
        }            
    } 
    return 0;                             // return FALSE if not Stop cmd  
}
// ********************** MANUAL ********************** //
void Motor::controlmanual(unsigned int dis, int dir, Sensor sensor, int unit)      // Control 1 motor in the manual mode
{
    Motor::reset();
    digitalWrite(this->_direction,dir);       // Set direction

    unsigned long pulse = 0;                // Calculate pulse
    if(unit == 0)                           // Check unit of "dis", if mm or um
        pulse = (unsigned long)(round(float(dis)/this->_resolution));                    
    else                                    // um
        pulse = (unsigned long)(round(float(dis)/float(1000)/this->_resolution));   
    Serial.println(pulse,DEC);
    Serial.println(pulse,BIN);
    for(unsigned long i=0; i<pulse; i++)      // Start to generate pulse
    {
        digitalWrite(this->_pulse,HIGH);
        delayMicroseconds(this->_stept);
        digitalWrite(this->_pulse,LOW);
        delayMicroseconds(this->_stept);
        if(sensor.check())                    // Check if reach the limit or not, if yes: stop generating pulse
            break;    
    }
}
// *********************** AUTO *********************** //
/*void Motor::controlhome(Sensor sensor)        // Home button
{
    Motor::reset();
    digitalWrite(this->_direction,BACKWARD);
  
    while(!sensor.check())                    // Stop whenever reaching the limit sensor
    {
        if(Motor::checkStopCmd())             // Break "while" if receive stop cmd: should not contain "Motor::off()"
            break;
        // Continue move home
        digitalWrite(this->_pulse,HIGH);
        delayMicroseconds(this->_stept);
        digitalWrite(this->_pulse,LOW);
        delayMicroseconds(this->_stept);
    }
}*/
void Motor::controlauto(unsigned int dis, int dir, Sensor sensor, int unit)
{
    Motor::reset();
    digitalWrite(this->_direction,dir);

    unsigned long pulse = 0;
    if(unit == 0)                           // Check if the unit is mm or not, and calculate pulse
        pulse = (unsigned long)(round(float(dis)/this->_resolution));                    
    else
        pulse = (unsigned long)(round(float(dis)/float(1000)/this->_resolution));    
           
    for(unsigned long i=0; i<pulse; i++)    // Start to generate pulse
    {
        digitalWrite(this->_pulse,HIGH);
        delayMicroseconds(this->_stept);
        digitalWrite(this->_pulse,LOW);
        delayMicroseconds(this->_stept);
        if(sensor.check())                  // Check if reach the limit or not, if yes: stop generating pulse and cancel auto mode (flag_auto)
        {
            flag_auto=0;
            digitalWrite(23,LOW);           // Old Relay off
            digitalWrite(43,LOW);   
            break;
        }
        if(Motor::checkStopCmd())           // Break "for" if receive stop cmd
            break;
    }
}
/*void Motor::controlautohome(Sensor sensor)// Y axis in auto mode
{
    Motor::reset();
    digitalWrite(this->_direction,BACKWARD);
  
    while(!sensor.check())                  // Stop whenever reaching the limit sensor
    {
        if(Motor::checkStopCmd())           // Break "while" if receive stop cmd
            break;
        // Continue move home if  nothing wrong                           
        digitalWrite(this->_pulse,HIGH);
        delayMicroseconds(this->_stept);
        digitalWrite(this->_pulse,LOW);
        delayMicroseconds(this->_stept);
    }
}*/
void Motor::on()
{
    digitalWrite(this->_servo_onoff,LOW);
}
void Motor::off()
{
    digitalWrite(this->_servo_onoff,HIGH);
}
// ---------------------- Relay -------------------------------------------------------------
Relay::Relay(int pin)
{
	  pinMode(pin,OUTPUT);
    pinMode(23,OUTPUT);             // Old relay
	  this->_pin = pin;
}
void Relay::on()
{
	  digitalWrite(this->_pin,HIGH);
    digitalWrite(23,HIGH);          // Old relay
}
void Relay::off()
{
	  digitalWrite(this->_pin,LOW);
    digitalWrite(23,LOW);          // Old relay
}
void Relay::blink(int t)
{
    digitalWrite(this->_pin,HIGH);
    delay(t);
    digitalWrite(this->_pin,LOW);
    delay(t);
}
// ---------------------- Other ------------------------------------------------------------
unsigned int char2num(char *value)
{
    return (*value-48)*100+(*(value+1)-48)*10+(*(value+2)-48);
}

void blinkRL_checkT(Relay RL, int t)
{
    while(!digitalRead(T))                  // Waiting for signal of sensor T is HIGH
    {
        if(Serial.available()>=6)           // If have new command: check if that is stop command or not, if not -> ignore and delete that cmd
        {
            char cmd_buffer_term[18]={};
            Serial.readBytesUntil('\n',cmd_buffer_term,18);
            Serial.flush();                 // Clear serial buffer
            if((cmd_buffer_term[0] == 'A')&&(cmd_buffer_term[1] == '1'))    // If stop button
            {
                flag_auto = 0;              // Cancel the auto flag
                digitalWrite(23,LOW);       // Old Relay off
                digitalWrite(43,LOW);       
                break;                      // break the "while"
            }             
        }
        RL.blink(t);    
    }
}
