using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        GameObject pickup = Resources.Load("Pickup", typeof(GameObject)) as GameObject;
        if (pickup == null)
            Debug.Log("Not Working!!");
        else
            Debug.Log("WORKING!!");
        Vector3[] previous = new Vector3[6];
        for (int i = 0; i < 6; i++)
        {
            Vector3 index;
            do
            {
                index = new Vector3(Random.Range(-4, 5) + 0.5f, 0.5f, Random.Range(-4, 5) + 0.5f);
            } while (index.Equals(Vector3.zero) && index.x == 4.5 && index.z == 4.5);
            GameObject pickupClone = Instantiate(pickup, index, Quaternion.Euler(45,45,45));
            //pickupClone.transform.localScale += new Vector3(0,4.5f,0);
            
            pickupClone.transform.parent = transform;
            //pickupClone.transform.localRotation = transform.localRotation;

            
            previous[i] = pickupClone.transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
