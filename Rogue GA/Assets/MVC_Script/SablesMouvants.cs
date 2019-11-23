using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SablesMouvants : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerMovement>().moveSpeed = 0.5f;
        Debug.Log("le jouer est ralentit");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<PlayerMovement>().moveSpeed = 1.5f;
        Debug.Log("le jouer n'est plus ralentit");
    }
}
