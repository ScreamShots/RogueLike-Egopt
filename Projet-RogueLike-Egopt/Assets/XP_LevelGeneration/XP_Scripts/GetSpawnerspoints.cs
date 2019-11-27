using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpawnerspoints : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject parent = transform.parent.gameObject;
            Transform[] tsfm = parent.GetComponentsInChildren<Transform>();
            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in tsfm)
            {
                if (child.tag == "EnemySpawners")
                {
                    children.Add(child.gameObject);
                }
            }

            foreach (GameObject go in children)
            {
                go.GetComponent<XP_SpawningSystem>().Invoke("Spawning", 0.1f);
                
            }
        }

    } 
}
