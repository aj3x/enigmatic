using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/// <summary>
/// Controls important game variables such as number of lives
/// </summary>
public class game_scripts : MonoBehaviour {
    //keeps values on restart/level load
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }


    //standard variables
    public bool cthulu = false;
    int lives;
    int startTime;
    clock_movement clockScript;
    GameObject textBlock;
    GameObject textWall;
    GameObject buttons;
    public GameObject dropdown;
    Text livesHUD;







	// Use this for initialization
	void Start () {
        //Find the Text object and close it
        textBlock = GameObject.Find("Text");
        textWall = GameObject.Find("TextBack");
        buttons = GameObject.Find("Buttons");
        dropdown = GameObject.Find("Dropdown");
        closeText();

        //get difficulty
        int diff = GameObject.Find("MetaController").GetComponent<meta_script>().getDifficulty();
        //adjust variables based on difficulty
        lives = (int)(1.5*diff);
        startTime = 12 * 3 + (diff * 12);

        //get Scripts
        clockScript = GameObject.Find("Clock").GetComponent<clock_movement>();
        clockScript.enabled = true;
        livesHUD = GameObject.Find("lifeText").GetComponent<Text>();
        

        clockScript.currentTime = startTime;


        
        updateHUD();
    }
	
	// Update is called once per frame
	void Update () {
        /*if (cthulu) {
            GameObject.Find("Daylight").SetActive(false);
        }*/
	}

    //Text functions
    /// <summary>
    /// Shows the messaging system
    /// Changes text to display system message
    /// </summary>
    /// <param name="message">String of message to be sent</param>
    public void showText(string message) {
        textBlock.GetComponent<Text>().text = message;
        textBlock.SetActive(true);
        textWall.SetActive(true);
        
    }

    /// <summary>
    /// Closes the messaging system
    /// </summary>
    public void closeText() {
        textBlock.SetActive(false);
        textWall.SetActive(false);
        buttons.SetActive(false);
        dropdown.SetActive(false);
    }

    public void showOptions(string[] items) {
        dropdown.SetActive(true);
        buttons.SetActive(true);
        dropdown.GetComponent<Dropdown>().options.Clear();

        showText(items[0]);
        for (int i = 1; i < items.Length; i++) {
            dropdown.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(items[i]));
            closeOptions();
        }
    }

    public void closeOptions() {
        dropdown.SetActive(false);
        buttons.SetActive(false);
    }


    



    //HUD refresher
    public void updateHUD() {
        livesHUD.text = "x" + lives;
        clockScript.SendMessage("updateTime");
    }



    public int getStartTime() {
        return startTime;
    }

    /// <summary>
    /// Loses a life and resets game
    /// </summary>
    public void loseLife() {
        if (lives > 0) {
            lives--;
            livesHUD.text = "x" + lives;
            //game partial reset
        } else {
            //gameOver
        }
    }
}
