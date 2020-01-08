using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider effectVolumeSlider;
    public Slider masterVolumeSlider;

    public TMPro.TMP_Dropdown qualityDropDown;
    public TMPro.TMP_Dropdown resolutionDropDown;

    public Toggle fullScreenToogle;

    public float musicVolume;
    public float effectVolume;

    public AudioMixer mainAudioMixer;

    public Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> optionResolutions = new List<string>() ;
        int currentResolutionIndex = 0;

        for (int i =0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            optionResolutions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropDown.AddOptions(optionResolutions);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void FixedUpdate()
    {
        mainAudioMixer.SetFloat("masterVolume",masterVolumeSlider.value);
        effectVolume = effectVolumeSlider.value;
        musicVolume = musicVolumeSlider.value;

        QualitySettings.SetQualityLevel(qualityDropDown.value);
        Debug.Log(QualitySettings.GetQualityLevel());
        

        Resolution selectedResolution = resolutions[resolutionDropDown.value];

        if(selectedResolution.width != Screen.currentResolution.width || selectedResolution.height != Screen.currentResolution.height)
        {
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreenToogle.isOn);
        }
        Screen.fullScreen = (fullScreenToogle.isOn);

    }
  
}
