using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PauseMen : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _oohBabyILikeItRaw;
    [SerializeField] GameObject _killedTheRadioStar;
    public static bool _isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (_isPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
        
    }

    void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _oohBabyILikeItRaw.SetActive(true);
        _killedTheRadioStar.SetActive(true);
      //  _killedTheRadioStar.Play();
    }

   public void Resume()
    {
        Time.timeScale = 1f;
        _isPaused = false;
        _pauseMenu.SetActive(false);
       // _killedTheRadioStar.Stop();
        _oohBabyILikeItRaw.SetActive(false);
          _killedTheRadioStar.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
