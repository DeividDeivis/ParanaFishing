using System;
using UnityEngine;

public class WeatherState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Weather");
        _UI.OnSectionIN();

        InputManager._.StartReadInput("Interact", WheatherConfirmed);
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        InputManager._.StopReadInput("Interact", WheatherConfirmed);
        _UI.OnSectionOUT();
    }

    private void WheatherConfirmed()
    {
        GameManager.instance.States.SetState(new GameplayState());
        AudioManager.instance.PlaySfx("Select");
    }
}
