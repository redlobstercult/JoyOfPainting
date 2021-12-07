using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class TreeSpawnAudio : MonoBehaviour
{
    private AudioSource _pop;

    private void Awake()
    {
        _pop = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("PlaySound", PlaySound);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PlaySound", PlaySound);
    }

    void PlaySound()
    {
        //EventManager.StopListening("PlaySound", PlaySound);
        _pop.PlayOneShot(_pop.clip);
    }
}
