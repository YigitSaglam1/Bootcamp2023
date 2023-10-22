using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReloadState : PlayerBaseState
{
    public PlayerReloadState(PlayerStateMachine stateMachine) : base(stateMachine){}
    private readonly int reloadHash = Animator.StringToHash("Reload");
    private const float crossFadeDuration = 0.1f;
    private bool isAnimationEnd;

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(reloadHash, crossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        isAnimationEnd = stateMachine.AnimationDetection.IsAnimationEnd();
        if (isAnimationEnd)
        {
            stateMachine.gunShootScript.ReloadAmmo();
            stateMachine.SwitchState(new PlayerLocomotionState(stateMachine));
        }
    }
    public override void Exit()
    {
        
    }
    
}
