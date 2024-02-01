using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private ICollectibleBehavior collectibleBehavior;

    private void Awake()
    {
        collectibleBehavior = GetComponent<ICollectibleBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();
        if (player != null )
        {
            collectibleBehavior.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
