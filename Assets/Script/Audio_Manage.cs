using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manage : MonoBehaviour
{
    public static Audio_Manage Instance;

    public Sound[] Music_Audio;

    public Sound[] SFX_Audio;

    public AudioSource Music_Source;

    public AudioSource SFX_Source;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        Play_Music("Music_Background");
    }

    public void Play_Music(string name)
    {
        Sound s = Array.Find(Music_Audio, x => x.Name_Audio == name);
        if (s != null )
        {
            Music_Source.clip = s.Audio_Clip;
            Music_Source.Play();
        }
    }

    public void Play_SFX(string name)
    {
        Sound s = Array.Find(SFX_Audio, x => x.Name_Audio == name);
        if (s != null)
        {
            SFX_Source.PlayOneShot(s.Audio_Clip);
        }
    }

    public void Mute_Music()
    {
        Music_Source.mute = !Music_Source.mute;
    }    

    public void Mute_SFX()
    {
        SFX_Source.mute = !SFX_Source.mute;
    }    

    public void Music_Volume(float volume)
    {
        Music_Source.volume = volume;
    }    

    public void SFX_Volume(float volume)
    {
        SFX_Source.volume = volume;
    }
}
