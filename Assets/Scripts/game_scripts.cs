using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class game_scripts : MonoBehaviour {
    public bool blolz;
    public int lolz;
    int lives;
    public GameObject textBlock;
	// Use this for initialization
	void Start () {
        textBlock = GameObject.Find("Text");
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void showText(string message) {
        textBlock.GetComponent<Text>().text = message;
        textBlock.SetActive(true);

    }

    public void closeText() {
        textBlock.SetActive(false);
    }

}
