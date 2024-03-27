using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{public static audioManager instance;

    [SerializeField] private AudioMixer mixer;
    public AudioSource SoundSource,TextSource,MusicSource;
    public List<AudioClip> Music,sounds,Text;

    private void Awake()
    {
        if (instance == null) {  instance = this; } else { Destroy(gameObject); }
    }
    public void loodVolumes() 
    {
        mixer.SetFloat(SettingsHandler.Sound, Mathf.Log10(PlayerPrefs.GetFloat(SettingsHandler.Sound,0.75f))*20);
        mixer.SetFloat(SettingsHandler.Music, Mathf.Log10(PlayerPrefs.GetFloat(SettingsHandler.Music,0.7f))*20);
        mixer.SetFloat(SettingsHandler.Text, Mathf.Log10(PlayerPrefs.GetFloat(SettingsHandler.Text, 0.8f)) * 20);

    }
}
