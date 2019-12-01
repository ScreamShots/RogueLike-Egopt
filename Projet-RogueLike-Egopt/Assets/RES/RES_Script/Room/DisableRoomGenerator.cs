using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoomGenerator : MonoBehaviour
{
    public float timerEndOfGeneration;

    private void Awake()
    {
        timerEndOfGeneration = 1f;
    }
       
    void Update()
    {
        if (RoomGenerator.isRoomCreated == false)
        {
            timerEndOfGeneration -= Time.deltaTime;
            if (timerEndOfGeneration <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
