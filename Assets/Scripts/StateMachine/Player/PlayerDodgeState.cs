using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : PlayerBaseState
{
    public PlayerDodgeState(PlayerStateMachine stateMachine) : base(stateMachine){}

    private float timer = 0f;
    public override void Enter()
    {
        Debug.Log("Enter");
        stateMachine.InputHandler.dodgeEvent += OnJump;
    }
    public override void Tick(float deltaTime)
    {
        timer += deltaTime;
        Debug.Log(timer);
    }
    public override void Exit()
    {
        Debug.Log("Exit");
        stateMachine.InputHandler.dodgeEvent -= OnJump;
    }
    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerDodgeState(stateMachine));
    }


}
