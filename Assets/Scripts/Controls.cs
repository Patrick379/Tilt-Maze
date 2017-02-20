using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added 2/19/17
public class Controls : MonoBehaviour {

    private Rigidbody rb;
    private int points;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        points = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("r")){
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (Input.GetKey("q")){
            Application.Quit();
        }
        
	}
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.AddForce(Vector3.up * Time.deltaTime * 1500);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Goal")
        {
            if (points < 1) {
                GameObject camera = GameObject.Find("Main Camera");
                Rigidbody rb = GetComponent<Rigidbody>();
                GameObject cube = GameObject.Find("Cube");

                transform.position = new Vector3(0, 4, -1);
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.AddForce(Vector3.up * Time.deltaTime * 5000);

                camera.GetComponent<CameraController>().enabled = false;
                camera.transform.position = new Vector3(0, 10, -10);
                cube.GetComponent<tilt>().enabled = false;
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
