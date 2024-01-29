using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rb;
    private Vector2 _movementInput;
    private Vector2 _smoothMovementInput;
    private Vector2 _movementInoutSmoothVelocity;
    [SerializeField] private float speed;
    [SerializeField] private float Rotationspeed;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        setPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void setPlayerVelocity()
    {
        _smoothMovementInput = Vector2.SmoothDamp(
                    _smoothMovementInput,
                    _movementInput,
                    ref _movementInoutSmoothVelocity,
                    0.1f);

        _rb.velocity = _smoothMovementInput * speed;
    }
    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Rotationspeed * Time.deltaTime);

            _rb.MoveRotation(rotation);
        }
    }
    private void OnMove(InputValue inputValue)
    {
       _movementInput = inputValue.Get<Vector2>();
    }
}
