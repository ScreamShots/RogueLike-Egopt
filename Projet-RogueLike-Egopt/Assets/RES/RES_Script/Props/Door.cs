﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform linkedDoorTransform;
    public bool isOnGround;
    public bool isOverlaped;
    public float timer;

    private void Awake()
    {
        isOnGround = false;
        isOverlaped = false;
        timer = 0.3f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (isOnGround == false || isOverlaped == true)
            {
                Destroy(transform.parent.gameObject);
            }

        }

            

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision")
        {
            PlayerMovement.playerRgb.velocity = new Vector3(0, 0, 0);

            if(transform.position.x - linkedDoorTransform.position.x < 0)
            {
                collision.gameObject.transform.parent.position = linkedDoorTransform.position + new Vector3(0.3f,0,0);
            }
            else if (transform.position.x - linkedDoorTransform.position.x > 0)
            {
                collision.gameObject.transform.parent.position = linkedDoorTransform.position + new Vector3(-0.3f, 0, 0);
            }
            else if(transform.position.y - linkedDoorTransform.position.y < 0)
            {
                collision.gameObject.transform.parent.position = linkedDoorTransform.position + new Vector3(0, 0.3f, 0);
            }
            else if (transform.position.y - linkedDoorTransform.position.y > 0)
            {
                collision.gameObject.transform.parent.position = linkedDoorTransform.position + new Vector3(0, -0.3f, 0);
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rooms")
        {
            isOnGround = true;
        }
        if(collision.gameObject.tag == "Door")
        {
            isOverlaped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            isOverlaped = false;
        }
    }
}
