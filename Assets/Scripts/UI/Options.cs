using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Options : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    [SerializeField]
    public Slider volumeSlider = null;
    public TMP_Dropdown resolutionDropdown, qualityDropdown;
    Resolution[] resolutions;
    public float volumeValue;
    public int qualityIndexValue;

    void Start()
    {
        volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;

        qualityIndexValue = PlayerPrefs.GetInt("QualityIndex");
        qualityDropdown.value = qualityIndexValue;

        //mainAudioMixer.SetFloat("volume", volumeValue);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x "+ resolutions[i].height +" @ " +resolutions[i].refreshRate + " Hz";
            if(options.Contains(option) == false)
            {
                options.Add(option);
            }

            if(resolutions[i].Equals(Screen.currentResolution))
            {
                currentResolutionIndex = i;
            }
        }        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue(); 
    }

    void Update()
    {
       volumeSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
       qualityDropdown = GameObject.Find("graphicsDropdown").GetComponent<TMP_Dropdown>();
       
    }

    public void SetVolume(float volume)
    {   volumeValue = volumeSlider.value;
        mainAudioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("VolumeValue", volume);
        LoadValues();
        
    }

    public void LoadValues()
    {
        volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        //volumeSlider.value = volumeValue;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
    }
    
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
  
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); 
    }
    
}
