using DG.Tweening;
using System.Collections;
using UnityEngine;

public class FishingSubState : SubState
{
    private FishingSystem fishingSystem;
    private bool fishingComplete = false;

    public FishingSubState(UISection ui) : base(ui)
    {
        _ui = ui;
    }

    public override void SetSubState()
    {
        fishingSystem = GameObject.FindFirstObjectByType<FishingSystem>();
        _ui.GetComponent<FishingGameUI>().SetPowerBar(1);

        fishingSystem.FishingComplete += FishingResult;
        fishingSystem.FishingProgress += FishingProgress;

        fishingSystem.CatchFishMiniGame();

        AudioManager.instance.SetMusicState(2);

        fishingSystem.Inv.OnFishComplete += CompleteInventory;
    }

    public override void OnInteractTap()
    {
        fishingSystem.PullFishingRod();
    }

    public override void OnLeftTap()
    {
        // Save Fish
        fishingSystem.Inv.AddFish(fishingSystem.fishCatched);
        fishingSystem.ResetFish();
        _ui.GetComponent<FishingGameUI>().HideMessages();
        if(!fishingSystem.Inv.Complete())
            NextSubState.Invoke(new MoveSubState(_ui));
    }

    public override void OnRightTap()
    {
        // Drop Fish
        fishingSystem.ResetFish();
        _ui.GetComponent<FishingGameUI>().HideMessages();
        NextSubState.Invoke(new MoveSubState(_ui));
    }

    private void FishingProgress(float strainValue) 
    {
        _ui.GetComponent<FishingGameUI>().SetPowerBar(strainValue);
    }

    private void FishingResult(bool success) 
    {
        fishingSystem.FishingComplete -= FishingResult;
        fishingSystem.FishingProgress -= FishingProgress;

        if (success)
        {
            Debug.Log("WIN");
            var fishGroup = GameObject.FindFirstObjectByType<FishGroupController>();
            var fish = fishGroup.GetRandomFish();

            fishingSystem.fishCatched = fish;
            _ui.GetComponent<FishingGameUI>().ShowFishInfo(fish);

            AudioManager.instance.SetMusicState(3);
        }
        else 
        {
            Debug.Log("LOSE");
            _ui.GetComponent<FishingGameUI>().ShowFailed();

            AudioManager.instance.SetMusicState(4);
        }

        fishingComplete = true;
    }

    public void CompleteInventory() 
    {
        fishingSystem.ResetFish();
        _ui.GetComponent<FishingGameUI>().HideMessages();
        InputManager._.StopReadAllInput();
        GameManager.instance.States.SetState(new ScoreState());
        AudioManager.instance.PlaySfx("Select");
    }
}
