using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;
    public TMP_Dropdown resolutionDropdown;


    Resolution[] resolutions;

    public void ChangeGraphicsQuality() //Graphics toggle
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    //next 3 methods adjust their according audio levels (SFX, Master, Background Music)
    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("master", masterVol.value);
    }
    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("background music", musicVol.value);
    }
    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("sfx", sfxVol.value);
    }

    public void SetFullscreen(bool isFullscreen) // fullscreen toggle 
    {
        Screen.fullScreen = isFullscreen;
    }


    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions; //gets an array of all the available resolutions and stores them in my created array called "resolutions"
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
