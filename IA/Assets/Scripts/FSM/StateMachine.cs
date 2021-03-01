
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State State;

    public void SetState(State state)
    {
        State = state;
        StartCoroutine(State.Start());
    }

    public void UpdateState()
    {
        StartCoroutine(State.Update());
    }
}
