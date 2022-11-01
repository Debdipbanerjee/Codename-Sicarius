using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter Enemy Dead state");
        stateMachine.Ragdoll.ToggleRagdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        GameObject.Destroy(stateMachine.Target);

        Vector3 SpawnPosition = new Vector3(stateMachine.transform.position.x, stateMachine.transform.position.y + stateMachine.SpawnHeight, stateMachine.transform.position.z);
        Transform.Instantiate(stateMachine.Item, SpawnPosition, stateMachine.transform.rotation);

    }

    public override void Tick(float deltaTime)
    {
        
    }

    public override void Exit()
    {
        Debug.Log("Exit Enemy Dead state");
    }

}
