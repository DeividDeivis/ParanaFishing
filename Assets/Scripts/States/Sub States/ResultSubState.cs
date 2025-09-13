using UnityEngine;

public class ResultSubState : SubState
{
    public ResultSubState(UISection ui) : base(ui)
    {
        _ui = ui;
    }

    public override void SetSubState()
    {

    }

    public override void OnInteractTap()
    {

    }

    public override void OnLeftPress(bool isPressed)
    {
        _ui.Options.ChangeUp();
        AudioManager.instance.PlaySfx("Select");
    }

    public override void OnRightPress(bool isPressed)
    {
        _ui.Options.ChangeDown();
        AudioManager.instance.PlaySfx("Select");
    }
}
