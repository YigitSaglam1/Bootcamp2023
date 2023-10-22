using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotionState : PlayerBaseState
{
    public PlayerLocomotionState(PlayerStateMachine stateMachine) : base(stateMachine){}
    private Quaternion targetRotation;
    private float rotationSpeed = 450f ;
    private readonly int LocomotionBlendTreeHash = Animator.StringToHash("LocomotionBlendTree");
    private const float crossFadeDuration = 0.1f;

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(LocomotionBlendTreeHash, crossFadeDuration);
        stateMachine.AnimationDetection.AnimationStart();
        stateMachine.InputHandler.reloadEvent += OnReload;
        stateMachine.DamageHandler.OnDie += OnDieHandler;
        
    }
    public override void Tick(float deltaTime)
    {
        
        if (stateMachine.InputHandler.movementValue == Vector2.zero)
        {


            //Raycasting();
            FaceMouseDirection();

            stateMachine.animator.SetFloat("LocomotionForwardSpeed", 0, 0.1f, deltaTime);
            stateMachine.animator.SetFloat("LocomotionRightSpeed", 0, 0.1f, deltaTime);
            return;


        }
        FaceMouseDirection();
        Move();
        //Raycasting();


        stateMachine.animator.SetFloat("LocomotionForwardSpeed", stateMachine.InputHandler.movementForwardValue, 0.1f, deltaTime);
        stateMachine.animator.SetFloat("LocomotionRightSpeed", stateMachine.InputHandler.movementRightValue, 0.1f, deltaTime);

        
    }
    public override void Exit()
    {
        stateMachine.InputHandler.reloadEvent -= OnReload;
        stateMachine.DamageHandler.OnDie -= OnDieHandler;
    }

    private void OnDieHandler()
    {
        stateMachine.SwitchState(new PlayerDeathState(stateMachine));
    }
    private void OnReload()
    {
        stateMachine.SwitchState(new PlayerReloadState(stateMachine));
    }

    private void FaceMouseDirection()
    {
        float yOffset = stateMachine.MainCamera.transform.position.y - stateMachine.transform.position.y;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = stateMachine.MainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, yOffset));
        targetRotation = Quaternion.LookRotation(mousePosition - new Vector3(stateMachine.transform.position.x, 0, stateMachine.transform.position.z));
        stateMachine.transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(stateMachine.transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
    }
    private void Move()
    {
        float moveX = stateMachine.InputHandler.movementForwardValue;
        float moveY = stateMachine.InputHandler.movementRightValue;
        Vector3 move = stateMachine.transform.forward * moveX + stateMachine.transform.right * moveY;
        stateMachine.CharacterController.Move(move * stateMachine.RiffleMovementSpeed * Time.deltaTime);
    }
    //private void Raycasting()
    //{
    //    RaycastHit hit;
    //    Ray ray = new Ray(stateMachine.RiffleTip.transform.position, stateMachine.transform.TransformDirection(Vector3.forward));

    //    if (Physics.Raycast(ray, out hit, 20f))
    //    {
    //        Debug.DrawRay(stateMachine.RiffleTip.transform.position, stateMachine.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
    //    }
    //    else
    //    {
    //        Debug.DrawRay(stateMachine.RiffleTip.transform.position, stateMachine.transform.TransformDirection(Vector3.forward) * 20f, Color.green);
    //    }
    //}
}
