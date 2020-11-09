using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeMap : MonoBehaviour
{
    public int checkForMapInterval = 5;
    public GameObject BigMapCanvas;
    public GameObject OrdinaryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            BigMapCanvas.SetActive(true);
            OrdinaryCanvas.SetActive(false);
        }
        else
        {
            BigMapCanvas.SetActive(false);
            OrdinaryCanvas.SetActive(true);
        }
    }
}
