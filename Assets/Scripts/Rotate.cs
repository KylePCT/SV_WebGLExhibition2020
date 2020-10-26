using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 360f; // Speed, in degrees per second.                            
    public float bobSpeed = 5f; //Adjust this to change speed.
    public float bobHeight = 0.5f; //Adjust this to change how high it goes.

    void Update()
    {
        //Infinitely rotates on the y axis.
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            //Get the objects current position and put it in a variable so we can access it later with less code.
            Vector3 pos = transform.position;
            //Calculate what the new Y position will be.
            float newY = Mathf.Sin(Time.time * bobSpeed);
            //Set the object's Y to the new calculated Y.
            transform.position = new Vector3(pos.x, newY, pos.z) * bobHeight;
    }
}
