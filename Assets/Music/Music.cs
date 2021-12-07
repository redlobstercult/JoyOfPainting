using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] Slider _musicVolume;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
       
    }

   public void AdjustVolume()
    {
        AudioListener.volume = _musicVolume.value;
        Save();
    }

   public void Load()
    {
        _musicVolume.value = PlayerPrefs.GetFloat("vol");
    }

   public void Save()
    {
        PlayerPrefs.SetFloat("vol", _musicVolume.value);
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("vol"))
        {
            PlayerPrefs.SetFloat("vol", .5f);
            Load();
        }
        else
            Load(); 
    }
}
