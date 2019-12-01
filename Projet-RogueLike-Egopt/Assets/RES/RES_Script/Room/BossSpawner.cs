using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public bool createBossRoomIsPossible;
    public GameObject BossRoom;

    private void Start()
    {
        createBossRoomIsPossible = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rooms")
        {
            createBossRoomIsPossible = false;
        }
    }
    public bool SpawnBossRoom()
    {

        if (createBossRoomIsPossible == true && RoomGenerationHandler.isLevelPlayable == false)
        {
            Debug.Log("creation");
            Instantiate(BossRoom, transform.position, transform.rotation);
            RoomGenerationHandler.isLevelPlayable = true;
            return true;
        }

        return false;
    }
}
