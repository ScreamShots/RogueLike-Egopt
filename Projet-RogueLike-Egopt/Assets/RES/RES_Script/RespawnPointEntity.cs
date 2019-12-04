using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointEntity : MonoBehaviour
{
    public GameObject[] allRoomRespawnPoint;
    private bool updateShorter;

    void Start()
    {
        updateShorter = true;
        allRoomRespawnPoint = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            allRoomRespawnPoint[i] = transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (transform.parent.GetComponent<RoomHandler>().isRoomActivated == false)
        {
            DesactivateRespawnPoint();
            updateShorter = true;
        }
        else if (transform.parent.GetComponent<RoomHandler>().isRoomActivated == true && updateShorter == true)
        {
            ActivateRespawnPoint();
            updateShorter = false;
        }
    }

    public void ActivateRespawnPoint()
    {
        for (int i = 0; i < allRoomRespawnPoint.Length; i++)
        {
            allRoomRespawnPoint[i].SetActive(true);
        }

    }

    public void DesactivateRespawnPoint()
    {
        for (int i = 0; i < allRoomRespawnPoint.Length; i++)
        {
            allRoomRespawnPoint[i].SetActive(false);
            Debug.Log("coucou");
        }

    }
}
