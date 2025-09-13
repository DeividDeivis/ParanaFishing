using System.Collections.Generic;
using UnityEngine;

public class ShopState : State, IState
{
    private FishingSystem fishingSystem;
    private List<BaitInfo> baits;

    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Shop");
        _UI.OnSectionIN();

        InputManager._.StartReadInput("Interact", BuyBait);
        InputManager._.StartReadInput("Left", SelectLeft);
        InputManager._.StartReadInput("Right", SelectRight);

        _ReadInput = false;
        _UI.OnSectionAnimFinish += () => _ReadInput = true;

        fishingSystem = FishingSystem.instance;
        fishingSystem.Inv.ResetInventory();
        fishingSystem.Inv.OnBaitsComplete += CompleteInventory;
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateExit()
    {
        _UI.OnSectionOUT();

        _UI.OnSectionAnimFinish -= () => _ReadInput = true;
    }

    private void BuyBait()
    {
        int baitSelected = _UI.Options.ActiveOption;
        BaitInfo newBait = GameManager.instance.Settings.BaitsInGame[baitSelected];

        fishingSystem.Inv.AddBait(newBait);
        AudioManager.instance.PlaySfx("Choose");
        
    }

    private void CompleteInventory() 
    {
        InputManager._.StopReadAllInput();
        fishingSystem.Inv.OnBaitsComplete -= CompleteInventory;

        GameManager.instance.States.SetState(new GameplayState());
        AudioManager.instance.PlaySfx("Select");
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
