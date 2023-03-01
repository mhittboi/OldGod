using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    // initialise variables
    private float power = 0f;
    public float powerRate;
    private float powerMax = 100f;
    public int batteryCount = 1;
    public float batteryCapacity = 100f;
    public int solarCount = 0;
    public float solarRate = 3f;
    public float interval = 0.1f; // frequency at which powerRate is added to power, in seconds.
    public Text powerDisplayText;
    public float powerFull;

    void Start()
    {
        powerDisplayText.text = "0 / 100";
        InvokeRepeating("PowerChange", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        powerDisplayText.text = power + " / " + powerMax;
        //Debug.Log("Power:" + power + "| Power Rate:" + powerRate);

        //powerRate calculation
        powerRate = (solarCount * solarRate) + 0.1f;
        powerMax = (batteryCount * batteryCapacity);

        //powerFull should be updated every update to be accurate
        powerFull = Mathf.CeilToInt((powerMax - power) / powerRate);

        //calculate minutes and seconds
        int minutes = Mathf.FloorToInt(powerFull / 60);
        int seconds = Mathf.FloorToInt(powerFull % 60);

        //make it a string yayyyyy :3
        string timeString = string.Format("{0}:{1:00}", minutes, seconds);
        Debug.Log("Time until full power: " + timeString);
    }

    void PowerChange()
    {
        if (power < powerMax){
            power = power + powerRate;
            power = Mathf.Min(power, powerMax);
        }
    }
}
