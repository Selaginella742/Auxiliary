using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    void Start()
    {
        audioSource1.PlayScheduled(AudioSettings.dspTime);
        double clipLength = audioSource1.clip.samples / audioSource1.clip.frequency;
        audioSource2.PlayScheduled(AudioSettings.dspTime + clipLength + 0.5f);
    }
}
