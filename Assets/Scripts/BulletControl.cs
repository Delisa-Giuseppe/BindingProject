using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public float bulletVelocity;
    public float bulletRate;
    public float maxTravelDistance;

    Transform startPosition;
    Rigidbody2D bulletRB;

    private void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Vector2.Distance(startPosition.position, transform.position) > maxTravelDistance)
        {
            bulletRB.AddForce(Vector2.down);
            GameObject.FindGameObjectWithTag("TargetBullet").GetComponent<TargetControl>().follow = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            if (coll.gameObject.tag == "Enemy")
            {
                coll.gameObject.GetComponent<EnemyIA>().health = coll.gameObject.GetComponent<EnemyIA>().health - 1;
            }

            Destroy(gameObject);
        }
    }

    public Transform InitialPosition
    {
        set { startPosition = value; }
    }

}
