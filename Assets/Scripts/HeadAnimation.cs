using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour {

    Animator anim;
    Transform firePosition;
    public GameObject bullet;
    public float bulletVelocity;
    public float bulletrange;
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        firePosition = transform.FindChild("FireBullet").transform;
    }

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxisRaw("Horizontal2");
        float v = Input.GetAxisRaw("Vertical2");
        bool walking = h != 0f || v != 0f;
        anim.SetBool("isWalking", walking);
        if(walking)
        {
            anim.SetFloat("speedHorizontal", h);
            anim.SetFloat("speedVertical", v);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            float xSpeed = bulletVelocity;//Mathf.Abs(maxSpeed * Mathf.Cos(throwAngle));
            float ySpeed = bulletVelocity;// Mathf.Abs(maxSpeed * Mathf.Sin(throwAngle));

            if (h > 0)
            {
                ySpeed = bulletrange;
            }
            if (h < 0)
            {
                xSpeed = -xSpeed;
                ySpeed = bulletrange;
            }
            else if (v > 0)
            {
                xSpeed = 0;
            }
            else if (v < 0 || (h == 0 && v == 0))
            {
                xSpeed = 0;
                ySpeed = -bulletrange;
            }
            
            Fire(xSpeed, ySpeed);
        }
    }

    void Fire(float xSpeed, float ySpeed)
    {
        GameObject bulletInstance = Instantiate(bullet, firePosition.position, Quaternion.identity) as GameObject;

        Rigidbody2D bulletRB = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(xSpeed, ySpeed);
    }
}
