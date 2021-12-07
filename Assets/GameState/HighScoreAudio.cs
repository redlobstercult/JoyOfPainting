using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;

public class HighScoreAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject _newHighScoreText;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
       // _highScoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("HighScoreSound", HighScoreSound);
        EventManager.StartListening("NewHighScoreText", NewHighScoreText);
        // EventManager.StartListening("ShowHighScoreText", ShowHighScoreText);
    }

    private void OnDisable()
    {
        EventManager.StopListening("HighScoreSound", HighScoreSound);
        EventManager.StopListening("NewHighScoreText", NewHighScoreText);
        // EventManager.StopListening("ShowHighScoreText", ShowHighScoreText);
    }

    void HighScoreSound()
    {
        
        EventManager.StopListening("HighScoreSound", HighScoreSound);
        
        _audioSource.PlayOneShot(_audioSource.clip);
      //  Debug.Log("High Score Sound");
    }

    void NewHighScoreText()
    {
        EventManager.StopListening("NewHighScoreText", NewHighScoreText);
        StartCoroutine(NewHighScoreTextEffects());
        
    }

    IEnumerator NewHighScoreTextEffects()
    {
       // yield return new WaitForSeconds(Random.Range(0.0f, 1.0f));
        _newHighScoreText.SetActive(true);
        float vibrate = .2f;
        float startTime = 0;
        float shakeTime = Random.Range(1.0f, 3.0f);
        while (startTime < shakeTime)
        {
            _newHighScoreText.transform.Translate(Random.Range(-vibrate, vibrate), 0f, Random.Range(-vibrate, vibrate));
            _newHighScoreText.transform.Rotate(0.0f, Random.Range(-vibrate * 100, vibrate * 100), 0.0f);
            startTime += Time.deltaTime;
            yield return null;
        }

           _newHighScoreText.SetActive(false); 
    }
}
