using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalWalls : MonoBehaviour
{

    private bool isRotating = false;
    // Use this for initialization
    void Start()
    {

        GameObject wall = Resources.Load("Interior Wall", typeof(GameObject)) as GameObject;
        if (wall == null)
            Debug.Log("Not Working!!");
        else
            Debug.Log("WORKING!!");

        for (int i = -4; i < 5; i++)
            for (int j = -4; j < 5; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    GameObject wallClone = Instantiate(wall, new Vector3(i, 0, j), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
                    GameObject gb = new GameObject();
                    gb.transform.parent = transform;
                    wallClone.transform.parent = gb.transform;
                }

            }
       
    }

    
}
