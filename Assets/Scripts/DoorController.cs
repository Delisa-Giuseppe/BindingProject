using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public Vector2 direction;
    public Transform destinationCamera;
    public Transform destinationDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<CameraControl>().SetDestination = destinationCamera;
            camera.GetComponent<CameraControl>().MoveCamera = true;
            Vector2 playerPosition = Vector2.zero;

            playerPosition = new Vector2(destinationDoor.position.x + direction.x, destinationDoor.position.y + direction.y);

            collision.gameObject.transform.position = playerPosition;
        }
    }
}
