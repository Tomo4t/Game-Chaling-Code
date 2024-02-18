using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider s_Sound,s_Music,s_Text;
    [SerializeField] private Button b_ValumeSave,b_controlsSave;
    [SerializeField] private Toggle Movement,Grabbing,Extras;

    public const string Sound = "SoundVG";
    public const string Music = "MusicVG";
    public const string Text = "TextVG";
    

    private void Awake()
    {
        s_Sound.onValueChanged.AddListener(setSoundVolume);
        s_Music.onValueChanged.AddListener(setMusicVolume);
        s_Text.onValueChanged.AddListener(setTextVolume);
        b_ValumeSave.onClick.AddListener(SaveVolume);
        b_controlsSave.onClick.AddListener(SaveControls);
    }
    private void Start()
    {
        s_Sound.value = PlayerPrefs.GetFloat(Sound, 0.75f);
        s_Music.value = PlayerPrefs.GetFloat(Music, 0.7f);
        s_Text.value = PlayerPrefs.GetFloat(Text, 0.8f);
        
        Movement.isOn = PlayerPrefs.GetInt("Butten",0) == 1 ? true : false ;
        Grabbing.isOn = PlayerPrefs.GetInt("Toggle",0) == 1 ? true : false;
        Extras.isOn = PlayerPrefs.GetInt("Inv_Movement",0) == 1 ? true : false;
    }
    void setSoundVolume(float volume) 
    {
    mixer.SetFloat(Sound, Mathf.Log10(volume) *20);
    }
    void setMusicVolume(float volume)
    {
        mixer.SetFloat(Music, Mathf.Log10(volume) * 20);
    }
    void setTextVolume(float volume)
    {
        mixer.SetFloat(Text, Mathf.Log10(volume) * 20);
    }
    void SaveVolume() 
    {
        PlayerPrefs.SetFloat(Sound,s_Sound.value);
        PlayerPrefs.SetFloat(Music,s_Music.value);
        PlayerPrefs.SetFloat(Text,s_Text.value);
        
    }
    void SaveControls() 
    {
        if (Movement.isOn)
        {
            PlayerPrefs.SetInt("Butten", 1) ;
            
        }
        else
        {
            PlayerPrefs.SetInt("Butten", 0);
            
        }
        if (Grabbing.isOn)
        {
            PlayerPrefs.SetInt("Toggle", 1);
           
        }
        else
        {
            PlayerPrefs.SetInt("Toggle", 0);
            
        }
        if (Extras.isOn)
        {
            PlayerPrefs.SetInt("Inv_Movement", 1);
            
        }
        else
        {
            PlayerPrefs.SetInt("Inv_Movement", 0);
            
        }
        PlayerPrefs.Save();
    }
}
