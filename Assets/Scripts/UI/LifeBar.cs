using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Image lifeBar;
    [SerializeField] private GameObject shield1, shield2;

    void Start()
    {
        lifeBar = GetComponent<Image>();
    }

    public void UpdateLife(int totalLP, int actualLP)
    {
        lifeBar.fillAmount = (float)actualLP / (float)totalLP;
    }

    public void UpdateShields(int shields)
    {
        if (shields == 0)
        {
            shield1.SetActive(false);
            shield2.SetActive(false);
        }
        else if (shields == 1)
        {
            shield1.SetActive(true);
            shield2.SetActive(false);
        }
        else
        {
            shield1.SetActive(true);
            shield2.SetActive(true);
        }

    }
}
