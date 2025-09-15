using UnityEngine;

public class MoveSubState : SubState
{
    private Transform player;
    private float rotationSpeed;
    private float rotationAngle;
    private bool rightPress;
    private bool leftPress;
    private bool shoot;

    public MoveSubState(UISection ui) : base(ui)
    {
        _ui = ui;
    }

    public override void SetSubState()
    {
        player = FishingSystem.instance.pivot.transform;
        rotationSpeed = GameManager.instance.Settings.RotationSpeed;
        rotationAngle = GameManager.instance.Settings.MaxRotationAngle;
        rightPress = false;
        leftPress = false;
        shoot = false;

        _ui.GetComponent<FishingGameUI>().SetPowerBar(0);
    }

    public override void OnSubState()
    {
        if (shoot) return;

        if (leftPress)
            player.eulerAngles -= new Vector3(0, rotationSpeed * Time.deltaTime, 0);
        else if (rightPress)
            player.eulerAngles += new Vector3(0, rotationSpeed * Time.deltaTime, 0);

        if (leftPress || rightPress) 
        {          
            float YRot = Mathf.Clamp(player.eulerAngles.y, 180 - rotationAngle, 180 + rotationAngle);     
            player.eulerAngles = new Vector3(0, YRot, 0);
        }     
    }

    public override void OnLeftPress(bool isPressed)
    {
        leftPress = isPressed;
    }

    public override void OnRightPress(bool isPressed)
    {
        rightPress = isPressed;
    }

    public override void OnInteractPress(bool isPressed)
    {
        shoot = isPressed;
        if(shoot) 
            NextSubState.Invoke(new ShootSubState(_ui));
    }
}
