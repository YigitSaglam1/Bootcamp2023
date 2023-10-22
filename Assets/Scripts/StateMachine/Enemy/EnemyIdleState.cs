using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine){}

    private readonly int EnemyLocomotionBlendTreeHash = Animator.StringToHash("EnemyLocomotion");
    private readonly int EnemySpeedHash = Animator.StringToHash("EnemySpeed");
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(EnemyLocomotionBlendTreeHash, CrossFadeDuration);
        
    }
    public override void Tick(float deltaTime)
    {
        if (IsInChaseRange())
        {
            Debug.Log("In Range");
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
            return;
        }

        stateMachine.animator.SetFloat(EnemySpeedHash, 0, AnimatorDampTime, deltaTime);
    }
    public override void Exit()
    {
        
    }


}
