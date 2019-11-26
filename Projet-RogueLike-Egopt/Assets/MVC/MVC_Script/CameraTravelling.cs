using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTravelling : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    public Camera cam;
    private Vector2 newPos;

    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            newPos = new Vector2(cam.transform.position.x + cameraChange.x, cam.transform.position.y + cameraChange.y);
            cam.transform.position = newPos;
            other.transform.position += playerChange;
        }
    }
}

