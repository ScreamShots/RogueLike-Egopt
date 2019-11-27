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
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfRoomsSpawned = GameObject.FindGameObjectsWithTag("Rooms").Length;
        if (numberOfRoomsSpawned > 12)
        {
           
            canDeleted = true;
            Debug.Log(canDeleted);
        }
    }
}
