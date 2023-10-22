using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int EnemyAttackHash = Animator.StringToHash("EnemyAttack");
    private const float CrossFadeDuration = 0.1f;
    


    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) {   }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(EnemyAttackHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        if (!IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        
    }


}
