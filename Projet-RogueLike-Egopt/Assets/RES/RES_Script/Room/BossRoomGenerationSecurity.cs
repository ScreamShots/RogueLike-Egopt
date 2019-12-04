using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomGenerationSecurity : MonoBehaviour
{
    public static bool isBossRoomSpawnedCorrectly;
    public bool test;

    private void Start()
    {
        isBossRoomSpawnedCorrectly = true;
    }

    private void Update()
    {
        if (RoomGenerationHandler.isLevelPlayable == true)
        {
            Destroy(GetComponent<BossRoomGenerationSecurity>());
            Destroy(GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rooms")
        {
            isBossRoomSpawnedCorrectly = false;
        }
    }
}
