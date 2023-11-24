using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : Ship
{
    [SerializeField] Projectile cannonBall;
    [SerializeField] Transform frontalFirePosition;
    [SerializeField] float fireCoolDown;

    bool isInRange;
    bool canFire = true;
    bool canMove = true;
    bool isRotating;

    Transform target;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        FireGuns();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        canMove = false;
        isRotating = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            isInRange = false;
    }

    void FireGuns()
    {
        if (isInRange && canFire)
        {
            LookAtTarget(target);

            canFire = false;
            Invoke(nameof(EnableCannonFire), fireCoolDown);

            Instantiate(cannonBall, frontalFirePosition.position, transform.rotation).SetProjectileDamage(damage);
        }
    }

    void EnableCannonFire()
    {
        canFire = true;
    }

    protected override void Move()
    {
        if (canMove && !isInRange)
            transform.position += -transform.up * speed * Time.deltaTime;
    }

    protected override void Rotate()
    {
        if (isRotating && !isInRange)
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

            Invoke(nameof(StopRotating), 3);
        }
    }

    void StopRotating()
    {
        canMove = true;
        isRotating = false;
    }
}
