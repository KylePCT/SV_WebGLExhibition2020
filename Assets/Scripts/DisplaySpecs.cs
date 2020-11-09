using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySpecs : MonoBehaviour
{
    public TextMeshProUGUI ProcessorText;
    public TextMeshProUGUI GPUText;
    public TextMeshProUGUI RAMText;
    public TextMeshProUGUI SystemText;
    public TextMeshProUGUI MobileTest;

    // Start is called before the first frame update
    void Start()
    {
        ProcessorText.SetText("Processor: " + SystemInfo.processorType + ", running at " + SystemInfo.processorFrequency + "Hz with " + SystemInfo.processorCount + " cores.");
        GPUText.SetText("GPU: " + SystemInfo.graphicsDeviceName + " with " + SystemInfo.graphicsMemorySize + "MB memory.");
        RAMText.SetText("RAM Size: " + SystemInfo.systemMemorySize + "MB.");
        SystemText.SetText("Running on: " + SystemInfo.operatingSystem + ", on a " + SystemInfo.deviceType + " named " + SystemInfo.deviceName + ".");

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            MobileTest.gameObject.SetActive(true);
        }
        else
        {
            //Desktop.
        }
    }
}