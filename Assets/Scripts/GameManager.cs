using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettings _settings;
    public GameSettings Settings => _settings;
    [SerializeField] private StateController _states;
    public StateController States => _states;

    [SerializeField] private EventReference BGMusicEvent;
    private EventInstance musicState;


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
        _states.SetState(new MenuState());

        musicState = RuntimeManager.CreateInstance(BGMusicEvent);
        musicState.start();
    }

    public void SetMusicState(int value)
    {
        //musicState.setParameterByName("Scene", value); // Local Parameter
        RuntimeManager.StudioSystem.setParameterByName("Scene", value); // Global Parameter

        float currentValue = 0;
        RuntimeManager.StudioSystem.getParameterByName("Scene", out currentValue);
        Debug.Log($"<color=cyan>Music Parameter change to: {currentValue}</color>");
    }
}
