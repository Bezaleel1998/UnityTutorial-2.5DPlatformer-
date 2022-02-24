using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Variable Element")]
    [SerializeField]
    private int _playerScore;
    private int _playerOldHighscore;

    [Space(5)]
    [Header("UI Element")]
    public Text scoreText;
    public Text playerLivesText;

    private void Awake()
    {

        _playerScore = 0;

    }

    private void Update()
    {
        
        ShowScore();
        //HighScoreDetection();

    }

    #region ScoringSystem

    public void AddScore(int _scoreInput)
    {

        _playerScore += _scoreInput;

        PlayerPrefs.SetInt("PlayerScore", _playerScore);

    }

    private void ShowScore()
    {

        //Show Score on UI
        scoreText.text = "<color=lime>Coin : " + _playerScore.ToString() + "</color>";
        //show the HighScore on UI too

    }

    private void HighScoreDetection()
    {

        _playerOldHighscore = PlayerPrefs.GetInt("PlayerHighScore");

        if (_playerOldHighscore < _playerScore)
        {

            PlayerPrefs.SetInt("PlayerHighScore", _playerScore);
            _playerOldHighscore = _playerScore;

        }

    }

    #endregion

    #region PlayerLivesUISystem

    public void UpdatePlayerLivesDisplay(int lives)
    {

        playerLivesText.text = "<color=red>Player Lives : " + lives.ToString() + "</color>";

    }

    #endregion

    #region SceneManager

    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }

    #endregion

}
