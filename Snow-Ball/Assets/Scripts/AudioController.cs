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
    [SerializeField] AudioClip upgrade;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void playMenuMusic(){
        audioSource.clip = menu;
        audioSource.Play();
    }

    public void playGameMusic(){
        audioSource.clip = game;
        audioSource.Play();
    }

    public void playTimeFreezeMusic(){
        audioSource.clip = timeFreeze;
        audioSource.Play();
    }

    public void playWinMusic(){

    }

    public void playLoseMusic(){

    }

    public void SoundOn(){
        audioSource.enabled = true;
    }

    public void SoundOff(){
        audioSource.enabled = false;
    }

    
}
