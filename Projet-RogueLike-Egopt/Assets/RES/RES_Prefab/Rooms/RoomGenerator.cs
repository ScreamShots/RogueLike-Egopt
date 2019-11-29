using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public static int numberOfRoomCreated;
    public int numberMaxOfRoom;
    public int randomNumber;
    public GameObject roomListHolder;
    public RoomList roomList;
    public GameObject[] spawnableRoom;
    public GameObject lastRoomToSpawn;
    public bool alreadySpawn;
    public static bool isRoomCreated;
    public float timerEndOGeneration;


    private void Awake()
    {
        roomList = roomListHolder.GetComponent<RoomList>();
        alreadySpawn = false;
        isRoomCreated = false;
        timerEndOGeneration = 2f;

        if (transform.localPosition.y > 0 && transform.localPosition.x == 0) //spawnpoint is top
        {
            spawnableRoom = roomList.topOpenRoom;
            lastRoomToSpawn = roomList.toplastRoom;

        }
        else if (transform.localPosition.y < 0 && transform.localPosition.x == 0) //spawnpoint is bot
        {
            spawnableRoom = roomList.botOpenRoom;
            lastRoomToSpawn = roomList.botlastRoom;

        }
        else if (transform.localPosition.x > 0 && transform.localPosition.y == 0) //spawnpoint is right
        {
            spawnableRoom = roomList.rightOpenRoom;
            lastRoomToSpawn = roomList.rightlastRoom;

        }
        else if (transform.localPosition.x < 0 && transform.localPosition.y == 0) //spawnpoint is left
        {
            spawnableRoom = roomList.leftOpenRoom;
            lastRoomToSpawn = roomList.leftlastRoom;
        }

        randomNumber = Random.Range(0, spawnableRoom.Length);

        StartCoroutine("SpawnARoom");

    }

    private void Update()
    {
        if (isRoomCreated == false)
        {
            timerEndOGeneration -= Time.deltaTime;
            if (timerEndOGeneration <= 0)
            {
                Destroy(this.gameObject);

            }
        }
        else if (isRoomCreated == true)
        {
            isRoomCreated = false;
        }
    }
    IEnumerator SpawnARoom()
    {
        yield return new WaitForSeconds(0.2f);
        if (alreadySpawn == false && numberOfRoomCreated < numberMaxOfRoom)
        {
            Instantiate(spawnableRoom[randomNumber], transform.position, transform.rotation);
            alreadySpawn = true;
            isRoomCreated = true;
            numberOfRoomCreated += 1;
        }
        else if(alreadySpawn == false && numberOfRoomCreated >= numberMaxOfRoom)
        {
            Instantiate(lastRoomToSpawn, transform.position, transform.rotation);
            alreadySpawn = true;
            numberOfRoomCreated += 1;
            isRoomCreated = true;
            Debug.Log("c'est terminée");
            Debug.Log(numberOfRoomCreated);
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
