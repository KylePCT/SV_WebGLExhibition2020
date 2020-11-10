using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        StartCanvas.SetActive(true);
        Player.GetComponent<FirstPersonAIO>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EnterExhibition()
    {
        StartCanvas.SetActive(false);
        Player.GetComponent<FirstPersonAIO>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowMouse()
    {
        Player.GetComponent<FirstPersonAIO>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DisableMouse()
    {
        Player.GetComponent<FirstPersonAIO>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
