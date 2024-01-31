using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController healthController;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    public void StartInvincibility(float duration)
    {
        StartCoroutine(InvicibilityCoroutine(duration));
    }

    private IEnumerator InvicibilityCoroutine(float duration)
    {
        healthController.invincibility = true;
        yield return new WaitForSeconds(duration);
        healthController.invincibility = false;
    }
}
