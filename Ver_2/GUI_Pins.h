#ifndef GUI_PINS_H
#define GUI_PINS_H

/* ---------- RAMPS 1.4 HARDWARE PINS ---------- */
#define X_STEP    0   // A0
#define X_DIR     1   // A1
#define X_ENABLE  38  // D38
#define X_ENDSTOP 3   // X_MIN D3

#define Y_STEP    6   // A6
#define Y_DIR     7   // A7
#define Y_ENABLE  2   // A2
#define Y_ENDSTOP 14  // Y_MIN D14

#define Z_STEP    46  // D46
#define Z_DIR     48  // D48
#define Z_ENABLE  8   // A8
#define Z_ENDSTOP 18  // Z_MIN D18

#define SERVO_PWM 4   // D4 - PWM

/* ---------- GUI PROJECT DEFINE PINS ---------- */
#define BUILD_STEP  X_STEP
#define BUILD_DIR   X_DIR
#define BUILD_ENA   X_ENABLE
#define BUILD_MIN   X_ENDSTOP

#define FEEDER_STEP Y_STEP
#define FEEDER_DIR  Y_DIR
#define FEEDER_ENA  Y_ENABLE
#define FEEDER_MIN  Y_ENDSTOP

#define COATER_STEP Z_STEP
#define COATER_DIR  Z_DIR
#define COATER_ENA  Z_ENABLE
#define COATER_MIN  Z_ENDSTOP

#define SERVO SERVO_PWM
#endif
