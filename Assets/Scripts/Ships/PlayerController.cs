using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Ship
{
    [SerializeField] float fireCoolDown;
    [SerializeField] Projectile cannonBall;
    [SerializeField] Transform frontalFirePosition;
    [SerializeField] List<Transform> sideFirePositions;

    float sideFireOffset = -0.25f;

    bool canControlShip;
    bool canFire = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControlShip)
        {
            Move();
            Rotate();

            FrontalFire();
            SideFire();
        }
    }

    void FrontalFire()
    {
        if (canFire && Input.GetKeyDown(KeyCode.Space))
        {
            canFire = false;
            Invoke(nameof(EnableCannonFire), fireCoolDown);

            Instantiate(cannonBall, frontalFirePosition.position, transform.rotation).SetProjectileDamage(damage);
        }
    }

    void SideFire()
    {
        if (canFire && Input.GetKeyDown(KeyCode.Return))
        {
            canFire = false;
            Invoke(nameof(EnableCannonFire), fireCoolDown);

            foreach (var sideFirePosition in sideFirePositions)
            {
                Instantiate(cannonBall, sideFirePosition.position, sideFirePosition.rotation).SetProjectileDamage(damage);
            }
        }
    }

    void EnableCannonFire()
    {
        canFire = true;
    }

    public void EnableControlOfShip()
    {
        canControlShip = true;
    }

    public void DisableControlOfShip()
    {
        canControlShip = false;
    }

    protected override void Move()
    {
        if (Input.GetAxis("Vertical") > 0)
            transform.position += -transform.up * speed * Time.deltaTime;
    }

    protected override void Rotate()
    {
        transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
    }

    protected override void DestroyShip()
    {
        if (canControlShip)
            GameManager.instance.GameOver();

        base.DestroyShip();
    }
}
