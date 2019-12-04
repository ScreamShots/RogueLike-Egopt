using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    public List<GameObject> doorInThisRoom;
    public List<GameObject> enemyInThisRoom;
    public bool isRoomActivated;


    private void Start()
    {
        isRoomActivated = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInThisRoom.Add(collision.gameObject);
        }

        if (collision.gameObject.tag == "Door")
        {
            doorInThisRoom.Add(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            isRoomActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInThisRoom.Remove(collision.gameObject);
        }

        if (collision.gameObject.tag == "Door")
        {
            doorInThisRoom.Remove(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            isRoomActivated = false;
        }

    }

    private void Update()
    {
        if (isRoomActivated == true)
        {
            if (enemyInThisRoom.Count == 0)
            {
                foreach (GameObject door in doorInThisRoom)
                {
                    door.GetComponent<Door>().isDoorLocked = false;
                }
            }
            else if (enemyInThisRoom.Count != 0)
            {
                foreach (GameObject door in doorInThisRoom)
                {
                    door.GetComponent<Door>().isDoorLocked = true;
                }
            }
        }
        
    }
}
