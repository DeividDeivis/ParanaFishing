
using System;

public class SubState
{
    protected UISection _ui;
    public SubState(UISection ui) 
    { 
        _ui = ui; 
    }
    public virtual void SetSubState() { }

    public virtual void OnSubState() { }
    public virtual void OnInteractTap() { }
    public virtual void OnInteractPress(bool isPressed) { }
    public virtual void OnRightTap() { }
    public virtual void OnRightPress(bool isPressed) { }
    public virtual void OnLeftTap() { }
    public virtual void OnLeftPress(bool isPressed) { }

    public static Action<SubState> NextSubState;
}

