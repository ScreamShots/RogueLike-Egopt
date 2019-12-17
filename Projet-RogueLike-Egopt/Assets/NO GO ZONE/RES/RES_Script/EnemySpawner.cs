using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyToSpawn;
    [HideInInspector] public GameObject linkedRoom;
    [HideInInspector] public int randomNumber;
    [HideInInspector] public float timeBeforeSpawn;

    private void Update()
    {
        if (linkedRoom.GetComponent<RoomHandler>().isRoomActivated == true)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rooms")
        {
            linkedRoom = collision.gameObject;
        }
    }

    IEnumerator SpawnEnemy()
    {
        //PlayerStatusManager.isLoading = true;

        yield return new WaitForSeconds(0);

        //PlayerStatusManager.needToEndLoad = true;

        randomNumber = Random.Range(0, enemyToSpawn.Length);
        Instantiate(enemyToSpawn[randomNumber], transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}

