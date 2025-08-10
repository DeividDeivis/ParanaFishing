using UnityEngine;

public class ShootSubState : SubState
{
    private FishingSystem fishingSystem;

    public ShootSubState(UISection ui) : base(ui)
    {
        _ui = ui;
    }

    public override void SetSubState()
    {
        fishingSystem = GameObject.FindFirstObjectByType<FishingSystem>();
        fishingSystem.ShootBait();
    }

    public override void OnInteractPress(bool isPressed)
    {
        fishingSystem.shootPressed = isPressed;
        if (!isPressed) 
        {
            _ui.GetComponent<FishingGameUI>().SetPowerBar(0);
            NextSubState.Invoke(new WaitSubState(_ui));
        }           
    }
}
