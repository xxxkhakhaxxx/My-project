/* --------------- INCLUDE LIBRARY --------------- */
#include "GUI_Control_ver2.h"
#include <Servo.h> 

/* --------------- CREATE OBJECT - CHANGE NAME BASE ON HARDWARE INPUT SETTING --------------- */
#define time_delay 1000   // Thời gian delay giữa các bước trong Auto (ms)     

#define encoder1 5000     // M1 encoder pulse per revolution  - base on ezi-servo driver setting
#define motor1_dpr 1      // M1 distance per revolution       - base on axis hardware (mm)
#define motor1_stept 100  // M1 time for a pulse              - this means speed (us)

#define encoder2 5000     // M2 encoder pulse per revolution  - base on ezi-servo driver setting
#define motor2_dpr 1      // M2 distance per revolution       - base on axis hardware (mm) 
#define motor2_stept 100  // M2 time for a pulse              - this means speed (us)

Sensor SX_P(SENSOR_1);      // Xlimit+ is S1 input
Sensor SX_N(SENSOR_2);      // Xlimit- is S2 input
Sensor SY_P(SENSOR_3);      // Ylimit+ is S3 input
Sensor SY_N(SENSOR_4);      // Ylimit- is S4 input

/* ------------------------------------- Do not touch these code  ------------------------------------- */
Motor M_X(motor1_pul, motor1_dir, motor1_ala, motor1_ser, motor1_rst, encoder1, motor1_dpr, motor1_stept);     // X-AXIS is Motor1 input
Motor M_Y(motor2_pul, motor2_dir, motor2_ala, motor2_ser, motor2_rst, encoder2, motor1_dpr, motor2_stept);     // Y-AXIS is Motor2 input
Relay RL(RELAY);            // RELAY is named as RL
Servo RC_Servo;             // Servo 

bool flag_cmd=0, flag_auto=0, flag_home=0;          // 0 when done everything, 1 when not done yet
char cmd_buffer[18] = {};
unsigned int value_1 = 0;
unsigned int N=0, K=0, H=0, L=0;
unsigned long Home_pulse = 0; 

void setup() {
  M_X.init();               // Initial motor I/O
  M_Y.init();               // Initial motor I/O
  RC_Servo.attach(servo_pwm);
  RC_Servo.write(0);        // Home position
  pinMode(T,INPUT_PULLUP);
  Serial.begin(115200);     // Initial communicate
}

void loop() {
  if(!flag_cmd){            // Check command flag   // If no command: Find command on Serial
      if(Serial.available()>=6)
      {
          Serial.readBytesUntil('\n',cmd_buffer,18);
          Serial.flush();
          flag_cmd = 1;
      }      
  }
  else{                     // Have command: Execute the command
      M_X.on();                       // Start motor only have command
      M_Y.on();                       // Start motor only have command
      /* --------------- MANUAL WINDOW --------------- */
      if(cmd_buffer[0] == 'M')       
      {
          if(cmd_buffer[1] == '0')          // If relay button
          {
              if(char2num(&cmd_buffer[2]) == 1) RL.on();     // turn on  relay   
              else                              RL.off();    // turn off relay  
          }   
          else if(cmd_buffer[1] == '1')     // M1XXX : motor 1 "-" button
          {   M_X.controlmanual(char2num(&cmd_buffer[2]),BACKWARD,SX_N,mm);    }
          else if(cmd_buffer[1] == '2')     // M2XXX : motor 1 "+" button
          {   M_X.controlmanual(char2num(&cmd_buffer[2]),FORWARD ,SX_P,mm);     }
          else if(cmd_buffer[1] == '3')     // M3XXX : motor 2 "-" button
          {   M_Y.controlmanual(char2num(&cmd_buffer[2]),BACKWARD,SY_N,um);    }
          else if(cmd_buffer[1] == '4')     // M4XXX : motor 2 "+" button
          {   M_Y.controlmanual(char2num(&cmd_buffer[2]),FORWARD ,SY_P,um);     }
          Serial.flush();
      }
      /* --------------- AUTO WINDOW --------------- */
      // Bổ sung chỉnh sửa: thêm K (servo), cập nhật chu trình
      else if(cmd_buffer[0] == 'A')
      {
          if(cmd_buffer[1] == '0')              // If Home button   // No use
          {          }
          else if(cmd_buffer[1] == '2')         // If Start button
          {
              flag_auto = 1;                    // Set auto flag
              RL.off();                         // Turn off relay          
              N = char2num(&cmd_buffer[2]);     // Loop
              K = char2num(&cmd_buffer[6]);     // Servo loop
              H = char2num(&cmd_buffer[10]);    // M_Y H
              L = char2num(&cmd_buffer[14]);    // M_X L
              
              for(int i=1;i<=N;i++)            // Loop N time
              {
              // Step 1 : Run M_X forward L (mm)
                  if(flag_auto)
                  {
                      M_X.controlauto(L,FORWARD,SX_P,mm);   
                      delay(time_delay);
                  }                      
              // Step 2 : Run M_X backward L (mm)
                  if(flag_auto)
                  {
                      M_X.controlauto(L,BACKWARD,SX_N,mm);    
                      delay(time_delay);
                  }                      
              // Step 3 - 4 : While waiting for peripheral's signal, blink the relay
                  if(flag_auto)
                      blinkRL_checkT(RL,400);   // RL On 400ms, off 400ms   // Stop when receive HIGH signal from T or Receive STOP COMMAND
              // Step 5 : RC Servo loop K
                  if(flag_auto)
                  {
                      for(int k=1;k<=K;k++)
                      {
                          RC_Servo.write(180);
                          delay(300);    
                          RC_Servo.write(0);
                          delay(300);
                      // If have new command: check if that is stop command or not, if not -> ignore and delete that cmd    
                          if(Serial.available()>=6)           
                          {
                              Serial.readBytesUntil('\n',cmd_buffer,18);
                              Serial.flush();                 // Clear serial buffer
                              if((cmd_buffer[0] == 'A')&&(cmd_buffer[1] == '1'))    // If stop button
                              {
                                  flag_auto = 0;              // Reset the auto flag
                                  RL.off();                   // Old Relay off       
                                  M_X.off();
                                  M_Y.off();
                                  break;                      // break the "for"
                              }             
                          }
                      }
                      delay(time_delay);
                  }
              // Step 6 : Run M_Y backward H (um)
                  if(flag_auto)
                  {
                      M_Y.controlauto(H,BACKWARD,SY_N,um);    // Run M_Y forward l1 (um)
                      delay(time_delay);
                  }    
              }
              flag_auto = 0;                    // Reset auto flag
          } 
          else if(cmd_buffer[1] == '3')         // If change to Auto window
          {
              Home_pulse = 0;
              RL.off();
              RC_Servo.write(0);
          }
          else if(cmd_buffer[1] == '1')         // If Stop button 
          {
              RL.off();
              RC_Servo.write(0);
              M_X.off();
              M_Y.off(); 
          }
      } 
      flag_cmd = 0;                     // Command is done
  }
}
