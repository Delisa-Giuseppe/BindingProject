using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    bool moveCamera = false;
    Transform destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(moveCamera && transform.position != destination.position)
        {
            Vector3 newPosition = new Vector3(destination.position.x, destination.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, 0.2f);
        }
        else
        {
            moveCamera = false;
        }
	}

    public bool MoveCamera
    {
        set { moveCamera = value; }
    }

    public Transform SetDestination
    {
        set { destination = value; }
    }
}
