using UnityEngine;

public class PlaceSelectionState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Place");
        _UI.OnSectionIN();

        InputManager.InteractTap += PlaceConfirmed;
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        InputManager.InteractTap -= PlaceConfirmed;
        _UI.OnSectionOUT();
    }

    private void PlaceConfirmed() 
    {
        GameManager.instance.States.SetState(new WeatherState());
    }
}
