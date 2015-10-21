using UnityEngine;
using System.Collections;
/// <summary>
/// TEMPORARY CLASS TO GET INTERACTION WITH OBJECTS
/// </summary>
public class basic_move : MonoBehaviour {
    Rigidbody2D r_body;
    float moveForce;
	// Use this for initialization
	void Start () {
        moveForce = 5;
        r_body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        r_body.AddForce(new Vector2(x * moveForce, y * moveForce));
	}
}
