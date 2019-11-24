using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInHole : MonoBehaviour
{
    public GameObject respawnPoint;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Fallen());

        IEnumerator Fallen()
        {
            print("Fallen Start Execution");
            collision.GetComponent<PlayerMovement>().canMove = false;
            yield return new WaitForSeconds(2);
            print("Fallen is finish");
            collision.transform.position = respawnPoint.transform.position;
            print("Player is Respawn");
            collision.GetComponent<PlayerMovement>().canMove = true;
            // Ajouter la perte de vie
        }
        
    }

}