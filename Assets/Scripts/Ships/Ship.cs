using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ship : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] protected float rotateSpeed;

    [Header("Sprites")]
    [SerializeField] Sprite fullHealthSprite;
    [SerializeField] Sprite midHealthSprite;
    [SerializeField] Sprite lowHealthSprite;

    [Header("HealthBar")]
    [SerializeField] Image healthBar;

    [Header("Explosion")]
    [SerializeField] GameObject explosion;

    protected float health;
    float fullHealthThreshold = 0.7f;
    float midHealthThreshold = 0.4f;

    SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        health = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fullHealthSprite;
    }

    protected abstract void Move();
    protected abstract void Rotate();

    protected virtual void DestroyShip()
    {
        spriteRenderer.enabled = false;
        explosion.SetActive(true);

        Destroy(gameObject, 0.5f);
    }

    public void GetHit(float damage)
    {
        health -= damage;

        float healthPercentage = health / maxHealth;
        healthBar.fillAmount = healthPercentage;

        if (health <= 0)
            DestroyShip();
        else if (healthPercentage < midHealthThreshold)
            spriteRenderer.sprite = lowHealthSprite;
        else if (healthPercentage < fullHealthThreshold)
            spriteRenderer.sprite = midHealthSprite;
    }

    protected void LookAtTarget(Transform target)
    {
        Vector3 diff = target.position - transform.position;

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
    }
}
