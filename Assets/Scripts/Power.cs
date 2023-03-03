using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    // initialise variables
    public float power = 0f;
    public float powerRate;
    private float powerMax = 100f;
    public int batteryCount = 1;
    public float batteryCapacity = 100f;
    public int solarCount = 0;
    public float solarRate = 0.3f;
    public float interval = 0.1f; // frequency at which powerRate is added to power, in seconds.
    public Text powerDisplayText;
    public float powerFull;

    // recieve prices of upgrades from nav script
    public Nav navPrices;

    //variables for changing battery fullness sprite
    //idk fix it bb!

    void Start()
    {
        powerDisplayText.text = "0 / 100";
        InvokeRepeating("PowerChange", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        //calculate minutes and seconds for power information display
        int minutes = Mathf.FloorToInt(powerFull / 60);
        int seconds = Mathf.FloorToInt(powerFull % 60);
        string timeString = string.Format("{0}:{1:00}", minutes, seconds);

        switch (navPrices.selectionX, navPrices.selectionY)
        {
            case (0, 0):
                if (navPrices.selectedMenu == "Upgrades")
                {
                    powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n - " + navPrices.newbatteryCost + " Power\n" + timeString + " until full";
                }
                else
                {
                    powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n[UNLOCKED]\n" + timeString + " until full";
                }
                break;
            case (0, 1):
                if (navPrices.selectedMenu == "Upgrades")
                {
                    powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n - " + navPrices.newsolarCost + " Power\n" + timeString + " until full";
                }
                else
                {
                    powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n[UNLOCKED]\n" + timeString + " until full";
                }
                break;
            case (0, 2):
                if (navPrices.selectedMenu == "Upgrades")
                {
                    if (!navPrices.unlockMain)
                    {
                        powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n - " + navPrices.mainCost + " Power\n" + timeString + " until full";
                    }
                    else
                    {
                        if (!navPrices.unlockMilestones)
                        {
                            powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n - " + navPrices.milestonesCost + " Power\n" + timeString + " until full";
                        }
                        else
                        {
                            powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n[UNLOCKED]\n" + timeString + " until full";
                        }
                    }
                }
                else
                {
                    powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n[UNLOCKED]\n" + timeString + " until full";
                }
                break;
            case (0, 3):
                if (navPrices.selectedMenu == "Upgrades")
                {
                    if (!navPrices.unlockMain)
                    {
                        powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n\n" + timeString + " until full";
                    }
                    else
                    {
                        if (!navPrices.unlockPower)
                        {
                            powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n - " + navPrices.powerCost + " Power\n" + timeString + " until full";
                        }
                        else
                        {
                            powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n[UNLOCKED]\n" + timeString + " until full";
                        }
                    }
                }
                else
                {
                    powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n[UNLOCKED]\n" + timeString + " until full";
                }
                break;
            case (0, 4):
                if (navPrices.selectedMenu == "Upgrades")
                {
                    if (!navPrices.unlockMain)
                    {
                        powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n\n" + timeString + " until full";
                    }
                    else
                    {
                        if (!navPrices.unlockCamera)
                        {
                            powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n - " + navPrices.cameraCost + " Power\n" + timeString + " until full";
                        }
                        else
                        {
                            powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n[UNLOCKED]\n" + timeString + " until full";
                        }
                    }
                }
                else
                {
                    powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n[UNLOCKED]\n" + timeString + " until full";
                }
                break;
            default:
                powerDisplayText.text = Mathf.Round(power * 10f) / 10f + " / " + powerMax + "\n\n" + timeString + " until full";
                break;
        }
        

        //powerRate calculation
        powerRate = (solarCount * solarRate) + 0.1f;
        powerMax = (batteryCount * batteryCapacity);

        //powerFull should be updated every update to be accurate
        powerFull = Mathf.CeilToInt((powerMax - power) / powerRate);

        //calculate battery fullness in a percentage
        float percentFull = power / powerMax;

        //use percentage to determine displayed ui battery sprite
        if (percentFull >= 1f)
        {
            Debug.Log("Full Sprite");
        }
        else if (percentFull >= 0.8f)
        {
            Debug.Log("80+ Sprite");
        }
        else if (percentFull >= 0.6f)
        {
            Debug.Log("60+ Sprite");
        }
        else if (percentFull >= 0.4f)
        {
            Debug.Log("40+ Sprite");
        }
        else if (percentFull >= 0.2f)
        {
            Debug.Log("20+ Sprite");
        }
        else
        {
            Debug.Log("Empty");
        }
    }

    void PowerChange()
    {
        if (power < powerMax){
            power = power + powerRate;
            power = Mathf.Min(power, powerMax);
        }
    }
}
