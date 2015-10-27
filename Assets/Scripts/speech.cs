using UnityEngine;
using System.Collections;

public class speech : MonoBehaviour {

    basic_move playerScript;
    public string[] introLines;//only spoken when you first talk to character
    public string[] passiveLines;//
    public string[] scaredLines;
    public string[] helpfulLines;
    delegate void Speech();
    Speech talk;
    bool isTalking;
    int curLine;

	// Use this for initialization
	void Start () {
        talk = introduction;
        isTalking = false;
        curLine = 0;
        playerScript = GameObject.Find("Player").GetComponent<basic_move>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
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

    void startTalking() {
        isTalking = true;
        playerScript.enabled = false;
    }

    void stopTalking() {
        isTalking = false;
        playerScript.enabled = true;
        curLine = 0;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Player") && Input.GetButtonDown("Action")) {
            talk();
        }
    }



    
}
