using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tilt : MonoBehaviour {

    public Vector3 curentRot;
    public float tiltSensitivity = 20.0f;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        float deltaHRot = -Time.deltaTime * tiltSensitivity * Input.GetAxis("Horizontal");
        float deltaVRot = Time.deltaTime * tiltSensitivity * Input.GetAxis("Vertical");
        curentRot = GetComponent<Transform>().eulerAngles;
        normalizeEuler(ref curentRot);

        if(curentRot.z > 10 && deltaHRot > 0)
        {

            deltaHRot = 0;
        }
        if(curentRot.z < -10 && deltaHRot < 0)
        {

            deltaHRot = 0;
        }
        if (curentRot.x > 10 && deltaVRot > 0)
        {

            deltaVRot = 0;
        }
        if(curentRot.x < -10 && deltaVRot < 0)
        {

            deltaVRot = 0;
        }
        transform.Rotate(0, 0, deltaHRot);
        transform.Rotate(deltaVRot, 0, 0);
	}

    void normalizeEuler(ref Vector3 rot)
    {

        rot.x =  rot.x > 180 ? rot.x -= 360 : rot.x;
        rot.y = rot.y > 180 ? rot.y -= 360 : rot.y;
        rot.z = rot.z > 180 ? rot.z -= 360 : rot.z;
    }
}
