using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Variable Element")]
    [SerializeField]
    private int _playerScore;
    private int _playerHighscore;

    [Space(5)]
    [Header("UI Element")]
    public Text scoreText;

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

        _playerHighscore = PlayerPrefs.GetInt("PlayerHighScore");

        if (_playerHighscore < _playerScore)
        {

            PlayerPrefs.SetInt("PlayerHighScore", _playerScore);
            _playerHighscore = _playerScore;

        }

    }

    #endregion

}
