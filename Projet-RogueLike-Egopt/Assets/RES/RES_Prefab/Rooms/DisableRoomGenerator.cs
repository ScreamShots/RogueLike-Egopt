using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoomGenerator : MonoBehaviour
{
    public float timerEndOGeneration;

    private void Awake()
    {
        timerEndOGeneration = 2f;
    }
       
    void Update()
    {
        if (RoomGenerator.isRoomCreated == false)
        {
            timerEndOGeneration -= Time.deltaTime;
            if (timerEndOGeneration <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
