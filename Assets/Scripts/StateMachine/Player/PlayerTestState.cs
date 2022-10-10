using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{

    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        // movement
        Vector3 movement = new Vector3();

        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;

        stateMachine.Controller.Move(movement * stateMachine.FreeLookMovementSpeed * deltaTime);

        // rotation
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            // if idle, play idle animation
            stateMachine.Animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);
            return;
        }

        // if moving, play run animation
        stateMachine.Animator.SetFloat("FreeLookSpeed", 1, 0.0f, deltaTime);
        stateMachine.transform.rotation = Quaternion.LookRotation(movement);

        //Debug.Log(stateMachine.InputReader.MovementValue);
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }

}
