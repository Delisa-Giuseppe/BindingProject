using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public Vector2 speed;
    public GameObject target;
    public Transform firePosition;

    Rigidbody2D bulletRB;

	// Use this for initialization
	void Start () {
        bulletRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Debug.LogWarning(target.transform.position);
        //bulletRB.AddForce(speed);
        transform.position = Vector2.Lerp(firePosition.position, target.transform.position, 5 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //Destroy(target);
    }
}
