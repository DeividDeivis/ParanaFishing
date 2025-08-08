using UnityEngine;

public class MenuState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Menu");
        _UI.OnSectionIN();

        InputManager.InteractTap += StartGame;
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        InputManager.InteractTap -= StartGame;
        _UI.OnSectionOUT();
    }

    private void StartGame() 
    {
        GameManager.instance._states.SetState(new PlaceSelectionState());
    }
}
