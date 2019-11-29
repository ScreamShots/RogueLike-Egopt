using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public int spawnPointOrientation;
    public bool createBossRoomIsPossible;
    public float timerEndOfGeneration;

    private void Start()
    {
        createBossRoomIsPossible = true;
        timerEndOfGeneration = 2f;

        if (transform.localPosition.y > 0 && transform.localPosition.x == 0) //spawnpoint is top
        {
            spawnPointOrientation = 0;
        }
        else if (transform.localPosition.y < 0 && transform.localPosition.x == 0) //spawnpoint is bot
        {
            spawnPointOrientation = 2;
        }
        else if (transform.localPosition.x > 0 && transform.localPosition.y == 0) //spawnpoint is right
        {
            spawnPointOrientation = 1;
        }
        else if (transform.localPosition.x < 0 && transform.localPosition.y == 0) //spawnpoint is left
        {
            spawnPointOrientation = 3;
        }
    }

    void Update()
    {
        if (RoomGenerationHandler.isLevelPlayable == true)
        {
            timerEndOfGeneration -= Time.deltaTime;
            if (timerEndOfGeneration <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rooms")
        {
            createBossRoomIsPossible = false;
        }
    }
}
