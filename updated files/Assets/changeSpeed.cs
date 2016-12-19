//Patrick Rygula
//HoloTrack System
//September 20th, 2016
//Script for Manipulating Behavior Tree Movement Speed
//Resource: http://legacy.rivaltheory.com/wiki/

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using System.IO.Ports;
using RAIN.Core;
using RAIN.Motion;
using RAIN.Action;
using RAIN.BehaviorTrees;
using RAIN.Memory;
using RaspberryGPIOManager;

public class changeSpeed: MonoBehaviour
{
    SerialPort serial1 = new SerialPort("COM3", 9600);

    private AIRig cameraAIRig = null;
    private Vector3 destination;
    private int speed;
    private float mph = 0.044704F; //conversion from meters per second to miles per hour (.1 mph)
    private float initialSpeed = 0.22352F;

    //private GPIOPinDriver increaseSpeedButton;
    //private GPIOPinDriver decreaseSpeedButton;

    // Use this for initialization
    void Start()
    {
        serial1.Open();

        serial1.ReadTimeout = 1;

        /*
        serial1 = new SerialPort();
        serial1.PortName = "COM3";
        serial1.Parity = Parity.None;
        serial1.BaudRate = 115200;
        serial1.DataBits = 8;
        serial1.StopBits = StopBits.One;
        */


        //string text = serial1.ReadLine();
        //Debug.Log(text);

        //increaseSpeedButton = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO17, GPIOPinDriver.GPIODirection.In);
        //decreaseSpeedButton = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO27, GPIOPinDriver.GPIODirection.In);

        //increaseSpeedButton.State = GPIOPinDriver.GPIOState.Low;
        //decreaseSpeedButton.State = GPIOPinDriver.GPIOState.Low;

        //cameraAIRig.AI.Motor.Speed = initialSpeed;
    }

    //void Awake()
    //{
    //    cameraAIRig = GetComponentInChildren<AIRig>();
    //}

    // Update is called once per frame
    void Update()
    {
        try
        {
            //print(sp.ReadLine());
            string x = serial1.ReadLine();
            int conversion = Convert.ToInt32(x, 32);
            print(conversion);
            updatemovingspeed(conversion);
        }
        catch (System.Exception)
        {
        }

        //Debug.Log("Initial Speed");
        //Debug.Log(cameraAIRig.AI.Motor.Speed);
        //if(some position is hit that has a bad turn speed)
        //cameraAIRig.AI.Motor.RotationSpeed = some better rotational speed;
        //Debug.Log(increaseSpeedButton.State.ToString());
        //Debug.Log(serial1.ReadLine());

        //if (increaseSpeedButton.State == GPIOPinDriver.GPIOState.High)
        //{
        //    //cameraAIRig.AI.WorkingMemory.SetItem<int>("Move Speed", cameraAIRig.AI.WorkingMemory.GetItem<int>("Move Speed") + 1);
        //    cameraAIRig.AI.Motor.Speed = cameraAIRig.AI.Motor.Speed + mph;
        //    Debug.Log("Increase Speed");
        //    increaseSpeedButton.State = GPIOPinDriver.GPIOState.Low;
        //}

        //if (decreaseSpeedButton.State == GPIOPinDriver.GPIOState.High)
        //{
        //    //cameraAIRig.AI.WorkingMemory.SetItem<int>("Move Speed", cameraAIRig.AI.WorkingMemory.GetItem<int>("Move Speed") - 1);
        //    cameraAIRig.AI.Motor.Speed = cameraAIRig.AI.Motor.Speed - mph;
        //    Debug.Log("Decrease Speed");
        //    decreaseSpeedButton.State = GPIOPinDriver.GPIOState.Low;
        //}

    }
    void updatemovingspeed(int updatedspeed)
    {
        RAIN.Core.AIRig rig = RAIN.Core.AIRig.FindRig(gameObject);
        rig.AI.WorkingMemory.SetItem("speed", updatedspeed);
        float curSpeed2 = rig.AI.WorkingMemory.GetItem<float>("speed");
        Debug.Log("_lookit Speed is now(after):  " + curSpeed2);
    }
}
