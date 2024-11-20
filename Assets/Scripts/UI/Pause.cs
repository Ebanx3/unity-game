using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject controllers;

    public void PauseGame () {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        controllers.SetActive(false);
    }

    public void ContinueGame () {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        controllers.SetActive(true);
    }
}
