using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("CollectSound", CollectSound);
    }

    private void OnDisable()
    {
        EventManager.StopListening("CollectSound", CollectSound);
    }

    void CollectSound()
    {
        float randVolume = Random.Range(0.2f, 1f);
        //EventManager.StopListening("CollectSound", CollectSound);
        _audioSource.pitch = Random.Range(0.85f, 1.25f);
        _audioSource.PlayOneShot(_audioSource.clip, randVolume);
        //Debug.Log("Tree Sound");
    }
}
