using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyToSpawn;
    public int randomNumber;
    public GameObject enemySpawned;

    private void Awake()
    {

        Debug.Log(GetComponent<Transform>().position);
       
  
    }
}

