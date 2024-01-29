using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefrab;
    [SerializeField] private float _bulletSpeed;
    private bool _fireContinously;

    void Update()
    {
        if (_fireContinously) FireBullet();
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefrab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = _bulletSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinously = inputValue.isPressed;
    }
}
