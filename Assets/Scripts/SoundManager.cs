using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public bool audio1 = true;
    public AudioSource theaudio;
    public GameObject BGMplayer;
    [SerializeField] private AudioClip[] clips;

    private void Start()
    {
        theaudio = GetComponent<AudioSource>();
    }
    public void OnclickAudio()
    {
        if (audio1 == true)
        {
            BGMplayer.SetActive(false);
            audio1 = false;
            theaudio.Stop();
        }
        if (audio1 == false)
        {
            BGMplayer.SetActive(true);
            audio1 = true;
            theaudio.Play();
        }
    }
    public void audios()
    {
        theaudio.clip = clips[0];
        
    }
}
