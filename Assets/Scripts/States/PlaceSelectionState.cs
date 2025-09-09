using UnityEngine;

public class PlaceSelectionState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Place");
        _UI.OnSectionIN();

        InputManager._.StartReadInput("Interact", PlaceConfirmed);
        InputManager._.StartReadInput("Left", SelectLeft);
        InputManager._.StartReadInput("Right", SelectRight);
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        InputManager._.StopReadInput("Interact", PlaceConfirmed);
        _UI.OnSectionOUT();
    }

    private void PlaceConfirmed() 
    {
        GameManager.instance.States.SetState(new WeatherState());
        AudioManager.instance.PlaySfx("Select");
    }

    private void SelectRight()
    {
        //GameManager.instance.States.SetState(new PlaceSelectionState());
        AudioManager.instance.PlaySfx("Select");
    }

    private void SelectLeft()
    {
        //GameManager.instance.States.SetState(new PlaceSelectionState());
        AudioManager.instance.PlaySfx("Select");
    }
}
