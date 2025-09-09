using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private bool debugInput = false;
    public bool showDebug => debugInput;

    private InputSystem_Actions m_Inputs;

    [SerializeField] private List<ButtonInfo> buttonsInputs = new List<ButtonInfo>();

    void OnEnable()
    {
        /// Enable actions as part of enabling this behavior.
        m_Inputs.Enable();
    }

    void OnDisable()
    {
        /// Disable actions as part of disabling this behavior.
        m_Inputs.Disable();
    }

    #region Singleton
    private static InputManager _instance;
    public static InputManager _
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<InputManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        m_Inputs = new InputSystem_Actions();

        buttonsInputs.Add(new ButtonInfo("Right", m_Inputs._3Buttons.Right));
        buttonsInputs.Add(new ButtonInfo("Left", m_Inputs._3Buttons.Left));
        buttonsInputs.Add(new ButtonInfo("Interact", m_Inputs._3Buttons.Interact));
    }



    // Tap input
    public void StartReadInput(string inputName, Action onTap) 
    {
        var input = buttonsInputs.First(btn => btn.BtnName == inputName);
        input.BtnTap += onTap;

        Debug.Log($"Start Read Input {inputName}");
    }

    public void StopReadInput(string inputName, Action onTap)
    {
        var input = buttonsInputs.First(btn => btn.BtnName == inputName);
        input.BtnTap -= onTap;

        Debug.Log($"Stpo Read Input {inputName}");
    }

    // Press input with boolean
    public void StartReadInput(string inputName, Action<bool> onPress)
    {
        var input = buttonsInputs.First(btn => btn.BtnName == inputName);
        input.BtnPress += onPress;

        Debug.Log($"Start Read Input {inputName}, OnPress {onPress}");
    }

    public void StopReadInput(string inputName, Action<bool> onPress)
    {
        var input = buttonsInputs.First(btn => btn.BtnName == inputName);
        input.BtnPress -= onPress;

        Debug.Log($"Stop Read Input {inputName}, OnPress {onPress}");
    }
}

[Serializable]
public class ButtonInfo 
{
    public string BtnName;
    public Action BtnTap;
    public Action<bool> BtnPress;

    public ButtonInfo(string name, InputAction input) 
    {
        BtnName = name;
        input.started += TapInput;
        input.performed += PressInput;
        input.canceled += CancelInput;
    }

    public void TapInput(InputAction.CallbackContext ctx) { BtnTap?.Invoke(); if(InputManager._.showDebug) Debug.Log($"{BtnName} Tap"); }
    public void PressInput(InputAction.CallbackContext ctx) { BtnPress?.Invoke(true); if (InputManager._.showDebug) Debug.Log($"{BtnName} Press Start"); }
    public void CancelInput(InputAction.CallbackContext ctx) { BtnPress?.Invoke(false); if (InputManager._.showDebug) Debug.Log($"{BtnName} Press Finish"); }
}