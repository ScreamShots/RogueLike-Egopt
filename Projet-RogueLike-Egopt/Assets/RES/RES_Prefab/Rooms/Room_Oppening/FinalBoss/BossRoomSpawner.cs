using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSpawner : MonoBehaviour
{
    public GameObject[] bossSpawnPoint;
    public GameObject bossRoom;
    public static bool bossRoomIsSpawned;
    public float securityWaitingTime;

    public void Start()
    {
        
        bossRoomIsSpawned = false;

        for (int i = 0; i < bossSpawnPoint.Length; i++)
        {
            if (bossSpawnPoint[i].GetComponent<BossSpawner>().createBossRoomIsPossible == true)
            {
                Debug.Log("coucou");
                Instantiate(bossRoom, transform.position, transform.rotation);
                bossRoomIsSpawned = true;
                Destroy(this.gameObject);
            }
            else
            {
                bossRoomIsSpawned = false;
            }
        }

        Destroy(this.gameObject);
    }
}

