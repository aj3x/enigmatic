using UnityEngine;
using System.Collections;

/// <summary>
/// Class controls things such as difficulty and sound options.
/// </summary>
public class meta_script : MonoBehaviour {
    //keep values on restart
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    int difficulty;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    
	}



    
















    public void setDifficulty(int num) {
        difficulty = num;
    }

    public int getDifficulty() {
        return difficulty;
    }


    void randomSeed() {
        
    }

    public void setSeed(int num) {
        //if (num < 0 || num > 9999999999) {
            
        //}
    }


    public void StartGame() {

        Application.LoadLevel("UI");
    }
}
