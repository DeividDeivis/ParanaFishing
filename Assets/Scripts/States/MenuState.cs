using UnityEngine;
using FMODUnity;

public class MenuState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Menu");
        _UI.OnSectionIN();

        InputManager._.StartReadInput("Interact", StartGame);

        AudioManager.instance.SetMusicState(0);

        FishingSystem.instance.HideRod();
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        InputManager._.StopReadInput("Interact", StartGame);
        _UI.OnSectionOUT();
    }

    private void StartGame() 
    {
        GameManager.instance.States.SetState(new PlaceSelectionState());
        AudioManager.instance.PlaySfx("Select");
    }
}
