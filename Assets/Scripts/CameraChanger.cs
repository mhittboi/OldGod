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
        if (isCam == true)
        {
            Debug.Log("2D Cam");
        }
        else
        {
            Debug.Log("3D Cam");
        }

        if (isCam == true)
        {
            if (cameraCheck.unlockCamera)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    isCam = false;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isCam = true;
            }
        }
    }
}