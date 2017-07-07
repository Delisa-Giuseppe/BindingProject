using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : EnemyIA {

	public PhysicsMaterial2D bouncing;
	public GameObject enemyBullet;

	private Rigidbody2D rb;
	private Collider2D coll;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent <Rigidbody2D> ();
		coll = GetComponent <BoxCollider2D> ();
		rb.AddForce (new Vector2 (100f, -100f));

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnDestroy()
	{
		Sprite sprite = GetComponent <SpriteRenderer> ().sprite;

		if (sprite.name == "Spitfly")
		{

			for(int i = 0; i < 8; i++)
			{
				GameObject bulletInstance = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
				Rigidbody2D bulletRB = bulletInstance.GetComponent<Rigidbody2D>();
				float bulletSpeed = bulletInstance.GetComponent<EnemyBulletControl>().speed;
				switch (i)
				{
					case 0 :
						bulletRB.velocity = Vector2.up * bulletSpeed;
						break;
					case 1 :
						bulletRB.velocity = Vector2.right * bulletSpeed;
						break;
					case 2:
						bulletRB.velocity = Vector2.left * bulletSpeed;
						break;
					case 3:
						bulletRB.velocity = Vector2.down * bulletSpeed;
						break;
					case 4:
						bulletRB.velocity = new Vector2(bulletSpeed, bulletSpeed);
						break;
					case 5:
					bulletRB.velocity = new Vector2(-bulletSpeed, bulletSpeed);
						break;
					case 6:
					bulletRB.velocity = new Vector2(bulletSpeed, -bulletSpeed);
						break;
					case 7:
					bulletRB.velocity = new Vector2(-bulletSpeed, -bulletSpeed);
						break;
				}
			}
		}

	}
}
