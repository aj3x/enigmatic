using UnityEngine;
using System.Collections;

public class speech : MonoBehaviour {

    basic_move playerScript;
    public string[] introLines;//only spoken when you first talk to character
    public string[] passiveLines;//
    public string[] scaredLines;
    public string[] helpfulLines;
    public string[] questLines;
    delegate void SpeechDelegate();
    SpeechDelegate talk;
    bool isTalking;
    int curLine;

	// Use this for initialization
	void Start () {
        talk = introduction;//NPC Starts at introduction
        isTalking = false;//Is not talking at first
        curLine = 0;
        playerScript = GameObject.Find("Player").GetComponent<basic_move>();
	}
	
	


    /// <summary>
    /// Handles lines of string to display to console
    /// </summary>
    /// <param name="arr"></param>
    void talkTemplate(string []arr) {
        if (isTalking) {
            if(curLine < arr.Length) {
                curLine++;
            } else {
                stopTalking();
            }
        } else {
            startTalking();
        }
        
    }
    void introduction() {
        talkTemplate(introLines);
        if (!isTalking) {//after the introduction go to passive speech
            talk = passive;
        }
    }
    void passive() {
        talkTemplate(passiveLines);
    }
    void scared() {
        talkTemplate(scaredLines);
    }
    void helpful() {
        talkTemplate(helpfulLines);
    }


    public void questTalking(string name,string clue) {
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
    /// </summary>
    void stopTalking() {
        isTalking = false;
        playerScript.enabled = true;
        curLine = 0;
    }



    /// <summary>
    /// If the PC is looking at teh NPC chekc if the action button has been pressed
    /// If so continues along talk delegate
    /// </summary>
    /// <param name="coll"></param>
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Player") && Input.GetButtonDown("Action")) {
            talk();
        }
    }



    
}
