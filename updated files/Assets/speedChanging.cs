using UnityEngine;
using System.Collections;
using RAIN.Core;
//using RAIN.Motion;
using RAIN.Memory;
//using RAIN.Action;
//using RAIN.BehaviorTrees;
using System.IO.Ports;
using System;

public class speedChanging : MonoBehaviour
{

    //private int blah = 0;
    //private float updateSpeed = 1.5F;
    SerialPort sp = new SerialPort("COM3", 9600);
    private float mph = 0.044704F; //conversion from meters per second to miles per hour (.1 mph)
    private float conversion = 0;
    private string x = "";
    
    // Use this for initialization
    void Start()
    {
        sp.Open();
        //RAIN.Core.AIRig rig = RAIN.Core.AIRig.FindRig(gameObject);
        //float curSpeed = rig.AI.WorkingMemory.GetItem<float>("speed");
        //Debug.Log("_lookit Speed is now(before):  " + curSpeed);
    }

    //void FixedUpdate()
    //{
    //    if (Time.fixedTime >= timeToGo)
    //    {
    //        try
    //        {
    //            //print(sp.ReadLine());
    //            x = sp.ReadLine();
    //            conversion = Convert.ToInt32(x, 16);
    //            //print(conversion);
    //            updatemovingspeed(conversion);
    //        }
    //        catch (System.Exception)
    //        {
    //        }

    //        timeToGo = Time.fixedTime + 0.5F;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        try
        {
            //print(sp.ReadLine());
            x = sp.ReadLine();
            conversion = float.Parse(x);
            //print(conversion);
            updateMovingSpeed(conversion);
        }
        catch (System.Exception)
        {
        }
    }

    void updateMovingSpeed(float updatedspeed)
    {
        RAIN.Core.AIRig rig = RAIN.Core.AIRig.FindRig(gameObject);
        rig.AI.WorkingMemory.SetItem("speed", updatedspeed*mph*200);
        float curSpeed2 = rig.AI.WorkingMemory.GetItem<float>("speed");
        //Debug.Log("_lookit Speed is now(after):  " + curSpeed2);
    }
}