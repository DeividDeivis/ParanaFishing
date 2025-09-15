using FMOD.Studio;
using FMODUnity;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("BG Music Settings")]
    [SerializeField] private EventReference BGMusicEvent;
    private EventInstance musicState;

    [Header("Game SFX Settings")]
    [SerializeField] private List<FMODEventInfo> GameSFX;

    #region Singleton
    private static AudioManager _instance;
    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<AudioManager>();
                //DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    #endregion

    #region BG Music Method
    public void StartBGMusic() 
    {
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

    public void StopBGMusic()
    {
        musicState.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicState.release();
    }
    #endregion

    #region Sfx Method
    public void PlaySfx(string eventID, Transform attach = null) 
    {
        try
        {
            FMODEventInfo eventInfo = GameSFX.Find(x => x.ID == eventID);
            var attachTo = attach == null ? transform : attach;
            RuntimeManager.PlayOneShot(eventInfo.SfxEvent);
        }
        catch 
        {
            Debug.Log($"<color=red> FMOD Event ID {eventID} not founded </color>");
        }
    }
    public void PlaySfxInstance(string eventID, Transform attach = null)
    {
        try
        {
            FMODEventInfo eventInfo = GameSFX.Find(x => x.ID == eventID);
            var attachTo = attach == null ? transform : attach;
            eventInfo.SfxInstance = RuntimeManager.CreateInstance(eventInfo.SfxEvent);
            eventInfo.SfxInstance.start();
        }
        catch
        {
            Debug.Log($"<color=red> FMOD Event ID {eventID} not founded </color>");
        }
    }
    public void StopSfxInstance(string eventID)
    {
        try
        {
            FMODEventInfo eventInfo = GameSFX.Find(x => x.ID == eventID);
            eventInfo.SfxInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            eventInfo.SfxInstance.release();
        }
        catch
        {
            Debug.Log($"<color=red> FMOD Event ID {eventID} not founded </color>");
        }
    }
    #endregion
}

[Serializable]
public class FMODEventInfo 
{
    public string ID;
    public EventReference SfxEvent;
    public EventInstance SfxInstance;
}
