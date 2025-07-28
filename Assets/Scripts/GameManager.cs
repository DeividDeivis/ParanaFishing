using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameSettings _settings;

    #region Singleton
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
}
