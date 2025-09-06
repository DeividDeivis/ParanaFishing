using System.Collections;
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
        fishingSystem = FishingSystem.instance;
        fishingSystem.ShootBait();
    }

    public override void OnInteractPress(bool isPressed)
    {
        fishingSystem.shootPressed = isPressed;
        if (!isPressed) 
        {
            FishingSystem.OnBaitInWater += BaitInWater;
        }           
    }

    private void BaitInWater() 
    {
        FishingSystem.OnBaitInWater -= BaitInWater;
        _ui.GetComponent<FishingGameUI>().SetPowerBar(0);
        NextSubState.Invoke(new WaitSubState(_ui));
    }
}
