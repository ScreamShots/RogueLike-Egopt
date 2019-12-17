using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoomGenerator : MonoBehaviour
{
    void Update()
    {
        if (RoomGenerationHandler.isBasicGenerationFinished == true)
        {
            Destroy(this.gameObject);            
        }
    }
}
