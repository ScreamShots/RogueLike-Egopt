using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canDeleted = false;

    public int numberOfRoomsSpawned;
    // Start is called before the first frame update
    void Awake()
    {
        numberOfRoomsSpawned = GameObject.FindGameObjectsWithTag("Rooms").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfRoomsSpawned > 12)
        {
            canDeleted = true;
        }
    }
}
