using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour {

    Animator anim;
    Transform firePosition;
    Transform fireShadow;
    Rigidbody2D playerRB;
    float nextFire = 0.0F;
    public GameObject bullet;
    public GameObject target;
    float previousH = 0;
    float previousV = 0;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        firePosition = transform.FindChild("FireBullet").transform;
        fireShadow = transform.FindChild("FireShadow").transform;
    }

    // Update is called once per frame
    void Update() {
        playerRB = GetComponentInParent<Rigidbody2D>();
        float h = Input.GetAxisRaw("Horizontal2");
        float v = Input.GetAxisRaw("Vertical2");
        float h1 = Input.GetAxisRaw("Horizontal");
        float v1 = Input.GetAxisRaw("Vertical");

        bool shooting = h != 0f || v != 0f;
        bool moving = h1 != 0f || v1 != 0f;
        bool isShootingUp = false;

        anim.SetBool("isShooting", shooting);
        anim.SetBool("isMoving", moving);

        float bulletVelocity = bullet.GetComponent<BulletControl>().bulletVelocity;
        float bulletRate = bullet.GetComponent<BulletControl>().bulletRate;

        float speedPlayerX = playerRB.velocity.x != 0 ? playerRB.velocity.x : 0;
        float speedPlayerY = playerRB.velocity.y != 0 ? playerRB.velocity.y : 0;

        Vector2 speed = Vector2.zero;

        if (h > 0)
        {
            speed = Vector2.right * bulletVelocity;
        }
        if (h < 0)
        {
            speed = Vector2.left * bulletVelocity;
        }
        else if (v > 0)
        {
            speed = Vector2.up * bulletVelocity;
            isShootingUp = true;

        }
        else if (v < 0 || (h == 0 && v == 0))
        {
            speed = Vector2.down * bulletVelocity;
        }

        if(moving)
        {
            previousH = h1;
            previousV = v1;
            anim.SetFloat("movementHorizontal", h1);
            anim.SetFloat("movementVertical", v1);
        }
        else
        {
            anim.SetFloat("movementHorizontal", previousH);
            anim.SetFloat("movementVertical", previousV);
        }

        if (shooting)
        {
            previousH = h;
            previousV = v;
            anim.SetFloat("speedHorizontal", h);
            anim.SetFloat("speedVertical", v);
            if(Time.time > nextFire)
            {
                nextFire = Time.time + bulletRate;
                Fire(speed, isShootingUp);
            }
        }
        else
        {
            anim.SetFloat("movementHorizontal", previousH);
            anim.SetFloat("movementVertical", previousV);
        }


    }

    void Fire(Vector2 speed, bool isShootingUp)
    {
        GameObject bulletInstance = Instantiate(bullet, firePosition.position, Quaternion.identity) as GameObject;
        GameObject targetInstance = Instantiate(target, fireShadow.position, Quaternion.identity) as GameObject;
        targetInstance.GetComponent<TargetControl>().BulletFollow = bulletInstance;

        Rigidbody2D bulletRB = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRB.velocity = speed;
        bulletInstance.GetComponent<BulletControl>().InitialPosition = firePosition;
        if (isShootingUp)
        {
            bulletInstance.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }
}
