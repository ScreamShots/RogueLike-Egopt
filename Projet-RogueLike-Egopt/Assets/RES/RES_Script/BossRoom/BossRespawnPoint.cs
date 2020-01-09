﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRespawnPoint : MonoBehaviour
{
    public Transform respawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.respawnPosition = respawnPoint.position;
        }
    }
}
