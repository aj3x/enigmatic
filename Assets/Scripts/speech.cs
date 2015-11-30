﻿using UnityEngine;
using System.Collections;

public class speech : MonoBehaviour {

    PlayerControl playerScript;
    game_scripts gameScripts;
    NPC_Calc aiGraph;
    public string[] introLines;//only spoken when you first talk to character
    public string[] passiveLines;//
    public string[] scaredLines;
    public string[] helpfulLines;
    public string[] questLines;

    public string[] questLineExplain;
    public string[] questLinesClue;
    public string[] questLinesClosing;
    delegate void SpeechDelegate();
    SpeechDelegate talk;
    bool isTalking;
    int curLine;


    // Use this for initialization
    void Start () {
        talk = keepTalking;//NPC Starts at introduction
        isTalking = false;//Is not talking at first
        curLine = 0;
        playerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
        gameScripts = GameObject.Find("GameController").GetComponent<game_scripts>();
        aiGraph = gameObject.GetComponent<NPC_Calc>();
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
    /// <summary>
    /// Reads one line from the script then closes when action is hit again
    /// </summary>
    /// <param name="arr">Array to be read</param>
    void talkRandLine(string[]arr) {
        if (isTalking) {
            curLine = Random.Range(0, arr.Length);
            gameScripts.showText(arr[curLine]);
            talk = stopTalking;
        } else {
            stopTalking();
        }
    }


    //For Delegate
    void helpful() {
        talkTemplate(helpfulLines);
    }
    void busySpeech() {
        if (Random.Range(0, 3) == 0) {
            string[] arr = {
                "I can see your busy with " + aiGraph.toPC.getQuestNPC() + ".",
                "Talk to me when you're not busy already.",
                "You can only help one person at a time.",
                "Sorry, the script says you can only help one person at a time."
            };
            talkRandLine(arr);
        } else {
            talkRandLine(passiveLines);
        }
    }


    void questStart() {
        if (name != "Butler") {//Butler can't give quest
            if (aiGraph.toPC.questing()) {//already on a quest
                talk = busySpeech;//
            } else {
                
            }
        } else {//butler goes to helpful instead of giving quests
            talk = helpful;
        }
    }
    public void quest() {
        //aiGraph.toPC.startQuest();
        aiGraph.startQuest(aiGraph.findIndex(name));
        questTalking(aiGraph.findName(Mathf.Abs(aiGraph.revealPerson(aiGraph.findIndex(name)))), " A CONVENIENT PLOT DEVICE");
        
    }

    /// <summary>
    /// Ends the quest you're currently on
    /// </summary>
    void endQuest() {
        aiGraph.toPC.setQuestNPC(null);
    }

    /// <summary>
    /// Makes generic quest speech
    /// </summary>
    /// <param name="name">Name of person to reveal</param>
    /// <param name="clue">Clue to look for</param>
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
    public void stopTalking() {
        isTalking = false;
        playerScript.enabled = true;
        gameScripts.closeText();
        aiGraph.toPC.setTalkNPC(null);
        curLine = 0;
        aiGraph.speech.goToRoot();
    }

    
    void keepTalking() {
        if (aiGraph.speech.isQuestion()) {

        } else {
            talkTemplate(aiGraph.speech.getLines());
            aiGraph.speech.goToNext();
        }
    }
    



    
}
