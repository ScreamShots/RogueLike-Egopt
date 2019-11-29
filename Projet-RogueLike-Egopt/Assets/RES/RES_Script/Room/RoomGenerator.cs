using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public RoomList roomList;
    public GameObject[] spawnableRoom;

    public static int numberOfRoomCreated;
    public int maxNumberOfRoomCreated;
    public int minNumberOfRoomCreated;
    public float timerEndOfGeneration;
    public static bool generationIsFinished;

    public bool alreadySpawn;
    public static bool isRoomCreated;

    public int randomNumber;

    private void Awake()
    {
        alreadySpawn = false;
        isRoomCreated = false;
        timerEndOfGeneration = 2f;
        generationIsFinished = false;

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
        if (isRoomCreated == false)
        {
            timerEndOfGeneration -= Time.deltaTime;

            if (timerEndOfGeneration <= 0)
            {
                Debug.Log("Nombre de salles dans la scene:" + numberOfRoomCreated);
                generationIsFinished = true;
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

        if (alreadySpawn == false && numberOfRoomCreated < maxNumberOfRoomCreated)
        {
            Instantiate(spawnableRoom[randomNumber], transform.position, transform.rotation);
            alreadySpawn = true;
            isRoomCreated = true;
            numberOfRoomCreated += 1;
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
