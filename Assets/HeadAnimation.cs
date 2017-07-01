using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void LateUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        bool walking = h != 0f || v != 0f;
        anim.SetBool("isWalking", walking);
        if(walking)
        {
            anim.SetFloat("speedHorizontal", h);
            anim.SetFloat("speedVertical", v);
        }
    }
}
