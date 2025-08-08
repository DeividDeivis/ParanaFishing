using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<UISection> m_UISections;

    #region Singleton
    private static UIController _instance;
    public static UIController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<UIController>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    #endregion


    #region Fishing UI
    [SerializeField] private Slider powerBar;
    public void SetPowerBar(float value) 
    {
        powerBar.value = value;
    }
    #endregion
}
