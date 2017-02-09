using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tiltold : MonoBehaviour {

    public Vector3 curentRot;
   
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        
        curentRot = GetComponent<Transform>().eulerAngles;
        
        if((Input.GetAxis("Horizontal") > 0.2) && (curentRot.z <= 8 || curentRot.z >= 350))
        {
            transform.Rotate(0, 0, 1);
        }
        if((Input.GetAxis("Horizontal") < -0.2) && (curentRot.z >= 351 || curentRot.z <= 9))
        {

            transform.Rotate(0, 0, -1);
        }
        if ((Input.GetAxis("Vertical") > 0.2) && (curentRot.x <= 8 || curentRot.x >= 350))
        {
            transform.Rotate(1, 0, 0);
        }
        if((Input.GetAxis("Vertical") < -0.2) && (curentRot.x >= 351 || curentRot.x <= 9))
        {

            transform.Rotate(-1, 0, 0);
        }
    }
}

