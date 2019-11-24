using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private GameObject thisEnemy;

    private void Start()
    {
        thisEnemy = GetComponent<Transform>().parent.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thisEnemy.GetComponent<EnemyMeleeMovement>().playerIsInRang = true;
            thisEnemy.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            thisEnemy.GetComponent<EnemyMeleeAttack>().isPlayerinRang = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thisEnemy.GetComponent<EnemyMeleeMovement>().playerIsInRang = false;
            thisEnemy.GetComponent<EnemyMeleeAttack>().isPlayerinRang = false;
        }
    }
}
