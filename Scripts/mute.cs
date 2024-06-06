using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mute : MonoBehaviour
{
    [SerializeField] Image musiconicon;
    [SerializeField] Image musicofficon;
    private bool muted = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        else
        {
            load();
        }
        AudioListener.pause = muted;
    }

    public void onbuttonpress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        save();
    }

    private void updateicon()
    {
        if(muted == false)
        {
            musicofficon.enabled = false;
            musiconicon.enabled = true;
        }
        else
        {
            musicofficon.enabled = true;
            musiconicon.enabled = false;
        }
    }

    private void load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void save()
    {
        PlayerPrefs.SetInt("muted",muted ? 1 : 0);
    }
}
