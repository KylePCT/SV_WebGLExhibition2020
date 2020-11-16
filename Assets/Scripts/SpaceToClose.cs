using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceToClose : MonoBehaviour
{
    private void OnEnable()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
        }
    }
}
