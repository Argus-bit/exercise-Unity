using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    public List<AudioClip> audioClipList;
    public AudioSource audioSource;

    private void PlayRandom()
    {
        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        audioSource.Play();
    }
}
