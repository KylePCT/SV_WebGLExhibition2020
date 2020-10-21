using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject Player;

    public static bool IsPaused = false;

    public GameObject PauseScreen;
    public GameObject SettingsScreen;

    [Space(10)]
    public Slider MusicSlider;
    public float MusicVolume;
    public AudioListener MusicSource;

    [Space(10)]
    public Slider MouseSlider;
    public FirstPersonAIO ControllerReference;

    private void OnEnable()
    {
        MusicSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        MouseSlider.onValueChanged.AddListener(delegate { OnSensitivityChanged(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Player.GetComponent<FirstPersonAIO>().enabled = true;
        IsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseScreen.SetActive(false);
    }

    public void Pause()
    {
        Player.GetComponent<FirstPersonAIO>().enabled = false;
        IsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseScreen.SetActive(true);
    }

    public void OpenSettings()
    {
        IsPaused = true;
        PauseScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }

    public void OnVolumeChanged()
    {
        AudioListener.volume = MusicSlider.value;
    }

    public void OnSensitivityChanged()
    {
        ControllerReference.mouseSensitivity = MouseSlider.value;
    }
}
