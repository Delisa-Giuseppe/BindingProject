using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : EnemyIA {

    public GameObject target;
    public float moveSpeed;

    Vector2 currentDirection;
    Vector2 direction;
    bool move = true;

    // Update is called once per frame
    void Update()
    {
        if(base.IsDead())
        {
            Destroy(gameObject);
        }

        if (move)
        {
            direction = (target.transform.position - transform.position).normalized;
        }
        currentDirection = direction;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnHitPlayer();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            move = false;

            if (currentDirection == Vector2.left)
            {
                direction = Vector2.up;
            }
            else if (currentDirection == Vector2.right)
            {
                direction = Vector2.up;
            }
            else if (currentDirection == Vector2.up)
            {
                direction = Vector2.left;
            }
            else if (currentDirection == Vector2.down)
            {
                direction = Vector2.right;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            move = true;
        }
    }

}
