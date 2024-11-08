using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;
            }

            if (instance == null)
            {
                Instantiate(Resources.Load<GameManager>("GameManager"));
            }
#endif
            return instance;
        }
    }

    // Rebuild Player scripts logic for a correct operation by grouping all in one script called "Player"
    public Movement Movement { get; set; }
    public PointManager PointManager { get; internal set; }
    public EnemySpawnManager EnemySpawnManager { get; set; }
    private bool _isSaving;
    private bool _isLoading;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (Movement == null)
        {
            Movement = Object.FindAnyObjectByType<Movement>();

            if (Movement == null)
            {
                Debug.LogError("No se encontró ningún objeto con el componente Movement en la escena.");
            }
        }
    }

    private void Update()
    {
        if (Keyboard.current.numpad0Key.wasPressedThisFrame && !_isSaving)
        {
            SaveAsync();
        }

        if (Keyboard.current.numpad1Key.wasPressedThisFrame && !_isLoading)
        {
            LoadAsync();
        }
    }

    private async void SaveAsync()
    {
        _isSaving = true;
        await SaveSystem.SaveAsynchronously();
        _isSaving = false;
    }

    private async void LoadAsync()
    {
        _isLoading = true;
        await SaveSystem.LoadAsync();
        _isLoading = false;
    }
}
