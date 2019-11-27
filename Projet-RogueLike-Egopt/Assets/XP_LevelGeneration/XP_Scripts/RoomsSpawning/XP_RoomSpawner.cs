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

    public XP_RoomTemplates templates = default;
    private int rand;
    private bool spawned;
    public int numberOfRooms;

   
     public bool spawningIsFinish = false;


    private void Update()
    {
        if ( numberOfRooms > 15)
        {
            spawningIsFinish = true;
            Debug.Log(spawningIsFinish);
        }
    }

    private void Awake()
    {
        
        spawned = false;
        Invoke("SpawnRoom", 0.1f);
        numberOfRooms = GameObject.FindGameObjectsWithTag("Rooms").Length;
        Debug.Log(numberOfRooms);

    }

    

    void SpawnRoom()
    {
        if (spawned == false && numberOfRooms <= 12 && spawningIsFinish == false)
        {
            if (openingDirection == 1 )
            {
                // Need to spawn a room with a BOTTOM door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                

            }
            else if (openingDirection == 2 )
            {
                // Need to spawn a room with a TOP door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                numberOfRooms += 1;
            }
            else if (openingDirection == 3 )
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
        if (other.gameObject.tag == ("MiddleCenter") ||  other.gameObject.tag == "SpawnRoom" || other.gameObject.tag == ("SpawnPoint"))
        {
               Destroy(gameObject);
          
        }

        if(other.gameObject.tag == "Rooms"){
            Destroy(gameObject);
        }
    }

   
}
