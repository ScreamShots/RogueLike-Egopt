using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledColider : MonoBehaviour
{
    private int numberOfSpawnedRooms;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfSpawnedRooms = GameObject.FindGameObjectsWithTag("Rooms").Length;

        if (numberOfSpawnedRooms >= 13)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
