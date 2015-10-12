using UnityEngine;
using System.Collections;

public class clock_movement : MonoBehaviour {
    // 5 minutes is 1 unit
    // 1 hour is 12 units
    public int startTime;
    public int currentTime;
    public GameObject hour_hand;
    public GameObject min_hand;
	// Use this for initialization
	void Start () {
        currentTime = startTime;
	}
	
	// Update is called once per frame
	void Update () {
    }


    public void addTime(int num) {
        currentTime += num;
        updateTime();
    }

    public int timeLeft(){
        return 144 - currentTime;
    }

    void updateTime() {
        min_hand.transform.eulerAngles = new Vector3(0, 0, -currentTime % 12 * 30);
        hour_hand.transform.eulerAngles = new Vector3(0, 0, -currentTime * 30/12);
    }
}
