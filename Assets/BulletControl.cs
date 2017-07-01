using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public Vector2 speed;
    public float destroyDelay;

    Rigidbody2D bulletRB;

	// Use this for initialization
	void Start () {
        bulletRB = GetComponent<Rigidbody2D>();
        Destroy(gameObject, destroyDelay);
	}
	
	// Update is called once per frame
	void Update () {
        bulletRB.velocity = speed;
    }
}
