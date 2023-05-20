using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float health;
    [SerializeField] private FloatingHealthbar healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.UpdateHealthBar(health, maxHealth);
    }

    public void TakeDamage(float damageAmout)
    {
        health -= damageAmout;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

    }
}
