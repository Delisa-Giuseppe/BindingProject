using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimation : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isMoveRight", true);
            anim.SetBool("isMoveLeft", false);
            anim.SetBool("isMoveUp", false);
            anim.SetBool("isMoveDown", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("isMoveRight", false);
            anim.SetBool("isMoveLeft", true);
            anim.SetBool("isMoveUp", false);
            anim.SetBool("isMoveDown", false);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetBool("isMoveUp", true);
            anim.SetBool("isMoveRight", false);
            anim.SetBool("isMoveLeft", false);
            anim.SetBool("isMoveDown", false);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("isMoveUp", false);
            anim.SetBool("isMoveRight", false);
            anim.SetBool("isMoveLeft", false);
            anim.SetBool("isMoveDown", true);
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            anim.SetBool("isMoveUp", false);
            anim.SetBool("isMoveRight", false);
            anim.SetBool("isMoveLeft", false);
            anim.SetBool("isMoveDown", false);
        }
    }
}
