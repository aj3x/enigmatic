using UnityEngine;
using System.Collections;

public class container : MonoBehaviour {
    int item;//index value of item
    game_scripts gameScripts;
    clue_list clueList;
	// Use this for initialization
	void Start () {
        item = 0;
        gameScripts = GameObject.Find("GameController").GetComponent<game_scripts>();
	    clueList = GameObject.Find("GameController").GetComponent<clue_list>();
    }
	
	public void setItem(int num) {
        item = num;
    }

    /// <summary>
    /// Displays contents of container in message dialog
    /// </summary>
    public void onSearch() {
        string temp;
        if (item != 0) {
            temp = clueList.item(item);
        } else {
            switch (Random.Range(0, 100)) {
                case 0: temp = "a gremlin! It doesn't seem too happy, best leave it alone."; break;
                case 1: temp = "an old picture of yourself. How did that get here."; break;
                case 2: temp = "(-_-;)"; break;
                case 3: temp = "Satan! Lil' scamp what's he doing here."; break;
                case 4: temp = "an audio tape. It's dated 4 days ago, no use in listening to it."; break;
                case 5: temp = "an uneaten hamburger! No sense letting it go to waste"; break;
                case 6: temp = "something I'd rather not explain."; break;
                case 7: temp = "$10,000,000! I'll just burn this, since it has no use."; break;
                case 8: temp = "some kind of murder plan. Makes no sense to me."; break;
                case 9: temp = "Old Man Jenkins' treasure chest! Best tell the boys later."; break;
                case 10: temp = "a tree! It seems pretty OP, I'd better send an angry letter to the developers."; break;
                case 11: temp = "a message! From OP, guess it never got delivered."; break;
                case 12: temp = "a message! It seems to put OP's sexual orientation into question."; break;
                case 13: if (gameScripts.cthulu) { temp = "a portal! You release another minion of Cthulu!"; gameScripts.cthulu = true; }
                        else temp = "Cthulu! You release him beginning an era of terror!"; break;
                default: temp = "nothing of interest!"; break;
            }
        }
        gameScripts.showText("Inside you find "+temp);
        item = 0;
        
    }


    
}
