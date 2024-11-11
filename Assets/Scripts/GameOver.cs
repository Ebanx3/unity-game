using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    void Start()
    {
        Debug.Log("Game Over empezando a funcionar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gameover()
    {
        gameOverText.gameObject.SetActive(false);
    }


}
