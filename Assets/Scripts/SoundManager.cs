using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool audio1 = true;
    public AudioSource theaudio;
    [SerializeField] private AudioClip[] clips;

    private void Start()
    {
        theaudio = GetComponent<AudioSource>();
    }
    public void OnclickAudio()
    {
        if (audio1 == true)
        {
            theaudio.Stop();
            audio1 = false;
        }
        if (audio1 == false)
        {
            theaudio.Play();
            audio1 = true;
        }
    }

    public void SetMusicVolume(float volume)
    {
        theaudio.volume = volume;
        //theaudio.volume = 1.0f;
    }

    public void Play()
    {
        theaudio.clip = clips[0];
        theaudio.Play();
    }
}
