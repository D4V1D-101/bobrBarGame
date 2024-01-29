using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float speed;
    [SerializeField] private float rotationspeed;
    private Rigidbody2D _rb;
    private PlayerAwarness _playerAwarness;
    private Vector2 _targetDirection;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAwarness = GetComponent<PlayerAwarness>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardTarget();
        SetVelocity();

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
        if (_targetDirection ==Vector2.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward,_targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
        _rb.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rb.velocity = Vector2.zero;
        }
        else
        {
            _rb.velocity = transform.up * speed;
        }

    }
}
