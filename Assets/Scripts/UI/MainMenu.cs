using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject continueButton;

    void Start(){
        //buscar gameManager si está guardado y mostrar
    }

    public void StartNewGame () {
        SceneManager.LoadScene(2);
    }

    public void ContinueGame (){

    }

    public void DisplayOptionsMenu () {
        optionsMenu.SetActive(true);
    }

    public void HideOptionsMenu (){
        optionsMenu.SetActive(false);
    }

    public void QuitGame (){
        Application.Quit();
    }
}
