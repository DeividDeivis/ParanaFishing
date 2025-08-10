using UnityEngine;
using FMODUnity;

public class GameplayState : State, IState
{
    private SubState currentSubState;

    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Gameplay");
        _UI.OnSectionIN();

        GameManager.instance.SetMusicState(1);

        SetSubState(new MoveSubState(_UI));

        InputManager.InteractTap += SubStateInteractTap;
        InputManager.InteractPress += SubStateInteractPress;
        InputManager.LeftTap += SubStateLeftTap;
        InputManager.LeftPress += SubStateLeftPress;
        InputManager.RightTap += SubStateRightTap;
        InputManager.RightPress += SubStateRightPress;

        SubState.NextSubState += SetSubState;
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        InputManager.InteractTap -= SubStateInteractTap;
        InputManager.InteractPress -= SubStateInteractPress;
        InputManager.LeftTap -= SubStateLeftTap;
        InputManager.LeftPress -= SubStateLeftPress;
        InputManager.RightTap -= SubStateRightTap;
        InputManager.RightPress -= SubStateRightPress;

        SubState.NextSubState -= SetSubState;

        _UI.OnSectionOUT();
    }

    private void SubStateInteractTap() { currentSubState.OnInteractTap(); }
    private void SubStateInteractPress(bool press) { currentSubState.OnInteractPress(press); }
    private void SubStateLeftTap() { currentSubState.OnLeftTap(); }
    private void SubStateLeftPress(bool press) { currentSubState.OnLeftPress(press); }
    private void SubStateRightTap() { currentSubState.OnRightTap(); }
    private void SubStateRightPress(bool press) { currentSubState.OnRightPress(press); }

    private void SetSubState(SubState sub) 
    {
        currentSubState = sub;
        currentSubState.SetSubState();
        Debug.Log($"Sub state change to: {sub}");
    }
}