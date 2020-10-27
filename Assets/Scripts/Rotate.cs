using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 360f; // Speed, in degrees per second.                            
    public float bobSpeed = 5f; //Adjust this to change speed.
    public float bobHeight = 0.5f; //Adjust this to change how high it goes.

    private Vector3 pos;

    private void Start()
    {
        //Get the objects current position and put it in a variable so we can access it later with less code.
        Vector3 pos = this.transform.position;
    }

    void Update()
    {
        //Infinitely rotates on the y axis.
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        //Calculate what the new Y position will be.
        float newY = Mathf.Sin(Time.time * bobSpeed);
        //Set the object's Y to the new calculated Y.
        pos.y = newY;
        this.transform.position = new Vector3(this.transform.position.x, (pos.y * bobHeight), this.transform.position.z);
    }
}
