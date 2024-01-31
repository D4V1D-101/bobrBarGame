using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarness : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]private float playerAwarnessDistance;
    [SerializeField] private AudioSource awarnessSound;

    private Transform _player;

    // Start is called before the first frame update
    private void Awake()
    {
        _player = FindAnyObjectByType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        if (enemyToPlayerVector.magnitude <= playerAwarnessDistance)
        {
            AwareOfPlayer = true;
            awarnessSound.Play();
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
