using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyToSpawn;
    public GameObject linkedRoom;
    public int randomNumber;

    private void Update()
    {
        if (linkedRoom.GetComponent<RoomHandler>().isRoomActivated == true)
        {
            SpawnEnemy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rooms")
        {
            linkedRoom = collision.gameObject;
        }
    }

    void SpawnEnemy()
    {
        randomNumber = Random.Range(0, enemyToSpawn.Length);
        Instantiate(enemyToSpawn[randomNumber], transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}

