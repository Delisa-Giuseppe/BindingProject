using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : EnemyIA {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent <Rigidbody2D> ();
		rb.AddForce (new Vector2 (100f, -100f));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
