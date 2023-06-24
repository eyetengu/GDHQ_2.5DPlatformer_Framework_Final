using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    
    
    public void PlayAudioOfChoice(int clipChoice)
    {
        _audioSource.PlayOneShot(_audioClips[clipChoice]);
    }
}
