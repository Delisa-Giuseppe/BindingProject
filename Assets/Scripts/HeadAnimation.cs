using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour {

    Animator anim;
    public GameObject bullet;
    public GameObject target;
    public float bulletVelocity;
    Vector2 speedBullet;
    Transform firePosition;
    const float GRAVITY_CONSTANT = 9.8f;

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
            speedBullet = Vector2.zero;
            
            Vector2 targetPosition = new Vector2(transform.position.x + 20, 0);
            Instantiate(target, targetPosition, Quaternion.identity);


            bullet.GetComponent<BulletControl>().speed = speedBullet;
            bullet.GetComponent<BulletControl>().target = target;
            bullet.GetComponent<BulletControl>().firePosition = firePosition;
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePosition.position, Quaternion.identity);
    }
}
