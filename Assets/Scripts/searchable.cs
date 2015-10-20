using UnityEngine;
using System.Collections;

public class searchable : MonoBehaviour {
    CircleCollider2D range;
	// Use this for initialization
	void Start () {
        range = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D coll) {
        if (coll.tag.Equals("Searchable")){
            Debug.Log("Your trigger is working");
        }
    }
}
