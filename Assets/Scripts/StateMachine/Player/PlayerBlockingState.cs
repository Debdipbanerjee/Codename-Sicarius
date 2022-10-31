using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockingState : PlayerBaseState
{
    private readonly int BlockHash = Animator.StringToHash("Block");

    private const float CrossFadeDuration = 0.0f;

    public PlayerBlockingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter Player Blocking state");
        stateMachine.Animator.CrossFadeInFixedTime(BlockHash, CrossFadeDuration);
        stateMachine.Health.SetInvulnerable(true);
        stateMachine.Shield.SetActive(true);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if (!stateMachine.InputReader.IsBlocking)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
            return;
        }

        if (stateMachine.Targeter.CurrentTarget == null)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Player Blocking state");
        stateMachine.Health.SetInvulnerable(false);
        stateMachine.Shield.SetActive(false);
    }
}
