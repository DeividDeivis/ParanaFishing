using UnityEngine;

public class GameplayState : State, IState
{
    private SubState currentSubState;

    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Gameplay");
        _UI.OnSectionIN();

        AudioManager.instance.SetMusicState(1); 

        InputManager._.StartReadInput("Interact", SubStateInteractTap);
        InputManager._.StartReadInput("Interact", SubStateInteractPress);
        InputManager._.StartReadInput("Left", SubStateLeftTap);
        InputManager._.StartReadInput("Left", SubStateLeftPress);
        InputManager._.StartReadInput("Right", SubStateRightTap);
        InputManager._.StartReadInput("Right", SubStateRightPress);

        FishingSystem.instance.ShowRod(() => 
        { 
            SetSubState(new MoveSubState(_UI));
            SubState.NextSubState += SetSubState;
        });
    }

    public override void OnStateUpdate()
    {
        currentSubState?.OnSubState();
    }

    public override void OnStateExit()
    {
        InputManager._.StopReadAllInput();

        SubState.NextSubState -= SetSubState;

        _UI.OnSectionOUT();
    }

    private void SubStateInteractTap() { currentSubState?.OnInteractTap(); }
    private void SubStateInteractPress(bool press) { currentSubState?.OnInteractPress(press); }
    private void SubStateLeftTap() { currentSubState?.OnLeftTap(); }
    private void SubStateLeftPress(bool press) { currentSubState?.OnLeftPress(press); }
    private void SubStateRightTap() { currentSubState?.OnRightTap(); }
    private void SubStateRightPress(bool press) { currentSubState?.OnRightPress(press); }

    private void SetSubState(SubState sub) 
    {
        currentSubState = sub;
        currentSubState.SetSubState();
        Debug.Log($"Sub state change to: {sub}");
    }
}