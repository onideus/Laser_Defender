using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem hitEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var damageDealer = col.gameObject.GetComponent<DamageDealer>();

        if (damageDealer == null) return;
        TakeDamage(damageDealer.GetDamage());
        PlayHitEffect();
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

    private void PlayHitEffect()
    {
        if (hitEffect == null) return;
        var instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }
}
