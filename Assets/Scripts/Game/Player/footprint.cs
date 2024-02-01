using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootprints : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private bool isMoving;

    void Start()
    {
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        if (trailRenderer == null)
        {
            Debug.LogError("TrailRenderer not found in children. Make sure you have a TrailRenderer component in the 'FootprintsRenderer' GameObject.");
        }
    }

    void Update()
    {
        // Ellen�rzi, hogy a karakter mozog-e
        isMoving = GetComponentInParent<Rigidbody2D>().velocity.magnitude > 0.1f;

        // Be�ll�tja a l�bnyomok akt�v vagy inakt�v �llapot�t
        trailRenderer.emitting = isMoving;
    }
}
