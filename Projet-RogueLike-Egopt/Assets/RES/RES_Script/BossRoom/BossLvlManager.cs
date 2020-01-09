using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLvlManager : MonoBehaviour
{
    
    void Start()
    {
        GameManager.gameManager.player.transform.position = new Vector3(0, 0, 0);
        transform.parent = GameManager.gameManager.player.transform;
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
