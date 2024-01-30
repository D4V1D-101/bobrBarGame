using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maximumHealth;

    public float remainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    public Boolean invincibility { get; set; }

    public UnityEvent onDied;

    public UnityEvent onDamaged;

    public void takeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }

        if (invincibility)
        {
            return;
        }

        currentHealth -= damageAmount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0) 
        {
            onDied.Invoke();
        }
        else
        {
            onDamaged.Invoke();
        }
    }

    public void addHealth(float amountToAdd)
    {
        if (currentHealth == maximumHealth) 
        {
            return;
        }
        currentHealth += amountToAdd;
        if (currentHealth > maximumHealth) 
        { 
            currentHealth = maximumHealth;
        }
    }
}
