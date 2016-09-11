using UnityEngine;
using System.Collections;

public class mainCameraMovement : MonoBehaviour
{
    public float smooth = 1.5f;         // The relative speed at which the camera will catch up.
    private Vector3 newPos;             // The position the camera is trying to reach.
    private Vector3 standardPos;
    private Transform frontCamera;
    public Transform capsule;
    private int capsuleCount = 0;

    void Start()
    {
        newPos.x = 2949;
        newPos.y = 153;
        newPos.z = 5558;
    }
    void Update()
    {
        frontCamera = GameObject.FindWithTag("MainCamera").transform;
        //capsule = GameObject.FindWithTag("First Capsule").transform;
        newPos.z = newPos.z - 10;
        standardPos = frontCamera.position + newPos;
        frontCamera.position = newPos;
        /*if(frontCamera.position==capsule.position)
        {
            newPos.x = newPos.x - 1;
            standardPos = frontCamera.position + newPos;
            capsuleCount++;
        }*/
    }
    void onTriggerEnter(Collision col)
    {
        print("Collision detected with trigger object " + col.gameObject.name);
        if(col.gameObject.name=="Main Camera")
        {
            print("Collision detected with trigger object " + col.gameObject.name);
            frontCamera = GameObject.FindWithTag("MainCamera").transform;
            newPos.x = newPos.x - 1;
            standardPos = frontCamera.position + newPos;
            frontCamera.position = standardPos;
        }
    }
}