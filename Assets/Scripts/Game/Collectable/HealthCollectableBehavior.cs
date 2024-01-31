using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectableBehavior : MonoBehaviour, ICollectibleBehavior
{
    [SerializeField]
    private float healthAmount;

    public void OnCollected(GameObject player)
    {
        player.GetComponent<HealthController>().addHealth(healthAmount);
    }
}
