using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1--> Need bottom door.
    // 2--> Need top door.
    // 3--> Need left door.
    // 4--> need right door.

    [SerializeField] private XP_RoomTemplates templates = default;
    private int rand;
    private bool spawned;

    private void Start()
    {
        spawned = false;
        //templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<XP_RoomTemplates>();
        Invoke("Spawn", 0.3f);
    }

   void Spawn()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                // Need to spawn a room with a BOTTOM door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);

            }
            else if (openingDirection == 2)
            {
                // Need to spawn a room with a TOP door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // Need to spawn a room with a LEFT door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // Need to spawn a room with a RIGHT door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<XP_RoomSpawner>().spawned == true && other.gameObject.tag != "SpawnRoom") ;
        {
            Destroy(gameObject);
        }
    }
}
