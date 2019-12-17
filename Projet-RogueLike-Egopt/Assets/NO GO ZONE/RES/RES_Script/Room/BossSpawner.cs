using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    private bool createBossRoomIsPossible;
    [SerializeField]private GameObject BossRoom;

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
            Instantiate(BossRoom, transform.position, transform.rotation);
            RoomGenerationHandler.isBossRoomCreated = true;
            return true;
        }
        return false;
    }
}
