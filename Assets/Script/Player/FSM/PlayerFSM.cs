using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType 
{
    Walking,
    GettingHit,
    ShowingInfo,
    Death,
}

public class PlayerFSM : MonoBehaviour
{

    public StateType startStateType;

    private IState currentState;
    private Dictionary<StateType, IState> stateList;
    private StateType currentStateType;

    void Awake()
    {
        stateList = new Dictionary<StateType, IState>();

        stateList.Add(StateType.Walking, new WalkingState(this, this.gameObject));
        stateList.Add(StateType.GettingHit, new GettingHitState(this, this.gameObject));
        stateList.Add(StateType.ShowingInfo, new ShowingInfoState(this, this.gameObject));
        stateList.Add(StateType.Death, new DeathState(this, this.gameObject));

        //initialize the current state
        currentState = stateList[startStateType];
        currentStateType = startStateType;
        currentState.OnEnter();
    }

    void Update()
    {
        currentState.OnUpdate();
    }

    public void SwitchState(StateType switchState) 
    {
        currentState.OnExit();
        currentState = stateList[switchState];
        currentStateType = switchState;
        currentState.OnEnter();
    }

    public StateType GetCurrentState() 
    {
        return currentStateType;
    }

    public void ApplyImpulse(Vector3 impulse, ForceMode forceMode, float affectTime)
    {
        StartCoroutine(ImpulseCoroutine(impulse, forceMode, affectTime));
    }

    private IEnumerator ImpulseCoroutine(Vector3 impulse, ForceMode forceMode, float affectTime) 
    {
        StateType origin = currentStateType;

        SwitchState(StateType.GettingHit);
        GetComponent<Rigidbody>().AddForce(impulse, forceMode);

        yield return new WaitForSeconds(affectTime);

        SwitchState(origin);
    }

    public void GameOver() 
    {
        SwitchState(StateType.Death);
        currentState.OnExit();
    }

}
