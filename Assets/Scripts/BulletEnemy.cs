using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : EnemyIA {

    public GameObject enemyBullet;
    public float bulletRate;
    float nextFire = 0;

    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            Destroy(gameObject);
        }


        if (Time.time > nextFire)
        {
            nextFire = Time.time + bulletRate;
            Shoot();
        }
        else
        {
            anim.SetBool("IsShooting", false);
        }
    }

    private void Shoot()
    {
        anim.SetBool("IsShooting", true);
        for(int i = 0; i < 4; i++)
        {
            GameObject bulletInstance = Instantiate(enemyBullet, transform.GetChild(0).transform.position, Quaternion.identity) as GameObject;
            Rigidbody2D bulletRB = bulletInstance.GetComponent<Rigidbody2D>();
            float bulletSpeed = bulletInstance.GetComponent<EnemyBulletControl>().speed;
            switch (i)
            {
                case 0 :
                   bulletRB.velocity = Vector2.up * bulletSpeed;
                   break;
                case 1 :
                    bulletRB.velocity = Vector2.right * bulletSpeed;
                    break;
                case 2:
                    bulletRB.velocity = Vector2.left * bulletSpeed;
                    break;
                case 3:
                    bulletRB.velocity = Vector2.down * bulletSpeed;
                    break;
            }
        }
    }
}
