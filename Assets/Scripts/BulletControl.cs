using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public float bulletVelocity;
    public float bulletRate;
    public float maxTravelDistance;
    public GameObject tearSplash;

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
        if (coll.gameObject.tag == "Enemy")
        {
			coll.gameObject.GetComponent<EnemyIA> ().health--;
			if(coll.gameObject.GetComponent<EnemyIA> ().health <= 0)
			{
				Destroy (coll.gameObject);
			}

        }

        Destroy(gameObject);
        
    }

    public Transform InitialPosition
    {
        set { startPosition = value; }
    }

    private void OnDestroy()
    {
        GameObject tearSplashInstance = Instantiate(tearSplash, transform.position, Quaternion.identity) as GameObject;
        Destroy(tearSplashInstance, 1f);
    }

}
