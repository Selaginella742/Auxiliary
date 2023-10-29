using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateType 
{
    Walking,
    GettingHit,
    ShowingInfo,
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

}
