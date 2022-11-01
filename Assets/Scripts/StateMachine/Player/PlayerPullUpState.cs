using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPullUpState : PlayerBaseState
{
    private readonly int PullUpHash = Animator.StringToHash("PullUp");

    private const float CrossFadeDuration = 0.1f;

    private readonly Vector3 Offset = new Vector3(0, 0.5f, 1);

    public PlayerPullUpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter Player Pullup state");
        stateMachine.Animator.CrossFadeInFixedTime(PullUpHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            return;
        }

        stateMachine.Controller.enabled = false;
        stateMachine.transform.Translate(Offset, Space.Self);
        stateMachine.Controller.enabled = true;

        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine, false));
    }

    public override void Exit()
    {
        Debug.Log("Exit Player Pullup state");
        stateMachine.Controller.Move(Vector3.zero);
        stateMachine.ForceReceiver.Reset();
    }
}
