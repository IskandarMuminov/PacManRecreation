using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;

    private AudioSource audioSource;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        PlayStartTheme();

    }


    void Update()
    {
        if (!audioSource.isPlaying) { 
            PlayGhostNormal();
        }
            

    }

    public void PlayStartTheme() {

        AudioClip startTheme = sounds[0];
        audioSource.clip = startTheme;
        audioSource.Play();
    }

    public void PlayGhostNormal () {
        audioSource.loop = true;
        AudioClip ghostNormal = sounds[1];
        audioSource.clip = ghostNormal;
        audioSource.Play();
    }
}
