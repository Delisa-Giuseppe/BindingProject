using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public Transform target;
    public int moveSpeed;
	public Rigidbody2D rb;

    Vector2 currentDirection;
    bool move = true;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
    }

	// Update is called once per frame
	void Update () {
        if(move)
        {
            transform.Translate((target.position - transform.position).normalized * moveSpeed * Time.deltaTime);
            currentDirection = (target.position - transform.position).normalized;
        }
    }

	void OnCollisionStay2D(Collision2D other)
	{
        move = false;
        if(currentDirection == Vector2.left)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else if(currentDirection == Vector2.right)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else if(currentDirection == Vector2.up)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else if(currentDirection == Vector2.down)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        move = true;
    }

}