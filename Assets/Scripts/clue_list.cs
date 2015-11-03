using UnityEngine;
using System.Collections;

public class clue_list : MonoBehaviour {

    int numClues;//number of clues in teh game
    public GameObject[] hidingSpots;//links to gameobjects with searchable component
    int[] usedClues;//contains which clues the game has

	// Use this for initialization
	void Start () {
        usedClues = new int[numClues];
    }
	
	// Update is called once per frame
	void Update () {
	
	}











    /// <summary>
    /// Takes an integer and returns the appropriate item in string form
    /// </summary>
    /// <param name="num">Index number of the item</param>
    /// <returns></returns>
    public string item(int num) {
        switch (num) {
            case 1: return "a convenient plot device";
            case 2: return "the murder weapon";
            default: return "nothing";
        }
    }



    public clues itemClue(int num) {
        clues tempClue = new clues();
        switch (num) {
            case 1: tempClue.setClue("a convenient plot device", 1); break;
            case 2: tempClue.setClue("the murder weapon", 2); break;
            default: tempClue.setClue("nothing", 0); break;
        }
        return tempClue;
    }
}
