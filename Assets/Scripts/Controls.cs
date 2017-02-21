﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added 2/19/17
public class Controls : MonoBehaviour {

    private Rigidbody rb;
    private int points;
    float lastpress = 0;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        points = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.position.y < -10) // LOSE
        {
            Debug.Log("You Lose!!");
        }
        if (Input.GetKey("r")){
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (Input.GetKey("q")){
            Application.Quit();
        }/*
        isRotating = false
        rotDeg = 0
        if(... && !isRotating)
            isRot = trues;
            rotDeg = 0;
            if(isRotaing)
                float AxisRot = 90 * time.deltatime
                transform.rotate(Vector3.up * thisRotation
                rotDeg += thisRotation
                if(rotDeg > 90)
                    isRot = false*/
        //Coroutine for wall-turning
	}
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - lastpress > 0.5)
            {
                lastpress = Time.time;
                rb.AddForce(Vector3.up * Time.deltaTime * 15000);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Goal")
        {
            if (points > 1) {// WIN
                GameObject camera = GameObject.Find("Main Camera");
                GameObject cube = GameObject.Find("Cube");
                GameObject board = GameObject.Find("Board");
               
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.AddForce(Vector3.up * Time.deltaTime * 1000);

                camera.GetComponent<CameraController>().enabled = false;
                camera.transform.position = new Vector3(0, 10, -5);
                board.GetComponent<tilt>().enabled = false;//Causing error
                cube.transform.position = new Vector3(0, 0, 0);


                Debug.Log("You Win!!");
            }
        }
        else if(other.name.Contains("Pickup"))
        {
            other.gameObject.SetActive(false);
            points++;
        }
    }
}
