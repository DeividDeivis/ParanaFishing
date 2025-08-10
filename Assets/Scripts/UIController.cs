using System;
using System.Collections.Generic;
using System.Linq;
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

    private void Awake()
    {
        m_UISections = new List<UISection>();
        m_UISections = GetComponents<UISection>().ToList();
        foreach (var _ui in m_UISections)
        {
            _ui.OnSectionOUT();
        }
    }

    #region Fishing UI
    [SerializeField] private Slider powerBar;
    public void SetPowerBar(float value) 
    {
        powerBar.value = value;
    }
    #endregion

    public UISection GetUI(string id) 
    {
        if (m_UISections.Exists(x => x.SectionID.Equals(id)))
        {
            UISection ui = m_UISections.First(x => x.SectionID.Equals(id));
            return ui;
        }
        else 
        {
            Debug.LogError($"UI Sections don`t containt {id}");
            return null;
        }
    }
}
