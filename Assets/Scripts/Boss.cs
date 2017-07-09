using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public Transform target;
    public GameObject projectile;
    public Transform shootPoint;
    public float shootCd;
    float nextFire = 0;
    public float health = 100f;
	// Use this for initialization


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + shootCd;
            Fire();
        }
            
        if(health <= 50)
        {

        }
        
	}

    public void Fire()
    {
        //transform.LookAt(target);
        GameObject bulletInstance = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        GameObject bulletInstance1 = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = Vector3.up + (target.position - transform.position) * 1.5f;
		bulletInstance1.GetComponent<Rigidbody2D>().velocity = Vector3.right + (target.position - transform.position) * 1.5f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 10f;
        }
    }
}
