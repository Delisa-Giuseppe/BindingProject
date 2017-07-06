using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour {

    GameObject followBullet;
    public bool follow = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(followBullet != null)
        {
            if(follow)
            {
                transform.position = Vector2.MoveTowards(transform.position, transform.position + followBullet.transform.position, 0f);
                GetComponent<Rigidbody2D>().velocity = followBullet.GetComponent<Rigidbody2D>().velocity;
            }
        }
        else
        {
            Destroy(gameObject);
        }
	}

    public GameObject BulletFollow
    {
        set { followBullet = value; }
    }
}
