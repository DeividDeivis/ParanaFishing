using UnityEngine;

public class PlaceSelectionState : State, IState
{
    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Place");
        _UI.OnSectionIN(true);

        InputManager._.StartReadInput("Interact", PlaceConfirmed);
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

    private void PlaceConfirmed() 
    {
        if (_UI.Options.ActiveOption == 0)
        {
            InputManager._.StopReadAllInput();
            GameManager.instance.States.SetState(new WeatherState());
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
