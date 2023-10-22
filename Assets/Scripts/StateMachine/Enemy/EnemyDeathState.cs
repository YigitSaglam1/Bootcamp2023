using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    private readonly int EnemyDieHash = Animator.StringToHash("EnemyDie");
    private const float CrossFadeDuration = 0.1f;


    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        Drop();
        stateMachine.animator.CrossFadeInFixedTime(EnemyDieHash, CrossFadeDuration);

    }
    public override void Tick(float deltaTime) { }
    
    public override void Exit() { }
    private void Drop()
    {
        int rng = Random.Range(3, 11);
        for (int i = 0; i < rng; i++)
        {
            int die1 = Random.Range(-3, 4);
            int die2 = Random.Range(-3, 4);
            // end locations
            float locRngX = die1 + stateMachine.transform.position.x;
            float locRngZ = die2 + stateMachine.transform.position.z;
            // beginning location
            var coin = GameObject.Instantiate(stateMachine.Coin,
                new Vector3(stateMachine.transform.position.x
                , stateMachine.transform.position.y, stateMachine.transform.position.z),
                Quaternion.identity);

            DropMovement drop = coin.GetComponent<DropMovement>();
            drop.AddForce(new Vector3(die1, 3, die2), new Vector3(locRngX, stateMachine.transform.position.y, locRngZ));
        }
        int rngM = Random.Range(1, 4);
        for (int i = 0; i < rngM; i++)
        {
            int die1 = Random.Range(-4, 5);
            int die2 = Random.Range(-4, 5);
            // end locations
            float locRngX = die1 + stateMachine.transform.position.x;
            float locRngZ = die2 + stateMachine.transform.position.z;
            var material = GameObject.Instantiate(stateMachine.CommonLoot,
                new Vector3(stateMachine.transform.position.x
                , stateMachine.transform.position.y, stateMachine.transform.position.z),
                Quaternion.identity);

            DropMovement drop = material.GetComponent<DropMovement>();
            drop.AddForce(new Vector3(die1, 4, die2), new Vector3(locRngX, stateMachine.transform.position.y, locRngZ));
        }

    }

}
