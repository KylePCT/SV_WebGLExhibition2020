using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpecs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Processor Count: " + SystemInfo.processorCount);
        Debug.Log("Processor Frequency: " + SystemInfo.processorFrequency);
        Debug.Log("Processor Type: " + SystemInfo.processorType);
        Debug.Log("GPU Memory: " + SystemInfo.graphicsMemorySize);
        Debug.Log("GPU Name: " + SystemInfo.graphicsDeviceName);
        Debug.Log("RAM Size: " + SystemInfo.systemMemorySize);

        Debug.Log("OS: " + SystemInfo.operatingSystem);
        Debug.Log("Device Name: " + SystemInfo.deviceName);
        Debug.Log("Device Type: " + SystemInfo.deviceType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
