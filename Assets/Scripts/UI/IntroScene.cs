using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public void SkipIntro () {
        SceneManager.LoadScene(3);
    }
}
