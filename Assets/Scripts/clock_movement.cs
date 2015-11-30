using UnityEngine;
using System.Collections;

public class clock_movement : MonoBehaviour {
    // 5 minutes is 1 unit
    // 1 hour is 12 units
    public int currentTime;
    public GameObject hour_hand;
    public GameObject min_hand;
	// Use this for initialization
	void Start () {
        //get objects and scripts
        currentTime = GameObject.Find("GameController").GetComponent<game_scripts>().getStartTime();


        updateTime();
    }
	
	// Update is called once per frame
	void Update () {

    }


    /// <summary>
    /// Adds time from action
    /// </summary>
    /// <param name="num">Number of units to add to time</param>
    public void addTime(int num) {
        currentTime += num;
        updateTime();
    }

    /// <summary>
    /// Returns how many units of time player has left until midnight
    /// </summary>
    /// <returns>number of units left till midnight</returns>
    public int timeLeft(){
        return 144 - currentTime;
    }


    /// <summary>
    /// Rotate clock hands based on current time
    /// </summary>
    void updateTime() {
        min_hand.transform.eulerAngles = new Vector3(0, 0, -currentTime % 12 * 30);
        hour_hand.transform.eulerAngles = new Vector3(0, 0, -currentTime * 30/12);
    }
}
