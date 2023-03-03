using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Nav : MonoBehaviour
{
    // initialise variables
    public float selectionX;
    public float selectionY;
    public string selectedMenu;
    public bool visualEffects = true;

    //individual menu displays
    public GameObject PowerMenu;
    public Text PowerMenuText;
    public GameObject UpgradesMenu;
    public Text UpgradesMenuText;
    public GameObject Milestones;
    public Text MilestonesText;
    public GameObject Settings;
    public Text SettingsText;
    public Text powerdisplayText;

    //milestones
    private string powerMilestone = "○○○";
    private string batteryMilestone = "○○○";

    //shop unlocks
    public bool unlockMain;
    public bool unlockPower;
    public bool unlockMilestones;
    public bool unlockCamera;

    //power variables
    public Power modifyPower;

    //upgrade prices
    public float newbatteryCost;
    public float newsolarCost;
    public float growthrate = 0.25f; //adjustable for the rate at which upgrade prices increase
    public float batteryCost = 10f;
    public float solarCost = 2f;
    public float milestonesCost = 50f;
    public float powerCost = 100f;
    public float cameraCost = 200f;
    public float mainCost = 35f;

    //navigation animations
    public Image mainBG;
    public Image overlay1;
    public Image overlay2;
    public Image pixelation;
    public Image scanlines;

    [SerializeField] Text navText; 

    void Start()
    {
        selectionX = 0;
        selectionY = 0;
        selectedMenu = "Upgrades";
        UpgradesMenu.SetActive(true);
        PowerMenu.SetActive(false);
        Milestones.SetActive(false);
        Settings.SetActive(false);
        unlockMain = false;
        unlockPower = false;
        unlockMilestones = false;
        unlockCamera = false;
        newbatteryCost = batteryCost;
        newsolarCost = solarCost;
}

    void Update()
    {
        //if right input pressed set selectionX to right column
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectionX = 1;
            selectionY = 0; //put selectionY back to the top now a new tab has been selected
        }
        //if left input pressed set selectionX to left column
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectionX = 0;
            selectionY = 0; //put selectionY back to the top now a new tab has been selected
        }

        //if up input pressed set selectionY to selectionY-1
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectionY = selectionY -1;
        }
        //if down input pressed set selectionY to selectionY+1
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectionY = selectionY + 1;
        }

        //calculate minutes and seconds for power information display
        int minutes = Mathf.FloorToInt(modifyPower.powerFull / 60);
        int seconds = Mathf.FloorToInt(modifyPower.powerFull % 60);

        //make it a string yayyyyy :3
        string timeString = string.Format("{0}:{1:00}", minutes, seconds);
        //Debug.Log("Time until full power: " + timeString);

        // check if player is in tutorial mode or not
        if (unlockMain) //player is NOT in tutorial
        {
            //change display based on current location stored in co-ordinates
            switch (selectionX, selectionY)
            {
                case (0, 0):
                    //if player is out of tutorial
                    navText.text = "[UPGRADES]\n[POWER]\n[MILESTONES]\n[SETTINGS]";
                    switch (selectedMenu)
                    {
                        case ("Upgrades"):
                            UpgradesMenuText.text = "UPGRADES\n--------\n> [FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n[UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                            //if player has enough power
                            if (newbatteryCost < modifyPower.power)
                            {
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    modifyPower.batteryCount = modifyPower.batteryCount + 1;
                                    modifyPower.power = modifyPower.power - newbatteryCost;
                                    newbatteryCost = Mathf.Round((batteryCost * Mathf.Pow(1 + growthrate, modifyPower.batteryCount)) * 10) / 10f;
                                }
                            }
                            break;
                        case ("Power"):
                            break;
                        case ("Milestones"):
                            MilestonesText.text = "MILESTONES\n--------\n> [IMPROVE POWER GENERATION] " + powerMilestone + "\nReach 8/20/32 Power/Second\n\n[IMPROVE POWER CAPACITY] " + batteryMilestone + "\nObtain 5/15/25 Batteries";
                            break;
                        case ("Settings"):
                            if (visualEffects)
                            {
                                SettingsText.text = "SETTINGS\n--------\n> Toggle Overlays [ENABLED]";
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    visualEffects = false;
                                    pixelation.color = new Color(pixelation.color.r, pixelation.color.g, pixelation.color.b, 0f);
                                    scanlines.color = new Color(scanlines.color.r, scanlines.color.g, scanlines.color.b, 0f);
                                }
                            }
                            else
                            {
                                SettingsText.text = "SETTINGS\n--------\n> Toggle Overlays [DISABLED]";
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    visualEffects = true;
                                    pixelation.color = new Color(pixelation.color.r, pixelation.color.g, pixelation.color.b, 0.004f);
                                    scanlines.color = new Color(scanlines.color.r, scanlines.color.g, scanlines.color.b, 0.004f);
                                }
                            }
                            break;
                    }
                    break;
                case (0, 1):
                    navText.text = "[UPGRADES]\n[POWER]\n[MILESTONES]\n[SETTINGS]";
                    switch (selectedMenu)
                    {
                        case ("Upgrades"):
                            UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n> [FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n[UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                            if (newsolarCost < modifyPower.power)
                            {
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    modifyPower.solarCount = modifyPower.solarCount + 1;
                                    modifyPower.power = modifyPower.power - newsolarCost;
                                    newsolarCost = Mathf.Round((solarCost * Mathf.Pow(1 + growthrate, modifyPower.solarCount)) * 10) / 10f;
                                }
                            }
                            break;
                        case ("Power"):
                            break;
                        case ("Milestones"):
                            MilestonesText.text = "MILESTONES\n--------\n[IMPROVE POWER GENERATION] " + powerMilestone + "\nReach 8/20/32 Power/Second\n\n> [IMPROVE POWER CAPACITY] " + batteryMilestone + "\nObtain 5/15/25 Batteries";
                            break;
                        case ("Settings"):
                            if (visualEffects)
                            {
                                SettingsText.text = "SETTINGS\n--------\n> Toggle Overlays [ENABLED]";
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    visualEffects = false;
                                    pixelation.color = new Color(pixelation.color.r, pixelation.color.g, pixelation.color.b, 0f);
                                    scanlines.color = new Color(scanlines.color.r, scanlines.color.g, scanlines.color.b, 0f);
                                }
                            }
                            else
                            {
                                SettingsText.text = "SETTINGS\n--------\n> Toggle Overlays [DISABLED]";
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    visualEffects = true;
                                    pixelation.color = new Color(pixelation.color.r, pixelation.color.g, pixelation.color.b, 0.004f);
                                    scanlines.color = new Color(scanlines.color.r, scanlines.color.g, scanlines.color.b, 0.004f);
                                }
                            }
                            break;
                    }
                    break;
                    break;
                case (0, 2):
                    UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n> [UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                    if (milestonesCost < modifyPower.power && !unlockMilestones)
                    {
                        if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                        {
                            unlockMilestones = true;
                            modifyPower.power = modifyPower.power - milestonesCost;
                        }
                    }
                    break;
                case (0, 3):
                    UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n[UNLOCK] Milestones\n> [UNLOCK] Power Details\n[UNLOCK] Camera";
                    if (powerCost < modifyPower.power && !unlockPower)
                    {
                        if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                        {
                            unlockPower = true;
                            modifyPower.power = modifyPower.power - powerCost;
                        }
                    }
                    break;
                case (0, 4):
                    UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n[UNLOCK] Milestones\n[UNLOCK] Power Details\n> [UNLOCK] Camera";
                    if (cameraCost < modifyPower.power && !unlockCamera)
                    {
                        if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                        {
                            unlockCamera = true;
                            modifyPower.power = modifyPower.power - cameraCost;
                        }
                    }
                    break;
                case (1, 0):
                    navText.text = "> [UPGRADES]\n[POWER]\n[MILESTONES]\n[SETTINGS]";
                    selectedMenu = "Upgrades";
                    UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n[UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                    PowerMenuText.text = "POWER\n--------\nYou are currently generating " + modifyPower.powerRate + " power per second.\n\nDetailed Breakdown:\n\n> " + (modifyPower.powerRate - 0.1f) + " comes from Solar Panels\n> 0.1 comes from Σ♦˧∀∀×»≤";
                    MilestonesText.text = "MILESTONES\n--------\n[IMPROVE POWER GENERATION] " + powerMilestone + "\nReach 8/20/32 Power/Second\n\n[IMPROVE POWER CAPACITY] " + batteryMilestone + "\nObtain 5/15/25 Batteries";
                    SettingsText.text = "SETTINGS\n--------\nToggle Overlay [ENABLED]";
                    UpgradesMenu.SetActive(true);
                    PowerMenu.SetActive(false);
                    Milestones.SetActive(false);
                    Settings.SetActive(false);
                    break;
                case (1, 1):
                    if (unlockPower == false)
                    {
                        PowerMenuText.text = "[LOCKED]";
                    }
                    navText.text = "[UPGRADES]\n> [POWER]\n[MILESTONES]\n[SETTINGS]";
                    selectedMenu = "Power";
                    UpgradesMenu.SetActive(false);
                    PowerMenu.SetActive(true);
                    Milestones.SetActive(false);
                    Settings.SetActive(false);
                    break;
                case (1, 2):
                    if (unlockMilestones == false)
                    {
                        MilestonesText.text = "[LOCKED]";
                    }
                    navText.text = "[UPGRADES]\n[POWER]\n> [MILESTONES]\n[SETTINGS]";
                    selectedMenu = "Milestones";
                    UpgradesMenu.SetActive(false);
                    PowerMenu.SetActive(false);
                    Milestones.SetActive(true);
                    Settings.SetActive(false);
                    break;
                case (1, 3):
                    navText.text = "[UPGRADES]\n[POWER]\n[MILESTONES]\n> [SETTINGS]";
                    selectedMenu = "Settings";
                    UpgradesMenu.SetActive(false);
                    PowerMenu.SetActive(false);
                    Milestones.SetActive(false);
                    Settings.SetActive(true);
                    break;
            }
        }
        else //player is in tutorial
            //change display based on current location stored in co-ordinates
            switch (selectionX, selectionY)
            {
                case (0, 0):
                    //if player is out of tutorial
                    navText.text = "[UPGRADES]\n[SETTINGS]";
                    switch (selectedMenu)
                    {
                        case ("Upgrades"):
                            UpgradesMenuText.text = "UPGRADES\n--------\n> [FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n[LEAVE LOW POWER MODE]";
                            //if player has enough power
                            if (newbatteryCost < modifyPower.power)
                            {
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    modifyPower.batteryCount = modifyPower.batteryCount + 1;
                                    modifyPower.power = modifyPower.power - newbatteryCost;
                                    newbatteryCost = Mathf.Round((batteryCost * Mathf.Pow(1 + growthrate, modifyPower.batteryCount)) * 10) / 10f;
                                }
                            }
                            break;
                        case ("Settings"):
                            if (visualEffects)
                            {
                                SettingsText.text = "SETTINGS\n--------\n> Toggle Overlays [ENABLED]";
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    visualEffects = false;
                                    pixelation.color = new Color(pixelation.color.r, pixelation.color.g, pixelation.color.b, 0f);
                                    scanlines.color = new Color(scanlines.color.r, scanlines.color.g, scanlines.color.b, 0f);
                                }
                            }
                            else
                            {
                                SettingsText.text = "SETTINGS\n--------\n> Toggle Overlays [DISABLED]";
                                if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                                {
                                    visualEffects = true;
                                    pixelation.color = new Color(pixelation.color.r, pixelation.color.g, pixelation.color.b, 0.004f);
                                    scanlines.color = new Color(scanlines.color.r, scanlines.color.g, scanlines.color.b, 0.004f);
                                }
                            }
                            break;
                    }
                    break;
                case (0, 1):
                    UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n> [FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n[LEAVE LOW POWER MODE]";
                    //if player has enough power
                    if (newsolarCost < modifyPower.power)
                    {
                        if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                        {
                            modifyPower.solarCount = modifyPower.solarCount + 1;
                            modifyPower.power = modifyPower.power - newsolarCost;
                            newsolarCost = Mathf.Round((solarCost * Mathf.Pow(1 + growthrate, modifyPower.solarCount)) * 10) / 10f;
                        }
                    }
                    break;
                case (0, 2):
                    UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n> [LEAVE LOW POWER MODE]";
                    if (mainCost < modifyPower.power && !unlockMain)
                    {
                        if (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 0"))
                        {
                            //update variables
                            modifyPower.power = modifyPower.power - mainCost;
                            navText.text = "[UPGRADES]\n[POWER]\n[MILESTONES]\n[SETTINGS]";
                            UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n> [UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                            unlockMain = true;

                            //visual effects
                            Color color = mainBG.color;
                            color.a = 1f;
                            mainBG.color = color;

                            Color overlayColor = new Color32(0x1F, 0x1F, 0x1F, 0xFF);
                            overlay1.color = overlayColor;

                            overlayColor.a = 0.8f;
                            overlay2.color = overlayColor;

                            navText.color = new Color(1, 1f, 1f); // sets the color of navText to white
                            UpgradesMenuText.color = new Color(1f, 1f, 1f); // sets the color of upgradesMenuText to white
                            SettingsText.color = new Color(1f, 1f, 1f); // sets the color of settingsText to white
                            MilestonesText.color = new Color(1f, 1f, 1f); // sets the color of MilestonesText to white
                            PowerMenuText.color = new Color(1f, 1f, 1f); // sets the color of PowerMenuText to white
                            powerdisplayText.color = new Color(1, 1f, 1f); // sets the color of navText to white
                        }
                    }
                    break;
                case (1, 0):
                    navText.text = "> [UPGRADES]\n[SETTINGS]";
                    selectedMenu = "Upgrades";
                    UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own " + modifyPower.batteryCount + "\n[FABRICATE] Solar Panel | Currently own " + modifyPower.solarCount + "\n[LEAVE LOW POWER MODE]";
                    SettingsText.text = "SETTINGS\n--------\nToggle Overlay [ENABLED]";
                    UpgradesMenu.SetActive(true);
                    Settings.SetActive(false);
                    break;
                case (1, 1):
                    navText.text = "[UPGRADES]\n> [SETTINGS]";
                    selectedMenu = "Settings";
                    UpgradesMenu.SetActive(false);
                    Settings.SetActive(true);
                    break;
            }

        // all of the milestones you can reach
        // im so sorry if you're a living person reading this. i dont mean to be like this :)
        if (modifyPower.batteryCount >= 5 && batteryMilestone == "○○○")
        {
            batteryMilestone = "●○○";
        }
        if (modifyPower.batteryCount >= 15 && batteryMilestone == "●○○")
        {
            batteryMilestone = "●●○";
        }
        if (modifyPower.batteryCount >= 25 && batteryMilestone == "●●○")
        {
            batteryMilestone = "●●●";
        }

        if (modifyPower.solarCount >= 8 && powerMilestone == "○○○")
        {
            powerMilestone = "●○○";
        }
        if (modifyPower.solarCount >= 20 && powerMilestone == "●○○")
        {
            powerMilestone = "●●○";
        }
        if (modifyPower.solarCount >= 32 && powerMilestone == "●●○")
        {
            powerMilestone = "●●●";
        }

    }
}