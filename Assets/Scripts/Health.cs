using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var damageDealer = col.gameObject.GetComponent<DamageDealer>();

        if (damageDealer == null) return;
        TakeDamage(damageDealer.GetDamage());
        damageDealer.Hit();
    }
    
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
