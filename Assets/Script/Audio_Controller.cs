using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Controller : MonoBehaviour
{
    public Image SFX_On;

    public Image SFX_Off;

    public Image Music_On;

    public Image Music_Off;

    private bool Check_Music_On = true;

    private bool Check_SFX_On = true;

    public Slider Music_Slider;

    public Slider SFX_Slider;

    public void Mute_Music()
    {
        if (Check_Music_On)
        {
            Audio_Manage.Instance.Mute_Music();
            Check_Music_On = false;
            Music_On.enabled = false;
            Music_Off.enabled = true;
        }
        else
        {
            Audio_Manage.Instance.Mute_Music();
            Check_Music_On = true;
            Music_On.enabled = true;
            Music_Off.enabled = false;
        }
    }

    private void Start()
    {
        SFX_Off.enabled = false;
        Music_Off.enabled = false;
    }

    public void Mute_SFX()
    {
        if (Check_SFX_On)
        {
            Audio_Manage.Instance.Mute_SFX();
            Check_SFX_On = false;
            SFX_On.enabled = false;
            SFX_Off.enabled = true;
        }
        else
        {
            Audio_Manage.Instance.Mute_SFX();
            Check_SFX_On = true;
            SFX_On.enabled = true;
            SFX_Off.enabled = false;
        }
    }

    public void Music_Volume()
    {
        Audio_Manage.Instance.Music_Volume(Music_Slider.value);
    }

    public void SFX_Volume()
    {
        Audio_Manage.Instance.SFX_Volume(SFX_Slider.value);
    }

    void Update()
    {
        Music_Volume();
        SFX_Volume();
    }

    
}
