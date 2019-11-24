using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject pickableVersionObject;
    public GameObject spawnedPickableObject;
    public GameObject player;


    public void Drop()
    {
        player = GameObject.FindWithTag("Player");
        spawnedPickableObject = Instantiate(pickableVersionObject);
        spawnedPickableObject.transform.position = player.GetComponent<Transform>().position;
    }
}
