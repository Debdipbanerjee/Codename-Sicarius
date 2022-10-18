using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    public PlayerAttackingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter Attack State");
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
        Debug.Log("Exit Attack State");
    }
}
