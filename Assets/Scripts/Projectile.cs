using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public Transform target;
	public Rigidbody2D myRigidBody;
    
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        // myRigidBody.velocity = (target.position - transform.position) * 1.5f;
        // myRigidBody.velocity = target.position * 1.5f* Time.deltaTime;
       	 Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
    }

    private void Update()
    {
       
    }
}
