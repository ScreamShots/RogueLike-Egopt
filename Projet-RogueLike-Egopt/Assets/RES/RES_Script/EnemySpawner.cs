using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyToSpawn;
    public int randomNumber;

    private void Start()
    {

        randomNumber = Random.Range(0, enemyToSpawn.Length);
        Instantiate(enemyToSpawn[randomNumber], transform.position, transform.rotation);

        Destroy(this.gameObject);
       
  
    }
}

