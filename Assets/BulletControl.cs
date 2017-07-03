using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public Vector2 speed;

    Rigidbody2D bulletRB;

	// Use this for initialization
	void Start () {
        bulletRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        bulletRB.velocity = speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }
}
