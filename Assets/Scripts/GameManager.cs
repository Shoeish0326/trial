using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int _playerScore = 0;
    private TMP_Text _text;
    string _scoreText = "";
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerScore = _player.GetComponent<Move>().Score;
        _text =GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        _text.text = _playerScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<Text>().text = _playerScore.ToString();
        _playerScore = _player.GetComponent<Move>().Score;
        _text.text = _playerScore.ToString();
    }
}
