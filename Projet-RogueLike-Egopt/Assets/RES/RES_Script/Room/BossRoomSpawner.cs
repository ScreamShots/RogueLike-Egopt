using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSpawner : MonoBehaviour
{
    public GameObject[] bossSpawnPoint;

    public void Start()
    {
        bossSpawnPoint = new GameObject[transform.childCount];
        
    }

    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            bossSpawnPoint[i] = transform.GetChild(i).gameObject;
            if (bossSpawnPoint[i].GetComponent<BossSpawner>().SpawnBossRoom() == true)
            {
                Destroy(this.gameObject);
                break;
            }
        }

        Destroy(this.gameObject);
    }
}

