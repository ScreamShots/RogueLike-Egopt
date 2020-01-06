using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private RoomList roomList;
    private GameObject[] spawnableRoom;
    private bool alreadySpawn;
    private int randomNumber;
    public float shopSpawnRate;
    public static bool shopIsSpawned;
    public bool shopIsSelectionned;
    

    private void Start()
    {
        alreadySpawn = false;
        shopIsSelectionned = false;
        Debug.Log(shopSpawnRate);


        if (RoomGenerationHandler.numberOfRoomCreated > 5 && shopIsSpawned == false)
        {
            shopIsSelectionned = true;

            if (transform.localPosition.y > 0 && transform.localPosition.x == 0) //spawnpoint is top
            {
                spawnableRoom = roomList.topOpenShop;

            }
            else if (transform.localPosition.y < 0 && transform.localPosition.x == 0) //spawnpoint is bot
            {
                spawnableRoom = roomList.botOpenShop;

            }
            else if (transform.localPosition.x > 0 && transform.localPosition.y == 0) //spawnpoint is right
            {
                spawnableRoom = roomList.rightOpenShop;

            }
            else if (transform.localPosition.x < 0 && transform.localPosition.y == 0) //spawnpoint is left
            {
                spawnableRoom = roomList.leftOpenShop;
            }
        }
        else
        {

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
            if(shopIsSelectionned == true && shopIsSpawned == false)
            {
                Instantiate(spawnableRoom[randomNumber], transform.position, transform.rotation);
                alreadySpawn = true;
                shopIsSpawned = true;
            }
            else if (shopIsSelectionned == false)
            {
                Instantiate(spawnableRoom[randomNumber], transform.position, transform.rotation);
                alreadySpawn = true;
            }

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
