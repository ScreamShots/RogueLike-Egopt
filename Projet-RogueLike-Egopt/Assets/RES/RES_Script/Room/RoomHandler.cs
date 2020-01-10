﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomHandler : MonoBehaviour
{
    public List<GameObject> doorInThisRoom;
    public List<GameObject> enemyInThisRoom;
    public bool isRoomActivated;
    public bool isThisRoomSpawn;
    public bool canSpawnChest;
    public bool chestAlreadySpawned;
    public GameObject chest;
    public GameObject thisChest;
    public GameObject gameCamera;
    public bool isThisBossRoom;
    public bool cameraIsSet;
    public bool isThisShop;

    //music
    public GameObject musicManagerEnvironnement;

    private void Start()
    {
        isRoomActivated = false;
        canSpawnChest = false;
        chestAlreadySpawned = false;
        gameCamera = GameObject.FindWithTag("MainCamera");

        //music
        musicManagerEnvironnement = GameObject.FindGameObjectWithTag("MusicManager_Environnement");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInThisRoom.Add(collision.gameObject);
        }

        if (collision.gameObject.tag == "Door")
        {
            doorInThisRoom.Add(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            isRoomActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInThisRoom.Remove(collision.gameObject);
        }

        if (collision.gameObject.tag == "Door")
        {
            doorInThisRoom.Remove(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            isRoomActivated = false;
            cameraIsSet = false;
        }

    }

    private void Update()
    {
        if (isRoomActivated == true)
        {
            if (enemyInThisRoom.Count == 0)
            {
                foreach (GameObject door in doorInThisRoom)
                {
                    door.GetComponent<Door>().isDoorLocked = false;

                }
                canSpawnChest = true;
            }

            else if (enemyInThisRoom.Count != 0)
            {
                foreach (GameObject door in doorInThisRoom)
                {
                    door.GetComponent<Door>().isDoorLocked = true;

                }
                Destroy(thisChest);
                chestAlreadySpawned = false;
                canSpawnChest = false;
            }

            if (isThisRoomSpawn == false && canSpawnChest == true && chestAlreadySpawned == false && isThisShop == false)
            {
                
                thisChest = Instantiate(chest, transform.position, Quaternion.identity);
                    chestAlreadySpawned = true;
            }

            if(isThisBossRoom == true && cameraIsSet == false)
            {
                SceneManager.LoadScene(3);
            }
            else if (cameraIsSet == false)
            {
                gameCamera.transform.parent = null;
                gameCamera.transform.position = transform.position;
                cameraIsSet = true;
            }
            
        }
        
    }
}
