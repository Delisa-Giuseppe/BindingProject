using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour {

    public int maxHitCounter;
    int currentHitCounter;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if(currentHitCounter >= maxHitCounter)
            {
                anim.SetBool("TurnOff", true);
            }
            else
            {
                currentHitCounter++;
            }
        }
    }
}
