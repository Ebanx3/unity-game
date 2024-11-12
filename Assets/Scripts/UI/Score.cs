using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;

    void Start()
    {   
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
        UpdateScore(0);
    }

    public void UpdateScore(int scorteToAdd)
    {
        score += scorteToAdd;
        scoreText.text = FormatedScore();
    }

    private string FormatedScore()
    {
        if (score < 10) return "0000" + score;
        else if (score < 100) return "000" + score;
        else if (score < 1000) return "00" + score;
        else if (score < 10000) return "0" + score;
        else return score.ToString();
    }
}
