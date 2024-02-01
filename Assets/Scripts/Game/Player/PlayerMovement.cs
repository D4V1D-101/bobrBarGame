using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    private Animator animatior;
    private bool isJoystickBeingUsed = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animatior = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isJoystickBeingUsed)
        {
            move.x = joystick.Horizontal;
            move.y = joystick.Vertical;

            float hAxis = move.x;
            float vAxis = move.y;
            float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, 0f, -zAxis);

        }
    }

    private void SetAnimation()
    {
        bool isMoving = move != Vector2.zero;
        animatior.SetBool("isMoving",isMoving);
    
    }



    private void FixedUpdate()
    {
        if (isJoystickBeingUsed)
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
        SetAnimation();
    }

    public void SetIsJoystickBeingUsed(bool value)
    {
        isJoystickBeingUsed = value;
    }
}