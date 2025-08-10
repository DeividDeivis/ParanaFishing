using UnityEngine;

public class WaitSubState : SubState
{
    private FishingSystem fishingSystem;

    public WaitSubState(UISection ui) : base(ui)
    {
        _ui = ui;
    }

    public override void SetSubState()
    {
        fishingSystem = GameObject.FindFirstObjectByType<FishingSystem>();
        fishingSystem.WaitToCatch();

        FishingSystem.OnFishBait += Fishing;
    }

    public override void OnInteractTap()
    {
        FishingSystem.OnFishBait -= Fishing;

        if (!fishingSystem.catchFish)
        {
            fishingSystem.ReturnBait();
            NextSubState.Invoke(new MoveSubState(_ui));
        }
        else
        {
            Fishing();
        }
    }

    private void Fishing() 
    {
        NextSubState.Invoke(new FishingSubState(_ui)); 
    }
}
