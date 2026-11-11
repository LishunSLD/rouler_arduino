using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;


public class OscProcess : MonoBehaviour

{
    public extOSC.OSCReceiver oscReceiver;
    public extOSC.OSCTransmitter oscTransmitter;
    public Player player;

    void Start()
    {
        oscReceiver.Bind("/enc/but", TraiterMessageButton);
        oscReceiver.Bind("/enc/rot", TraiterRot);
    }
    void TraiterMessageButton(OSCMessage message)
    {
        int valeur = message.Values[0].IntValue;

        Debug.Log("Reçu : " + message.Address + " " + valeur);

        if (valeur == 1)
        {
            player.Jump();
        }
    }

    void TraiterRot(OSCMessage message)
    {
        int valeur = message.Values[0].IntValue * -50;

        player.AddTorque(valeur);
    }

    void Update()
    {

    }
}