using UnityEngine;
using FMODUnity;

public class MenuState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Menu");
        _UI.OnSectionIN();

        InputManager.InteractTap += StartGame;

        GameManager.instance.SetMusicState(0);
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
        GameManager.instance.States.SetState(new PlaceSelectionState());
    }
}
