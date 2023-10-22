using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected bool IsInChaseRange()
    {
        float distanceToPlayerSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return distanceToPlayerSqr <= (stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange);
    }
    protected bool IsInAttackRange()
    {
        float distanceToPlayerSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return distanceToPlayerSqr <= (stateMachine.AttackRange * stateMachine.AttackRange);
    }
    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.EnemyController.Move((motion + stateMachine.forceReceiver.Movement) * deltaTime);
    }
    protected void FaceToPlayer()
    {
        if(stateMachine.Player == null) { return; }

        Vector3 lookPosition = stateMachine.Player.transform.position - stateMachine.transform.position;
        lookPosition.y = 0;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPosition);
    }
}
