using System;
using UnityEngine;

public class WeatherState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Weather");
        _UI.OnSectionIN();

        InputManager.InteractTap += WheatherConfirmed;
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        InputManager.InteractTap -= WheatherConfirmed;
        _UI.OnSectionOUT();
    }

    private void WheatherConfirmed()
    {
        GameManager.instance.States.SetState(new GameplayState());
    }
}
