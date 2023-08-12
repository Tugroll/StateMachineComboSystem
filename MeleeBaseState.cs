using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    // How long this state should be active for before moving on
    public float duration;
    // Cached animator component
    protected Animator animator;
    // bool to check whether or not the next attack in the sequence should be played or not
    protected bool shouldCombo;
    // The attack index in the sequence of attacks
    protected int attackIndex;
    // Timing combo last pressing time
    protected float attackPressTime;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
        
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        attackPressTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            attackPressTime = .3f;
        }
        if (attackPressTime > 0)
        {
            shouldCombo = true;
        }
        else
            shouldCombo = false;
        
    }
    public override void OnExit()
    {
        base.OnExit();
        shouldCombo = false;
       
    }
}
