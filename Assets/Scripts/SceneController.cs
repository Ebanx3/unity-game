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

    // Método para cerrar el juego
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Si estás en el editor, detener la ejecución
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Si está en construcción, cerrar la aplicación
            Application.Quit();
#endif
    }
}
