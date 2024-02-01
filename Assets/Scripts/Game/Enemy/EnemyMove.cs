using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationspeed;
    private Rigidbody2D _rb;
    private PlayerAwarness _playerAwarness;
    private Vector2 _targetDirection;

    [SerializeField] private float idleTime = 2f; // Idõ, amíg az enemy random irányban mozog

    // További változók
    private bool isIdle = false;
    private float idleTimer = 0f;

    [SerializeField] private float maxChaseDistance = 5f; // Maximális távolság, amelyen belül az enemy követi a játékost

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAwarness = GetComponent<PlayerAwarness>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();

        if (_playerAwarness.AwareOfPlayer)
        {
            // Ha érzékeljük a játékost, keressük és kövessük
            RotateTowardTarget();
            SetVelocity();
        }
        else
        {
            // Ha nem érzékeljük a játékost, mozogjunk random irányban
            MoveRandomly();
        }
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarness.AwareOfPlayer)
        {
            _targetDirection = _playerAwarness.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, _playerAwarness.transform.position);

        if (distanceToPlayer <= maxChaseDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _targetDirection);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rb.velocity = Vector2.zero;
        }
        else
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _playerAwarness.transform.position);

            if (distanceToPlayer <= maxChaseDistance)
            {
                _rb.velocity = transform.up * speed;
            }
            else
            {
                _rb.velocity = Vector2.zero; // Ne mozogjon, ha a játékos túl messze van
            }
        }
    }

    private void MoveRandomly()
    {
        if (!isIdle)
        {
            idleTimer += Time.fixedDeltaTime;
            if (idleTimer >= idleTime)
            {
                isIdle = true;
                idleTimer = 0f;
            }
        }
        else
        {
            // Random irány generálása
            float randomAngle = Random.Range(0f, 360f);
            Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

            // Forgatás beállítása
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, randomDirection);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
            transform.rotation = rotation;

            // Rigidbody2D mozgatása
            _rb.velocity = transform.up * speed;
        }
    }
}
