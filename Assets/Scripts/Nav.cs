using UnityEngine;
using UnityEngine.UI;

public class Nav : MonoBehaviour
{
    // initialise variables
    private float selectionX;
    private float selectionY;
    private string selectedMenu;
    //individual menu displays
    public GameObject PowerMenu;
    public Text PowerMenuText;
    public GameObject UpgradesMenu;
    public Text UpgradesMenuText;
    public GameObject Milestones;
    public Text MilestonesText;
    public GameObject Settings;
    public Text SettingsText;
    //shop unlocks
    public bool unlockMain;
    public bool unlockPower;
    public bool unlockMilestones;
    public bool unlockCamera;
    //power variables
    public Power modifyPower;
    //upgrade prices
    private float batteryCost;
    private float solarCost;

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



        //change display based on current location stored in co-ordinates
        switch (selectionX, selectionY)
        {
            case (0, 0):
                navText.text = "[UPGRADES]\n[POWER]\n[MILESTONES]\n[SETTINGS]";
                UpgradesMenuText.text = "UPGRADES\n--------\n> [FABRICATE] Battery | Currently own ?\n[FABRICATE] Solar Panel | Currently own ?\n[UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                if (Input.GetKeyDown("e"))
                {
                    modifyPower.batteryCount = modifyPower.batteryCount + 1;
                }
                // remove appropriate power amount
                break;
            case (0, 1):
                UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own ?\n> [FABRICATE] Solar Panel | Currently own ?\n[UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                if (Input.GetKeyDown("e"))
                {
                    modifyPower.solarCount = modifyPower.solarCount + 1;
                }
                // remove appropriate power amount
                break;
            case (0, 2):
                UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own ?\n[FABRICATE] Solar Panel | Currently own ?\n> [UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                if (Input.GetKeyDown("e"))
                {
                    unlockMilestones = true;
                }
                break;
            case (0, 3):
                UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own ?\n[FABRICATE] Solar Panel | Currently own ?\n[UNLOCK] Milestones\n> [UNLOCK] Power Details\n[UNLOCK] Camera";
                if (Input.GetKeyDown("e"))
                {
                    unlockPower = true;
                }
                break;
            case (0, 4):
                UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own ?\n[FABRICATE] Solar Panel | Currently own ?\n[UNLOCK] Milestones\n[UNLOCK] Power Details\n> [UNLOCK] Camera";
                if (Input.GetKeyDown("e"))
                {
                    unlockCamera = true;
                }
                break;
            case (1, 0):
                navText.text = "> [UPGRADES]\n[POWER]\n[MILESTONES]\n[SETTINGS]";
                selectedMenu = "Upgrades";
                UpgradesMenuText.text = "UPGRADES\n--------\n[FABRICATE] Battery | Currently own ?\n[FABRICATE] Solar Panel | Currently own ?\n[UNLOCK] Milestones\n[UNLOCK] Power Details\n[UNLOCK] Camera";
                PowerMenuText.text = "POWER\n--------\nYou are currently generating ??? power per second.\nDetailed Breakdown:\n\n> " + (modifyPower.powerRate - 0.1f) + " comes from Solar Panels\n> 0.1 comes from Σ♦˧∀∀×»≤";
                MilestonesText.text = "MILESTONES\n--------";
                SettingsText.text = "SETTINGS\n--------";
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

        //Debug.Log("selectionX = " + selectionX);
        //Debug.Log("selectionY = " + selectionY);
    }
}