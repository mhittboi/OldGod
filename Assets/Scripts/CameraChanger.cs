using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraChanger : MonoBehaviour
{
    //initialise variables
    public GameObject camera2D;
    public GameObject camera3D;
    public bool isCam = true;

    //camera check
    public Nav cameraCheck;

    void Start()
    {
        camera3D.SetActive(false);
        camera2D.SetActive(true);
    }

    void Update()
    {
        if (cameraCheck.unlockCamera)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 3"))
            {
                if (isCam == true)
                {
                    Debug.Log("2D Camera");
                    camera3D.SetActive(true);
                    camera2D.SetActive(false);
                    isCam = false;
                }
                else
                {
                    Debug.Log("3D Camera");
                    camera2D.SetActive(true);
                    camera3D.SetActive(false);
                    isCam = true;
                }

            }
        }
    }
}