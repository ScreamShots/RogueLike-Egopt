using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform linkedDoorTransform;
    public bool isOnGround;
    public bool isOverlaped;
    public bool isDoorLocked;
    public float timer;
    public Animator animator;




    private void Start()
    {
        animator = GetComponent<Animator>();
        isOnGround = false;
        isOverlaped = false;
        isDoorLocked = true;
        timer = 0.1f;

       
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

        if (isDoorLocked == true)
        {
            animator.SetTrigger("Open");
        }
        if (isDoorLocked == false)
        {
            
            animator.SetTrigger("Close");
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UseDoor(collision.gameObject);
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

    void UseDoor(GameObject obj)
    {
        if (obj.tag == "CharacterGroundCollision" && obj.transform.parent.tag == "Player" && isDoorLocked == false)
        {
            PlayerMovement.playerRgb.velocity = new Vector3(0, 0, 0);

            if (PlayerStatusManager.isDashing == false)
            {
                if (transform.position.x - linkedDoorTransform.position.x < 0)
                {
                    obj.transform.parent.position = linkedDoorTransform.position + new Vector3(0.30f, 0, 0);
                }
                else if (transform.position.x - linkedDoorTransform.position.x > 0)
                {
                    obj.transform.parent.position = linkedDoorTransform.position + new Vector3(-0.30f, 0, 0);
                }
                else if (transform.position.y - linkedDoorTransform.position.y < 0)
                {
                    obj.transform.parent.position = linkedDoorTransform.position + new Vector3(0, 0.30f, 0);
                }
                else if (transform.position.y - linkedDoorTransform.position.y > 0)
                {
                    obj.gameObject.transform.parent.position = linkedDoorTransform.position + new Vector3(0, -0.30f, 0);
                }
            }
        }
    }
}
