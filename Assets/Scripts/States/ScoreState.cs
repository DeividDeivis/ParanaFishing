using UnityEngine;

public class ScoreState : State, IState
{
    int score = 0;

    public override void OnStateEnter()
    {
        _UI = UIController.instance.GetUI("Score");
        _UI.OnSectionIN(true);

        InputManager._.StartReadInput("Interact", BackToMenu);

        AudioManager.instance.SetMusicState(0);

        foreach (var fish in FishingSystem.instance.Inv.FishInv) 
        {
            score += fish.m_Points;
        }

        _UI.GetComponent<ScoreMenuUI>().SetScore(score);
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateExit()
    {
        _UI.OnSectionOUT();
    }

    private void BackToMenu()
    {
        InputManager._.StopReadAllInput();
        GameManager.instance.States.SetState(new MenuState()); 
        AudioManager.instance.PlaySfx("Select");
    }
}
