using UnityEngine;
using System.Collections;

public class PCtoNPC : MonoBehaviour {
    bool onQuest;
	// Use this for initialization
	void Start () {
        onQuest = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}




    public void startQuest() {
        onQuest = true;
    }
    public void endQuest() {
        if (!onQuest)
            throw new System.Exception("Tried to end quest when not on one");
        onQuest = false;
    }

    public bool questing() {
        return onQuest;
    }
}
