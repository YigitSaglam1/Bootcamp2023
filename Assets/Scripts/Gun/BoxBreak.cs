using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxBreak : MonoBehaviour
{
    private float Health = 10f;
    public GameObject box;
    public GameObject Coin;
    public GameObject CommonMaterial;
    private readonly int BangHash = Animator.StringToHash("Bang");
    private const float CrossFadeDuration = 0.1f;
    [field: SerializeField] public Animator animator { get; private set; }
    public void TakeDamage(float damageAmmount)
    {
        if (Health == 0) { return; }

        Health -= damageAmmount;
        Debug.Log(Health);

        if (Health <= 0)
        {
            animator.CrossFadeInFixedTime(BangHash, CrossFadeDuration);
            Drop();
            Destroy(box, 2);
        }
    }
    private void Drop()
    {
        int rng = Random.Range(3, 11);
        for (int i = 0; i < rng; i++)
        {
            int die1 = Random.Range(-3, 4);
            int die2 = Random.Range(-3, 4);
            // end locations
            float locRngX = die1 + transform.position.x;
            float locRngZ = die2 + transform.position.z;
            // beginning location
            var coin = GameObject.Instantiate(Coin,
                new Vector3(transform.position.x
                , transform.position.y, transform.position.z),
                Quaternion.identity);

            DropMovement drop = coin.GetComponent<DropMovement>();
            drop.AddForce(new Vector3(die1, 3, die2), new Vector3(locRngX, transform.position.y, locRngZ));
        }
        int rngM = Random.Range(1, 4);
        for (int i = 0; i < rngM; i++)
        {
            int die1 = Random.Range(-4, 5);
            int die2 = Random.Range(-4, 5);
            // end locations
            float locRngX = die1 + transform.position.x;
            float locRngZ = die2 + transform.position.z;
            var material = GameObject.Instantiate(CommonMaterial,
                new Vector3(transform.position.x
                , transform.position.y, transform.position.z),
                Quaternion.identity);

            DropMovement drop = material.GetComponent<DropMovement>();
            drop.AddForce(new Vector3(die1, 4, die2), new Vector3(locRngX, transform.position.y, locRngZ));
        }

    }
}
