using UnityEngine;
using System.Collections;

public class characters : MonoBehaviour {
    string firstName;
    int mySeed;//values to determine what this character's going to do
    int loyalty;//sets how likely they are to help you
    int fear;//what you have to beat to get help
    int fearMax;//if fear is > then trigger events
    int location;//current location on map
    int ability;//ability
    bool isKiller;//is this character the killer
    bool isDead;//is this character dead

	// Use this for initialization
	void Start () {
        loyalty = 0;
        fear = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //will this person help you
    public bool willHelp() {
        return (loyalty > fear);
    }


    //can reveal information they have on other characters or themselves
    public void useLoyalty(int num) {

    }


    
}
