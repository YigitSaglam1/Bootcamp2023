using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float Health = 50f;
    public Action<Target> dieEvent;

    public void TakeDamage(float damageAmmount)
    {
        Health -= damageAmmount;
        Debug.Log(Health);

        if (Health <= 0)
        {
            dieEvent?.Invoke(this);
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
