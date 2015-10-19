using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Class controls things such as difficulty and sound options.
/// </summary>
public class meta_script : MonoBehaviour {
    //keep values on restart
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    int difficulty;
    double seed;
	void Start () {
        difficulty = -1;//difficulty has not been set yet
	}
	
	// Update is called once per frame
	void Update () {
	}



    











    



    void setDifficulty(int num) {
        difficulty = num;
    }

    public int getDifficulty() {
        return difficulty;
    }


    void randomSeed() {
        
    }

    void setSeed() {
        //if(GameObject.Find)
        //if(GameObject.Find("InputField").GetComponent<InputField>().text) {
        //    seed = randomSeed;
        //}
        //if (num < 0 || num > 9999999999) {
            
        //}
    }


    public void StartGame() {
        if (difficulty < 0) {
            GameObject.Find("Title").GetComponent<Text>().color = new Color(255, 0, 0);
        } else {
            setSeed();
            Application.LoadLevel("UI");
        }
    }
}
