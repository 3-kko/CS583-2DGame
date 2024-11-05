using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private bool isMuted = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("isMuted"))
        {
            PlayerPrefs.SetInt("isMuted", 0);
            Load();
        }
        else
        {
            Load();
        }
        //AudioListener.pause = isMuted;
    }

    public void onButtonPress()
    {
        if(isMuted == false)
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = false;
        }

        Save();
    }

    private void Load()
    {
        isMuted = PlayerPrefs.GetInt("isMuted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
    }

}
