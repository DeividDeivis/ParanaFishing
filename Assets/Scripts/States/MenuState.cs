using UnityEngine;
using FMODUnity;

public class MenuState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Menu");
        _UI.OnSectionIN(true);

        InputManager._.StartReadInput("Interact", StartGame);

        AudioManager.instance.SetMusicState(0);

        FishingSystem.instance.HideRod();
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        _UI.OnSectionOUT();
    }

    private void StartGame() 
    {
        InputManager._.StopReadAllInput();
        GameManager.instance.States.SetState(new PlaceSelectionState());
        //GameManager.instance.States.SetState(new GameplayState()); //Debug
        AudioManager.instance.PlaySfx("Select");
    }
}
