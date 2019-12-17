using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private RoomList roomList;
    private GameObject[] spawnableRoom;
    private bool alreadySpawn;
    private int randomNumber;

    private void Start()
    {
        alreadySpawn = false;
        
        if (transform.localPosition.y > 0 && transform.localPosition.x == 0) //spawnpoint is top
        {
            spawnableRoom = roomList.topOpenRoom;

        }
        else if (transform.localPosition.y < 0 && transform.localPosition.x == 0) //spawnpoint is bot
        {
            spawnableRoom = roomList.botOpenRoom;

        }
        else if (transform.localPosition.x > 0 && transform.localPosition.y == 0) //spawnpoint is right
        {
            spawnableRoom = roomList.rightOpenRoom;

        }
        else if (transform.localPosition.x < 0 && transform.localPosition.y == 0) //spawnpoint is left
        {
            spawnableRoom = roomList.leftOpenRoom;
        }

        randomNumber = Random.Range(0, spawnableRoom.Length);

        StartCoroutine("SpawnARoom");

    }

    private void Update()
    {
        if (RoomGenerationHandler.isBasicGenerationFinished == true)
        {
            Destroy(this.gameObject);            
        }
        
    }
    IEnumerator SpawnARoom()
    {
        yield return new WaitForSeconds(0.1f);

        if (alreadySpawn == false && RoomGenerationHandler.numberOfRoomCreated < RoomGenerationHandler.maxNumberOfRoom)
        {
            Instantiate(spawnableRoom[randomNumber], transform.position, transform.rotation);  
            alreadySpawn = true;

            RoomGenerationHandler.isARoomCreatedRecently = true;
            RoomGenerationHandler.numberOfRoomCreated += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnRoom" || collision.gameObject.tag == "SpawnRoomDisable")
        {
            alreadySpawn = true;
        }
    }
}
