using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PCtoNPC : MonoBehaviour {
    bool onQuest;
    bool questDone;
    string questNPC;
    string talkNPC;
    //Dropdown sel;
    
	// Use this for initialization
	void Start () {
        onQuest = false;
        questDone = false;
        //sel = GameObject.Find("Dropdown").GetComponent<Dropdown>();
	}
	
	public string getQuestNPC() {
        return questNPC;
    }
    public string getTalkNPC() {
        return talkNPC;
    }
    public void setTalkNPC(string name) {
        talkNPC = name;
    }
    public void setQuestNPC(string name) {
        questNPC = name;
    }
    public bool isQuestDone() {
        return questDone;
    }
    /*
    public void selSet(string []arr) {
        sel.options.Clear();
        for(int i=0;i< arr.Length; i++) {
            sel.options.Insert(i, new Dropdown.OptionData(arr[i]));
        }
    }*/


    public void startQuest() {
        onQuest = true;
        questDone = false;
        GameObject.Find(getQuestNPC()).GetComponent<speech>().quest();
        GameObject.Find("Buttons").SetActive(false);
    }
    public void endQuest() {
        if (!onQuest)
            throw new System.Exception("Tried to end quest when not on one");
        onQuest = false;
        questDone = false;
        questNPC = null;
        //send message to npc quest completed
    }

    public bool questing() {
        return onQuest;
    }



    void OnTriggerStay(Collider coll) {
        if (Input.GetButtonDown("Action")) {
            if (coll.tag.Equals("Talkable")) {
                if (!questing()) {
                    talkNPC = coll.name;
                    coll.SendMessage("startTalking");
                } else {
                    if (questNPC == coll.name && questDone) {
                        coll.SendMessage("endQuest");
                    } else if (this.name == coll.name) {
                        //do nothing
                    } else {
                        coll.SendMessage("busySpeech");
                    }
                }
            } else if (coll.tag.Equals("Searchable")) {
                coll.SendMessage("onSearch");
            }
        }
    }
}
