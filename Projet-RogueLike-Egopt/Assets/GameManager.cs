using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Rooms
    public bool canDeleted = false;
    public int numberOfRoomsSpawned;

    //Player
    public GameObject player;
    public Rigidbody2D playerRgb;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRgb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfRoomsSpawned = GameObject.FindGameObjectsWithTag("Rooms").Length;
        if (numberOfRoomsSpawned >= 13)
        {
           
            canDeleted = true;
            Debug.Log(canDeleted);
        }
    }
}
