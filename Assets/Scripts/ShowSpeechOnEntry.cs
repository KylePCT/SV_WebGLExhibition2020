using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSpeechOnEntry : MonoBehaviour
{
    private BoxCollider StandCollider;
    public GameObject StandSpeechBubble;

    // Start is called before the first frame update
    void Start()
    {
        StandCollider = GetComponent<BoxCollider>();
        StandSpeechBubble.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        StandSpeechBubble.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        StandSpeechBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StandSpeechBubble.SetActive(false);
        }
    }
}
