using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float Health;
    public Action<Target> dieEvent;
    public event Action OnDie;
    public GameObject enemy;
    public HealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }
    private void Start()
    {
        Health = MaxHealth;
        healthBar.UpdateHealthBar(Health, MaxHealth);
    }
    public void TakeDamage(float damageAmmount)
    {
        if (Health == 0) { return; }

        Health -= damageAmmount;
        healthBar.UpdateHealthBar(Health, MaxHealth);

        if (Health <= 0)
        {
            OnDie?.Invoke();
            dieEvent?.Invoke(this);
            Destroy(enemy,5);
        }
    }

}
