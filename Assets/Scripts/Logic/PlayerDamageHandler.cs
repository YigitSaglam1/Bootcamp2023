using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    private float maxHealth = 100f;
    private float damageTaken = 10f;
    private float health;
    public event Action OnDie;
    public GameObject player;
    public HealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Weapon"))
        {
            Debug.Log("DamageTaken !");
            GetHit();
        }
    }
    private void GetHit() 
    {
        if (health == 0) { return; }
        health -= damageTaken;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            OnDie?.Invoke();

        }
    }
}
