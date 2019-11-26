using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_SpawningSystem : MonoBehaviour
{
    
    public List<GameObject> enemies = new List<GameObject>();
    int randEnemy;

    public void Spawning()
    {
        randEnemy = Random.Range(0, 2);
        Instantiate(enemies[randEnemy],transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
