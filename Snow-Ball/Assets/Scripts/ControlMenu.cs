using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    [SerializeField] Slider sensivitySlider;
    [SerializeField] Button sounOnButton;
    [SerializeField] Button sounOffButton;

    Color active = new Color(255,255,255,255);
    Color inaktive = new Color(135,114,114,255);

    private void OnEnable() {
        SaveControl();
    }
    public void SoundOff(){
        AudioListener.pause = true;
        PlayerPrefs.SetInt("Mute",1);
        sounOffButton.Select();
    }

    public void SoundOn(){
        AudioListener.pause = false;
        PlayerPrefs.SetInt("Mute",0);
        sounOnButton.Select();
    }

    public void SaveControl(){
        bool isSoundOff = PlayerPrefs.GetInt("Mute")==1;

        if (isSoundOff)
        {
            SoundOff();
        }else
        {
            SoundOn();
        }

        float sensivity = PlayerPrefs.GetFloat("Sensivity");
        if (sensivity == 0)
        {
            sensivity = 0.2f;
        }
        sensivitySlider.value = sensivity*100;

    }
}
