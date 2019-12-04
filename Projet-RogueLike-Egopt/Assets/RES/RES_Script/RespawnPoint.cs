using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.respawnPosition = transform.position;
            transform.parent.gameObject.GetComponent<RespawnPointEntity>().DesactivateRespawnPoint();
            Debug.Log("hello");
        }
    }
}
