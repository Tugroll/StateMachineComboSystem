using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FadeOfShape.Weapons;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    State nextState;
    private State mainStateType;
    public string weaponName;
    public StatsUpgrade PlayerStats;
    public WeaponTypeAbstract weaponType;


    private void Update()
    {
        
        if (nextState != null)
        {
            SetState(nextState);
        }

        if (currentState != null)
            currentState.OnUpdate();
    }
    private void LateUpdate()
    {
        if (currentState != null)
            currentState.OnLateUpdate();
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.OnFixedUpdate();
    }
    private void SetState(State _newState)
    {
        nextState = null;
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = _newState;
        currentState.OnEnter(this);
    }
    public void SetNextState(State _newState)
    {
        if (_newState != null)
        {
            nextState = _newState;
        }
    }
    public void SetNextStateToMain()
    {
        nextState = mainStateType;
    }
    private void OnValidate()
    {
        if (mainStateType == null)
        {
            mainStateType = new IdleComboState();
        }
    }
    private void Awake()
    {
       
        SetNextStateToMain();



    }
}
