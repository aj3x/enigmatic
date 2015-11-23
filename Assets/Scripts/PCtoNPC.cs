using UnityEngine;
using System.Collections;

public class PCtoNPC : MonoBehaviour {
    bool onQuest;
    string nameNPC;
	// Use this for initialization
	void Start () {
        onQuest = false;
	}
	
	public string getName() {
        return nameNPC;
    }

    public void firstOption() {
        
    }

    public void secondOption() {

    }


    public void startQuest(string name) {
        nameNPC = name;
        onQuest = true;
    }
    public void endQuest() {
        if (!onQuest)
            throw new System.Exception("Tried to end quest when not on one");
        onQuest = false;
        nameNPC = null;
        //send message to npc quest completed
    }

    public bool questing() {
        return onQuest;
    }
}
