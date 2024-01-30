using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayarDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float duration;

    private InvincibilityController invincibilityController;

    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();
    }

    public void StartInvincibility()
    {
        invincibilityController.StartInvincibility(duration);
    }
}
