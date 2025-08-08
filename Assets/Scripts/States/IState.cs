using UnityEngine;

public interface IState 
{
    public void OnStateEnter();
    public void OnStateUpdate();
    public void OnStateExit();
}

public abstract class State 
{
    protected UISection _UI;
    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();
}
