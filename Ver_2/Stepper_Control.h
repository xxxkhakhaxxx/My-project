#ifndef STEPPER_CONTROL_H
#define STEPPER_CONTROL_H

class Stepper
{
    public:
        Stepper(int ENA_PIN, int DIR_PIN, int PULSE_PIN, int RESOLUTION);
        void init();
        void dir();
        void move();
        void on();
        void off();
    private:
        int _ENA_PIN;
        int _DIR_PIN;
        int _PULSE_PIN;
        int _RESOLUTION;              
};












#endif
