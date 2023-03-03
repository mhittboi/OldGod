using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryDisplay : MonoBehaviour
{
    // read power amount
    public Power modifyPower;
    public Nav navRead;
    public Sprite battery0;
    public Sprite battery1;
    public Sprite battery2;
    public Sprite battery3;
    public Sprite battery4;
    public Sprite battery5;
    public Sprite tutorialbattery0;
    public Sprite tutorialbattery1;
    public Sprite tutorialbattery2;
    public Sprite tutorialbattery3;
    public Sprite tutorialbattery4;
    public Sprite tutorialbattery5;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = tutorialbattery0;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate battery fullness in a percentage
        float percentFull = modifyPower.power / modifyPower.powerMax;

        //use percentage to determine displayed ui battery sprite
        if (navRead.unlockMain == true)
        {
            if (percentFull >= 1f)
            {
                //Debug.Log("Full Sprite");
                GetComponent<Image>().sprite = battery5;
            }
            else if (percentFull >= 0.8f)
            {
                //Debug.Log("80+ Sprite");
                GetComponent<Image>().sprite = battery4;
            }
            else if (percentFull >= 0.6f)
            {
                //Debug.Log("60+ Sprite");
                GetComponent<Image>().sprite = battery3;
            }
            else if (percentFull >= 0.4f)
            {
                //Debug.Log("40+ Sprite");
                GetComponent<Image>().sprite = battery2;
            }
            else if (percentFull >= 0.2f)
            {
                //Debug.Log("20+ Sprite");
                GetComponent<Image>().sprite = battery1;
            }
            else
            {
                //Debug.Log("Empty");
                GetComponent<Image>().sprite = battery0;
            }
        }
        else
        {
            if (percentFull >= 1f)
            {
                //Debug.Log("Full Sprite");
                GetComponent<Image>().sprite = tutorialbattery5;
            }
            else if (percentFull >= 0.8f)
            {
                //Debug.Log("80+ Sprite");
                GetComponent<Image>().sprite = tutorialbattery4;
            }
            else if (percentFull >= 0.6f)
            {
                //Debug.Log("60+ Sprite");
                GetComponent<Image>().sprite = tutorialbattery3;
            }
            else if (percentFull >= 0.4f)
            {
                //Debug.Log("40+ Sprite");
                GetComponent<Image>().sprite = tutorialbattery2;
            }
            else if (percentFull >= 0.2f)
            {
                //Debug.Log("20+ Sprite");
                GetComponent<Image>().sprite = tutorialbattery1;
            }
            else
            {
                //Debug.Log("Empty");
                GetComponent<Image>().sprite = tutorialbattery0;
            }
        }
    }
}
