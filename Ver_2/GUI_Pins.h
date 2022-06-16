#ifndef GUI_PINS_H
#define GUI_PINS_H

/* ---------- RAMPS 1.4 HARDWARE PINS ---------- */
#define X_STEP    0   // A0
#define X_DIR     1   // A1
#define X_ENABLE  38  // D38

#define Y_STEP    6   // A6
#define Y_DIR     7   // A7
#define Y_ENABLE  2   // A2

#define Z_STEP    46  // D46
#define Z_DIR     48  // D48
#define Z_ENABLE  8   // A8

#define X_MIN     3   // D3
#define X_MAX     2   // D2
#define Y_MIN     14  // D14
#define Y_MAX     15  // D15
#define Z_MIN     18  // D18
#define Z_MAX     19  // D19

#define RELAY     40  // D40

#define SERVO_PWM 4   // D4 - PWM

/* ---------- GUI PROJECT DEFINE PINS ---------- */
#if 1
    #define BUILD_STEP  X_STEP
    #define BUILD_DIR   X_DIR
    #define BUILD_ENA   X_ENABLE
    #define BUILD_MIN   X_MIN
    #define BUILD_MAX   X_MAX
    
    #define FEEDER_STEP Y_STEP
    #define FEEDER_DIR  Y_DIR
    #define FEEDER_ENA  Y_ENABLE
    #define FEEDER_MIN  Y_MIN
    #define FEEDER_MAX  Y_MAX
    
    #define COATER_STEP Z_STEP
    #define COATER_DIR  Z_DIR
    #define COATER_ENA  Z_ENABLE
    #define COATER_MIN  Z_MIN
    #define COATER_MAX  Z_MAX

    #define SERVO SERVO_PWM
#endif



#endif
