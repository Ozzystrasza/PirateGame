using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Ship
{
    Transform target;

    protected override void Start()
    {
        base.Start();

        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Ship>().GetHit(damage);

            DestroyShip();
        }
    }

    protected override void Move()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
    }

    protected override void Rotate()
    {
        LookAtTarget(target);
    }
}
