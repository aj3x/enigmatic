using UnityEngine;
using System.Collections;

public class speech : MonoBehaviour {

    PlayerControl playerScript;
    game_scripts gameScripts;
    public string[] introLines;//only spoken when you first talk to character
    public string[] passiveLines;//
    public string[] scaredLines;
    public string[] helpfulLines;
    public string[] questLines;
    delegate void SpeechDelegate();
    SpeechDelegate talk;
    bool isTalking;
    int curLine;
    bool choosing;
    int sel;

    // Use this for initialization
    void Start () {
        talk = introduction;//NPC Starts at introduction
        isTalking = false;//Is not talking at first
        choosing = false;
        sel = 0;
        curLine = 0;
        playerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
        gameScripts = GameObject.Find("GameController").GetComponent<game_scripts>();
	}
	


    void Update() {
        if(isTalking) {
            if (Input.GetButtonDown("Action")) {
                talk();
            }
        }
    }
	


    /// <summary>
    /// Handles lines of string to display to console
    /// </summary>
    /// <param name="arr"></param>
    void talkTemplate(string []arr) {
        talkTemplate(arr, arr.Length);
    }
    void talkTemplate(string []arr,int length) {
        if (isTalking) {
            if (curLine < length) {
                gameScripts.showText(arr[curLine]);
                curLine++;
            } else {
                stopTalking();
            }
        } else {
            Debug.Log("Shouldn't get here");
        }
    }
    void talkRandLine(string[]arr) {
        if (isTalking) {
            curLine = Random.Range(0, arr.Length);
            gameScripts.showText(arr[curLine]);
            talk = stopTalking;
        } else {
            stopTalking();
        }
    }


    void introduction() {
        talkTemplate(introLines);
        if (!isTalking) {//after the introduction go to passive speech
            talk = passive;
        }
    }
    void passive() {
        //talkRandLine(passiveLines);
        optionList(passiveLines);
    }
    void scared() {
        talkRandLine(scaredLines);
    }
    void helpful() {
        talkTemplate(helpfulLines);
    }


    void questTalking(string name,string clue) {
        questLines = new string[4];
        questLines[0] = "I've got something for you to do.";
        questLines[1] = name + " has something I want you to find.";
        questLines[2] = clue + " is stashed somewhere in the castle";
        questLines[3] = "Come back with it and I'll make it worth your while.";
        talkTemplate(questLines);
    }

    /// <summary>
    /// Display dialog box
    /// Disable movement script
    /// </summary>
    void startTalking() {
        isTalking = true;
        playerScript.enabled = false;
    }


    /// <summary>
    /// Remove dialog box
    /// Enable movement script
    /// Set Line to 0
    /// </summary>
    void stopTalking() {
        isTalking = false;
        playerScript.enabled = true;
        gameScripts.closeText();
        curLine = 0;
        talk = passive;
    }


    void showOptions() {
        string[] arr;
        arr = passiveLines;
        optionList(arr);
    }

    void optionList(string[] arr) {
        gameScripts.showOptions(arr);

    }


    /// <summary>
    /// If the PC is looking at teh NPC chekc if the action button has been pressed
    /// If so continues along talk delegate
    /// </summary>
    /// <param name="coll"></param>
    void OnCollisionStay(Collision coll) {
        if (coll.collider.tag.Equals("Player") && Input.GetButtonDown("Action")) {
            //startTalking();
            //showOptions();
        }
    }



    
}
