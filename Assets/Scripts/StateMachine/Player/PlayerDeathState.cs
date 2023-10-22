using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    private readonly int DieHash = Animator.StringToHash("Death");
    private const float CrossFadeDuration = 0.1f;

    public PlayerDeathState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(DieHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.AnimationDetection.IsAnimationEnd())
        {
            stateMachine.pauseMenuScript.HandleDie();
        }
    }
    public override void Exit(){}


}
