using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public Transform target;
    public float moveSpeed;
	public Rigidbody2D rb;

    Vector2 currentDirection;
    Vector2 direction;
    bool move = true;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
    }

	// Update is called once per frame
	void Update () {
        if(move)
        {
            direction = (target.position - transform.position).normalized;
        }
        currentDirection = direction;
        transform.Translate(direction *moveSpeed * Time.deltaTime);
    }

	void OnCollisionEnter2D(Collision2D other)
	{
        move = false;
        if(currentDirection == Vector2.left)
        {
            direction = Vector2.up;
        }
        else if(currentDirection == Vector2.right)
        {
            direction = Vector2.up;
        }
        else if(currentDirection == Vector2.up)
        {
            direction = Vector2.left;
        }
        else if(currentDirection == Vector2.down)
        {
            direction = Vector2.right;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        move = true;
    }

}