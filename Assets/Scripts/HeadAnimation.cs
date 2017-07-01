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

    private void Update()
    {
        speedBullet.x = 0;
        speedBullet.y = 0;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("HeadIdle") || anim.GetCurrentAnimatorStateInfo(0).IsName("HeadDown"))
        {
            speedBullet.y = -bulletVelocity;
            
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsName("HeadUp"))
        {
            speedBullet.y = bulletVelocity;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("HeadRight"))
        {
            speedBullet.x = bulletVelocity;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("HeadLeft"))
        {
            speedBullet.x = -bulletVelocity;
        }
        bullet.GetComponent<BulletControl>().speed = speedBullet;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    // Update is called once per frame
    void LateUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        bool walking = h != 0f || v != 0f;
        anim.SetBool("isWalking", walking);
        if(walking)
        {
            anim.SetFloat("speedHorizontal", h);
            anim.SetFloat("speedVertical", v);
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePosition.position, Quaternion.identity);
    }
}
