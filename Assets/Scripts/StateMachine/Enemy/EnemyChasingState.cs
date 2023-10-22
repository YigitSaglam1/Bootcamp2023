using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private readonly int EnemyLocomotionBlendTreeHash = Animator.StringToHash("EnemyLocomotion");
    private readonly int EnemySpeedHash = Animator.StringToHash("EnemySpeed");
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;


    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(EnemyLocomotionBlendTreeHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        if (!IsInChaseRange())
        {
            Debug.Log("Not In Range");
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
            return;
        }
        FaceToPlayer();
        MoveToPlayer(deltaTime);
        stateMachine.animator.SetFloat(EnemySpeedHash, 1, AnimatorDampTime, deltaTime);
    }
    public override void Exit()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }

    private void MoveToPlayer(float deltaTime)
    {
        stateMachine.Agent.destination = stateMachine.Player.transform.position;
        Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.EnemyMovementSpeed, deltaTime);
        stateMachine.Agent.velocity = stateMachine.EnemyController.velocity;
        
    }

}
