using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour {

    Animator anim;
    public GameObject bullet;
    public float bulletVelocity;
    Vector2 speedBullet;
    Transform firePosition;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        firePosition = transform.FindChild("FireBullet").transform;
    }

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        bool walking = h != 0f || v != 0f;
        anim.SetBool("isWalking", walking);
        if(walking)
        {
            anim.SetFloat("speedHorizontal", h);
            anim.SetFloat("speedVertical", v);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speedBullet.x = 0;
            speedBullet.y = 0;

            if (h > 0)
            {
                speedBullet.x = bulletVelocity;
            }
            else if (h < 0)
            {
                speedBullet.x = -bulletVelocity;
            }
            else if (v > 0)
            {
                speedBullet.y = bulletVelocity;
            }
            else if (v < 0)
            {
                speedBullet.y = -bulletVelocity;
            }
            else if (h == 0 && v == 0)
            {
                speedBullet.y = -bulletVelocity;
            }
            bullet.GetComponent<BulletControl>().speed = speedBullet;
            bullet.GetComponent<Rigidbody2D>().isKinematic = true;
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePosition.position, Quaternion.identity);
    }
}
