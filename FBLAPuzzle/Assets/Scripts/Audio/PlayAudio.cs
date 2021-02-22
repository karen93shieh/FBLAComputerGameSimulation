﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip[] clip;
    public AudioSource audioSource;
    private int randomNumber;
    private bool audioActive=true;
    void Start()
    {
        randomNumber = Random.Range(0, clip.Length);
        //Debug.Log(randomNumber);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip[randomNumber];
        audioSource.playOnAwake = false;
        //startPlayingAudio();
        //pauseAudio();
        //audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = clip;
        //randomStartPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying&&audioActive)
        {
            randomNumber = Random.Range(0, clip.Length);
            audioSource.clip = clip[randomNumber];
            startPlayingAudio();
        }
    }
    public void pauseAudio(){
        //audioActive = false;
        //audioSource.Pause();
    }
    public void startPlayingAudio() {
        //audioActive = true;
        audioSource.Play();
    }
    public void changeVolume(float vol) {
        audioSource.volume = vol;
    }
}
