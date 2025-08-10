using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions m_Inputs;

    public static Action RightTap;
    public static Action<bool> RightPress;

    public static Action LeftTap;
    public static Action<bool> LeftPress;

    public static Action InteractTap;
    public static Action<bool> InteractPress;

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

    private void Awake()
    {
        m_Inputs = new InputSystem_Actions();

        m_Inputs._3Buttons.Right.started += ctx => RightTap?.Invoke();
        m_Inputs._3Buttons.Right.performed += ctx => RightPress?.Invoke(true);
        m_Inputs._3Buttons.Right.canceled += ctx => RightPress?.Invoke(false);

        m_Inputs._3Buttons.Left.started += ctx => LeftTap?.Invoke();
        m_Inputs._3Buttons.Left.performed += ctx => LeftPress?.Invoke(true);
        m_Inputs._3Buttons.Left.canceled += ctx => LeftPress?.Invoke(false);

        m_Inputs._3Buttons.Interact.started += ctx => InteractTap?.Invoke();
        m_Inputs._3Buttons.Interact.performed += ctx => InteractPress?.Invoke(true);
        m_Inputs._3Buttons.Interact.canceled += ctx => InteractPress?.Invoke(false);
    }
}
