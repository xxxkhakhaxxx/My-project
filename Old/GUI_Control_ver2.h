
#ifndef GUI_Control_h		// Define the library if not yet
#define	GUI_Control_h
#include "Arduino.h"
#include "GUI_Configuration.h"

/* --------------- DEFINE PIN NAME --------------- */
// DO NOT CHANGE THESE LINES
#define T 49          // Laser module input
#define RELAY 23      // Old Relay control pin
//#define RELAY 43      // New Relay control pin
#define SENSOR_1 42   // S1 input pin       // PL7 - Port 12 - bit 128 (0b10000000)
#define SENSOR_2 44   // S2 input pin       // PL5 - Port 12 - bit 32  (0b100000)
#define SENSOR_3 46   // S3 input pin       // PL3 - Port 12 - bit 8   (0b1000)
#define SENSOR_4 48   // S4 input pin       // PL1 - Port 12 - bit 2   (0b10)

#define motor1_pul Feeder_pul  // M1 pulse pin
#define motor1_dir Feeder_dir // M1 direction pin 
#define motor1_ala Feeder_ala  // M1 alarm pin
#define motor1_ser Feeder_ser  // M1 servo on/off pin
#define motor1_rst Feeder_rst  // M1 alarm reset pin


#define motor2_pul 12 // M2 pulse pin
#define motor2_dir 13 // M2 direction pin
#define motor2_ala 11 // M2 alarm pin
#define motor2_ser 7  // M2 servo on/off pin
#define motor2_rst 6  // M2 alarm reset pin

#define servo_pwm 5   // PWM pin for control RC Servo

#define FORWARD 1
#define BACKWARD 0
#define mm 0
#define um 1

extern bool flag_auto, flag_home;
extern unsigned long Home_pulse;

/* ----------------- Class / Function declaration --------------- */
class Sensor
{
  public:
    Sensor(int pin);
    int check();
  private:
    int _pin;
    uint8_t _port;
    uint8_t _bit;
};

class Motor
{
	public:
		Motor(int pulse_pin, int direction_pin, int alarm_pin, int servo_onoff_pin, int alarm_rst_pin, int encoder, int dpr, int stept);
		void init();
    void reset();
    bool checkStopCmd();
		void controlmanual(unsigned int dis, int dir, Sensor sensor, int unit); // For manual mode
   // void controlhome(Sensor sensor);                                        // For home button
    void controlauto(unsigned int dis, int dir, Sensor sensor, int unit);   // For start button
   // void controlautohome(Sensor sensor);
    void off();
    void on();
	private:
		int _pulse;
		int _direction;
		int _alarm;
		int _servo_onoff;
		int _alarm_rst;
		int _encoder;
    int _dpr;
    int _stept;
    float _resolution;
};

class Relay
{
	public:
		Relay(int pin);
		void on();
		void off();
    void blink(int t);
	private:
		int _pin;
};

/* ----------------- Other Functions declaration --------------- */
unsigned int char2num(char *value);
void blinkRL_checkT(Relay RL, int t);

#endif
