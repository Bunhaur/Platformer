using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Score : MonoBehaviour
{
    private Text _text;
    private int _score;
    private string _scoreString;

    private void Start()
    {
        _text = GetComponent<Text>();
        _score = 0;
        _scoreString = "Score: ";
        _text.text = ($"{_scoreString} {_score}");
    }

    public void AddScore()
    {
        _score++;
        _text.text = ($"{_scoreString} {_score}");
    } 
}
