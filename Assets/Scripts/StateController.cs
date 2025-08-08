using UnityEngine;

public class StateController : MonoBehaviour
{
    private State currentState;

    // Update is called once per frame
    void Update()
    {
        currentState?.OnStateUpdate();
    }

    public void SetState(State newState) 
    {
        if(newState == currentState) return;

        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();

        Debug.Log($"New State Initiated {newState}");
    }
}
