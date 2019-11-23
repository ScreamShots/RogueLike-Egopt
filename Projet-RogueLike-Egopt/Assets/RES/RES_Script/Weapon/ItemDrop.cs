using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject pickableVersionObject;
    public GameObject spawnedPickableObject;

    public void Drop()
    {
        spawnedPickableObject = Instantiate(pickableVersionObject);
        spawnedPickableObject.transform.position = GetComponent<Transform>().position;
    }
}
