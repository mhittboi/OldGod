using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private bool audioOn;
    public CameraChanger cameraStatus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioOn && !cameraStatus.isCam)
        {
            GetComponent<AudioSource>().Play();
            audioOn = true;
        }
        if (cameraStatus.isCam)
        {
            GetComponent<AudioSource>().Stop();
            audioOn = false;
        }
    }
}
