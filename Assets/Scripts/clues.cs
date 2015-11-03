using UnityEngine;
using System.Collections;

public class clues : MonoBehaviour {
    bool isFindable;//only activate if player has required prerequisites
    int clueType;//
    string clueName;
    game_scripts gameScripts;

	// Use this for initialization
	void Start () {
        gameScripts = GameObject.Find("GameController").GetComponent<game_scripts>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void setClue(string name,int type) {
        clueName = name;
        clueType = type;
    }



    



}
