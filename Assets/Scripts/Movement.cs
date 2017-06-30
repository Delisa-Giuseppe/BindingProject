using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 5f;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed*Input.GetAxis("Horizontal")*Time.deltaTime, speed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);
	}
}
