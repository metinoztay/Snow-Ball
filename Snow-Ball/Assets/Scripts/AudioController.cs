using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip menu;
    [SerializeField] AudioClip game;
    [SerializeField] AudioClip timeFreeze; 
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;


    private void Start() {
        audioSource = GetComponent<AudioSource>();        
    }

    public void playMenuMusic(){
        audioSource.clip = menu;
        audioSource.Play();
        //audioSource.volume = 0.04f;
    }

    public void playGameMusic(){
        audioSource.clip = game;
        audioSource.Play();
        audioSource.volume = 0.04f;
    }

    public void playTimeFreezeMusic(){
        audioSource.clip = timeFreeze;
        audioSource.Play();
    }

    public void playWinMusic(){
        audioSource.clip = win;
        audioSource.Play();
        audioSource.volume = 0.5f;
        audioSource.loop = false;
    }

    public void playLoseMusic(){
        audioSource.clip = lose;
        audioSource.Play();
        audioSource.volume = 0.5f;
        audioSource.loop = false;
    }

    public void SoundOn(){
        AudioListener.pause = false;
        PlayerPrefs.SetInt("Mute",0);
    }

    public void SoundOff(){
        AudioListener.pause = true;
        PlayerPrefs.SetInt("Mute",1);
    }

    
}
