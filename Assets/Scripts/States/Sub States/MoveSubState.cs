using UnityEngine;

public class MoveSubState : SubState
{
    private Transform player;
    private float rotationSpeed;
    private bool shoot;

    public MoveSubState(UISection ui) : base(ui)
    {
        _ui = ui;
    }

    public override void SetSubState()
    {
        player = GameObject.FindFirstObjectByType<FishingSystem>().transform;
        rotationSpeed = GameManager.instance.Settings.RotationSpeed;
        shoot = false;

        _ui.GetComponent<FishingGameUI>().SetPowerBar(0);
    }

    public override void OnLeftPress(bool isPressed)
    {
        if (isPressed && !shoot) 
            player.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
    }

    public override void OnRightPress(bool isPressed)
    {
        if (isPressed && !shoot)
            player.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    public override void OnInteractTap()
    {
        shoot = true;
        NextSubState.Invoke(new ShootSubState(_ui));
    }
}
