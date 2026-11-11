#include <Arduino.h>

#include <Bounce2.h>
Bounce2::Button button1;

#include <Chrono.h>
Chrono chronoPot;

#include <MicroOscSlip.h>
MicroOscSlip<128> monOsc(&Serial);

#include <M5_Encoder.h>
M5_Encoder monEncodeur;

void setup()
{
    Wire.begin();
    monEncodeur.begin();
    Serial.begin(115200);
}

void loop()
{
    monEncodeur.update();

    int changementEncodeur = monEncodeur.getEncoderChange();

    if (changementEncodeur != 0)
    {
        monOsc.sendInt("/enc/rot", changementEncodeur);
    }

    if (monEncodeur.wasPressed())
    {
        monOsc.sendInt("/enc/but", 1);
    }
    if (monEncodeur.wasReleased())
    {
        monOsc.sendInt("/enc/but", 0);
    }
}