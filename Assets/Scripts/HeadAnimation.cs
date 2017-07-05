using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour {

    Animator anim;
    Transform firePosition;
    Rigidbody2D playerRB;
    float nextFire = 0.0F;
    public GameObject bullet;
    public float bulletVelocity;
    public float bulletRange;
    public float bulletRate;
    float previousH = 0;
    float previousV = 0;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        firePosition = transform.FindChild("FireBullet").transform;
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

        anim.SetBool("isShooting", shooting);
        anim.SetBool("isMoving", moving);

        float speedPlayerX = playerRB.velocity.x != 0 ? playerRB.velocity.x : 0;
        float speedPlayerY = playerRB.velocity.y != 0 ? playerRB.velocity.y : 0;
        float xSpeed = bulletVelocity + speedPlayerX;//Mathf.Abs(maxSpeed * Mathf.Cos(throwAngle));
        float ySpeed = bulletVelocity + speedPlayerY;// Mathf.Abs(maxSpeed * Mathf.Sin(throwAngle));

        if (h > 0)
        {
            ySpeed = bulletRange;
        }
        if (h < 0)
        {
            xSpeed = -xSpeed;
            ySpeed = bulletRange;
        }
        else if (v > 0)
        {
            xSpeed = 0;
        }
        else if (v < 0 || (h == 0 && v == 0))
        {
            xSpeed = 0;
            ySpeed = -bulletRange;
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
                Fire(xSpeed, ySpeed);
            }
        }
        else
        {
            anim.SetFloat("movementHorizontal", previousH);
            anim.SetFloat("movementVertical", previousV);
        }


    }

    void Fire(float xSpeed, float ySpeed)
    {
        GameObject bulletInstance = Instantiate(bullet, firePosition.position, Quaternion.identity) as GameObject;

        Rigidbody2D bulletRB = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(xSpeed, ySpeed);
    }
}
