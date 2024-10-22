using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }

    // M�todo para cerrar el juego
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Si est�s en el editor, detener la ejecuci�n
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Si est� en construcci�n, cerrar la aplicaci�n
            Application.Quit();
#endif
    }
}
