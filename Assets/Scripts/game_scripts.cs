using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class game_scripts : MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    //debugging variables
    public bool blolz;
    public int lolz;
    //standard variables
    int difficulty;
    int lives;
    clock_movement clockScript;
    GameObject textBlock;
    Text livesHUD;
	// Use this for initialization
	void Start () {
        //Find the Text object and close it
        textBlock = GameObject.Find("Text");
        closeText();
        //get scripts and such
        livesHUD = GameObject.Find("lifeText").GetComponent<Text>();
        clockScript = GameObject.Find("Clock").GetComponent<clock_movement>();

        //adjust variables based on difficulty





        updateHUD();
    }
	
	// Update is called once per frame
	void Update () {
        updateHUD();
	}

    //Text functions
    public void showText(string message) {
        textBlock.GetComponent<Text>().text = message;
        textBlock.SetActive(true);

    }

    public void closeText() {
        textBlock.SetActive(false);
    }



    //HUD refresher
    public void updateHUD() {
        livesHUD.text = "x" + lives;
        clockScript.SendMessage("updateTime");
    }




    public void loseLife() {
        if (lives > 0) {
            lives--;
            GameObject.Find("livesText").GetComponent<Text>().text = "x" + lives;
            //game partial reset
        } else {
            //gameOver
        }
    }
}
