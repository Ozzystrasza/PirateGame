using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject explosion;

    float damage;

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (TryGetComponent<Ship>(out Ship ship))
            ship.GetHit(damage);

        Explosion();
    }

    void Explosion()
    {
        explosion.SetActive(true);

        Destroy(gameObject, 0.5f);
    }

    public void SetProjectileDamage(float damage)
    {
        this.damage = damage;
    }


}
