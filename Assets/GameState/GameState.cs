using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    int _score = 0, _highScore;
    bool _isGameOver = false;
    [SerializeField] GameObject _scoreText;
    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] GameObject _highScoreText;
    public static GameState Instance;

   // private Text _highScoreText;

    private void Awake()
    {
       
        Instance = this;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            Time.timeScale = 1f;
            PauseMen._isPaused = false;
            _highScore = PlayerPrefs.GetInt("HighScore");
           
        }

       // _highScoreText = GetComponent<Text>();
    }

    public void InitiateGameOver()
    {
        
        _isGameOver = true;
        
        _gameOverMenu.SetActive(true);
        _highScoreText.GetComponent<Text>().text = "High Score: " + _highScore.ToString();
         _highScoreText.SetActive(true);
        //_highScoreText.enabled = true;

    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _scoreText.GetComponent<Text>().text = "Score: " + _score.ToString();
        //Debug.Log(_score);
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;

            PlayerPrefs.SetInt("HighScore", _highScore);
            EventManager.TriggerEvent("HighScoreSound");
            EventManager.TriggerEvent("NewHighScoreText");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && _isGameOver)
        {
            ReloadScene();
            
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        _highScore = 0;
        
        //_highScoreText.GetComponent<Text>().text = "High Score: 0";
       // _highScoreText.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
