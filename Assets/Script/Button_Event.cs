using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Event : MonoBehaviour
{
    public GameObject Pause_Back;

    private bool Pause_Display = true;

    public void Pause_Game()
    {
        if (Pause_Display)
        {
            Pause_Back.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Pause_Back.SetActive(false);
            Time.timeScale = 1;
        }
        Pause_Display = !Pause_Display;
    }  
    
    public void Restart()
    {
        SceneManager.LoadScene("Level_1");
        Check_Pause();
        Audio_Manage.Instance.Music_Source.Play();
    }

    public void Play()
    {
        Check_Pause();
        SceneManager.LoadScene("Level_1");
    }

    public void Home()
    {
        Audio_Manage.Instance.Music_Source.Stop();
        SceneManager.LoadScene("Home");
        Check_Pause();
    }

    public void Ressume()
    {
        Pause_Back.SetActive(false);
        Check_Pause();
    }   
    
    public void Quit()
    {
        Application.Quit();
    }  
    
    private void Check_Pause()
    {
        if(Time.timeScale == 0)
            Time.timeScale = 1;
    }    
}
