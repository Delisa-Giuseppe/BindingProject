using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour {

    public float speed;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Enemy")
        {
            if (coll.gameObject.tag == "Player")
            {
                HUDManager manager = GameObject.Find("HUD").GetComponent<HUDManager>();
                manager.ModifyHealth(5);
            }

            Destroy(gameObject);
        }
                
    }
}
