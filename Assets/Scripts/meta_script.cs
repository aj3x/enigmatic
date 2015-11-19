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
    private double seed;
	void Start () {
        difficulty = -1;//difficulty has not been set yet
	}
	
	

    public double GetSeed() {
        return seed;
    }



    











    


    /// <summary>
    /// Sets the difficulty to paramater
    /// </summary>
    /// <param name="num">Difficulty to set to</param>
    void setDifficulty(int num) {
        difficulty = num;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns>Current difficulty</returns>
    public int getDifficulty() {
        return difficulty;
    }


    void randomSeed() {
        seed = (double)(Random.Range(0, 10000000000));
    }

    void setSeed() {
        string temp = GameObject.Find("InputField").GetComponent<InputField>().text;
        if (temp != "") {
            double num = double.Parse(temp);
            if (num != 0 && //If User input a number and
                (num > 0 || num < 9999999999)) {//number is valid entry
                seed = num;
            } else {
                randomSeed();
                Debug.Log("Invalid Entry; Took random seed instead");
            }
        } else {
            randomSeed();
        }

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
