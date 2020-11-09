using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    public GameObject Player;

    public static bool IsPaused = false;

    public GameObject PauseScreen;
    public GameObject SettingsScreen;
    public GameObject[] OtherScreens;

    [Space(10)]
    public Slider MusicSlider;
    public float MusicVolume;
    private float MusicVolumeF2;
    public AudioListener MusicSource;
    public TextMeshProUGUI VolumeText;

    [Space(10)]
    public Slider MouseSlider;
    public FirstPersonAIO ControllerReference;
    public TextMeshProUGUI SensitiveText;

    private void OnEnable()
    {
        MusicSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        MouseSlider.onValueChanged.AddListener(delegate { OnSensitivityChanged(); });

        AudioListener.volume = 0.2f;
        MusicSlider.value = 0.2f;
        MusicVolumeF2 = MusicSlider.value;
        VolumeText.text = (MusicVolumeF2 * 100).ToString("F0") + "%";

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

        foreach (GameObject screens in OtherScreens)
        {
            screens.SetActive(false);
        }

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
        AudioListener.volume = MusicSlider.value; //This value is confirmed changing in debug.
        MusicVolumeF2 = MusicSlider.value;
        VolumeText.text = (MusicVolumeF2 * 100).ToString("F0") + "%";
    }

    public void OnSensitivityChanged()
    {
        ControllerReference.mouseSensitivity = MouseSlider.value;
        SensitiveText.text = MouseSlider.value + "";
    }
}
