using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    
    
    void Start()
    {
        StarGame();
    }

   
    void Update()
    {
        
    }

    public void UpdateScore(int scorteToAdd)
    {
        score += scorteToAdd;
        scoreText.text = "Score: " + score;
    }

    public void StarGame()
    {
        
        score = 0;
        
        UpdateScore(0);
    }

}
