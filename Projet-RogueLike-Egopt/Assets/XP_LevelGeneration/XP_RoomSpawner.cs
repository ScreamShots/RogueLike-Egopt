using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private int numberOfRooms;




    private void Awake()
    {
        spawned = false;
        Invoke("Spawn", 1f);
        numberOfRooms = GameObject.FindGameObjectsWithTag("Rooms").Length;
        Debug.Log(numberOfRooms);
    }
    private void Update()
    {
        if (numberOfRooms >= 13)
        {
            Instantiate(templates.closedRooms[0], transform.position, templates.closedRooms[0].transform.rotation);
        }
    }

    void Spawn()
    {
           if (spawned == false && numberOfRooms <= 13)
            {
                if (openingDirection == 1 )
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
                    numberOfRooms += 1;
                }
                else if (openingDirection == 3)
                {
                    // Need to spawn a room with a LEFT door
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    
                }
                else if (openingDirection == 4 )
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
        if (other.CompareTag("SpawnPoint") ||  other.gameObject.tag == "SpawnRoom" )
        {
               Destroy(gameObject);
          
        }
    }

   
}
