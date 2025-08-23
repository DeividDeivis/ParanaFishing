using UnityEngine;
using System.Collections;

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
    }

    public override void OnInteractTap()
    {
        fishingSystem.PullFishingRod();
    }

    public override void OnLeftTap()
    {
        // Go to menu
        _ui.GetComponent<FishingGameUI>().HideMessages();
        GameManager.instance.States.SetState(new MenuState());
    }

    public override void OnRightTap()
    {
        // Continue fishing
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
}
