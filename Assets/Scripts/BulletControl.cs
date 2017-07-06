﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public float bulletVelocity;
    public float bulletRange;
    public float bulletRate;
    Rigidbody2D bulletRB;

    private void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
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

}
