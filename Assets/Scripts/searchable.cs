using UnityEngine;
using System.Collections;

public class searchable : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    

    /// <summary>
    /// If player is looking at object and pushes action button display container's contents
    /// </summary>
    /// <param name="coll"></param>
    void OnTriggerStay2D(Collider2D coll) {
        if (coll.tag.Equals("Searchable")&& Input.GetButtonDown("Action")){
            //Open Search message menu
            coll.GetComponent<container>().SendMessage("onSearch");
        }
    }
}
