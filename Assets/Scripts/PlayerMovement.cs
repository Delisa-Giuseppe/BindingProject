using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    Rigidbody2D playerRB;
    public AudioSource [] audioPlayer;
    public static bool movementEnabled;


	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponents<AudioSource>();
        movementEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(movementEnabled)
        {
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
            playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioPlayer[0].Play();
            SpriteRenderer[] childsRenderer = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer childRender in childsRenderer)
            {
                if(childRender.name != "FireShadow")
                    childRender.color = Color.red;
            }

            StartCoroutine(ResetColor(0.1f));
        }
    }

    IEnumerator ResetColor(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpriteRenderer[] childsRenderer = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer childRender in childsRenderer)
        {
            if (childRender.name != "FireShadow")
                childRender.color = Color.white;
        }
    }
}
