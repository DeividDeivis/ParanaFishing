using System;
using UnityEngine;

public class WeatherState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Weather");
        _UI.OnSectionIN();

        InputManager._.StartReadInput("Interact", WheatherConfirmed);
        InputManager._.StartReadInput("Left", SelectLeft);
        InputManager._.StartReadInput("Right", SelectRight);

        _ReadInput = false;
        _UI.OnSectionAnimFinish += () => _ReadInput = true;
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        _UI.OnSectionOUT();

        _UI.OnSectionAnimFinish -= () => _ReadInput = true;
    }

    private void WheatherConfirmed()
    {
        if (_UI.Options.ActiveOption == 0 || _UI.Options.ActiveOption == 1)
        {
            InputManager._.StopReadAllInput();
            GameManager.instance.States.SetState(new ShopState());
            AudioManager.instance.PlaySfx("Choose");
        }
        else
        {
            AudioManager.instance.PlaySfx("Select");
        }
    }

    private void SelectRight()
    {
        _UI.Options.ChangeUp();
        AudioManager.instance.PlaySfx("Select");
    }

    private void SelectLeft()
    {
        _UI.Options.ChangeDown();
        AudioManager.instance.PlaySfx("Select");
    }
}
