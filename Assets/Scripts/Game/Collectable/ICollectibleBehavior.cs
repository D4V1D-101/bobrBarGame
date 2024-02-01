using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectibleBehavior
{
    void OnCollected(GameObject player);
}
