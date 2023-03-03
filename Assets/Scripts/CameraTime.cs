using UnityEngine;
using UnityEngine.UI;

public class CameraTime : MonoBehaviour {

    // initialise variables
    private float currentTime;
    private float timerSeconds;
    private float timerMinutes;
    private float timerHours;
    public bool updateTimer = true;

    [SerializeField] Text timerText;

    void Start () {
        currentTime = 0;
    }

    void Update() {
        // update timer only if currently unlocked
        if (updateTimer == true) {
            timerCalculation ();
        }
    }

    void timerCalculation(){
        // update currentTime
        currentTime += Time.deltaTime;

        // convert currentTime to appropriate units for displaying
        timerSeconds = currentTime % 60;
        timerMinutes = currentTime / 60;
        timerHours = currentTime / 3600;
        
        //display text with appropriate rounding
        timerText.text = timerHours.ToString("00") + ":" + timerMinutes.ToString("00") + ":" + timerSeconds.ToString("00");
    }
}
