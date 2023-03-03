using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPOV : MonoBehaviour {

     //Rotation Sensitivity
     public float RotationSensitivity = 35.0f;
     public float minAngle = -45.0f;
     public float maxAngle = 45.0f;

    //camera
    public GameObject camera3D;

    //Rotation Value
    float yRotate = 0.0f;
    float xRotate = 0.0f;
     
     // Update is called once per frame
     public void Update ()
     {
        //Rotate Y view
        yRotate -= Input.GetAxis ("Vertical") * RotationSensitivity * Time.deltaTime;
        yRotate = Mathf.Clamp (yRotate, minAngle, maxAngle);

        //Rotate X view
        xRotate += Input.GetAxis ("Horizontal") * RotationSensitivity * Time.deltaTime;
        xRotate = Mathf.Clamp (xRotate, minAngle, maxAngle);

        Debug.Log("yRotate = " + yRotate);
        Debug.Log("xRotate = " + xRotate);

        //final update
        camera3D.transform.rotation = Quaternion.Euler(yRotate, xRotate, 0.0f);
    }
}