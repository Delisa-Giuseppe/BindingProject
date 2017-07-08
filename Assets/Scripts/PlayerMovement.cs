using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Enemy")
        //{
        //    SpriteRenderer[] childsRenderer = GetComponentsInChildren<SpriteRenderer>();
        //    foreach(SpriteRenderer childRender in childsRenderer)
        //    {
        //        childRender.color = Color.red;
        //    }
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    { 
        SpriteRenderer[] childsRenderer = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer childRender in childsRenderer)
        {
            childRender.color = Color.white;
        }
    }
}
