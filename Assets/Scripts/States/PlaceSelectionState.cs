using UnityEngine;

public class PlaceSelectionState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Place");
        _UI.OnSectionIN();

        InputManager._.StartReadInput("Interact", PlaceConfirmed);
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
}
