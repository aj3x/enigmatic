using UnityEngine;
using System.Collections;

public class container : MonoBehaviour {
    int item;//index value of item
    game_scripts gameScripts;
	// Use this for initialization
	void Start () {
	    gameScripts = GameObject.Find("GameController").GetComponent<game_scripts>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Displays contents of container in message dialog
    /// </summary>
    public void onSearch() {
        gameScripts.showText("Inside you find "+gameScripts.item(item)+"!");
    }



    public void onTake() {
        item = 0;

    }
}
