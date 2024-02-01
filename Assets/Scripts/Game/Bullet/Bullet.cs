using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMove>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.takeDamage(10);
            Destroy(gameObject);
        }
    }
}
