using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    bool isRotating = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1f * Time.deltaTime);

    }
    IEnumerator Turn()
    {
        int chance = Random.Range(0, 1);
        if (chance > 0)
        {

            transform.Rotate(new Vector3(0, 360, 0) * Time.deltaTime);
            yield return null;

            yield return new WaitForSeconds(1);
        }
    }
}
