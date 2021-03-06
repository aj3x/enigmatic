﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{

    public float speed;

    private CharacterController controller;

    void Start()
    {

        controller = GetComponent<CharacterController>();

    }

    void Update()
    {


        if (Input.GetKey(KeyCode.UpArrow))
        {
            //vector3.right for x axis, vector3.up for y axis, and vector3.forward for z axis, 
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0);
        }

        //rotate right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0);
        }
    }

    
}
