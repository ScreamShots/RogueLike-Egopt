using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTooCloseScorpion : MonoBehaviour
{
    public GameObject thisScorpion;

    private void Start()
    {
        thisScorpion = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thisScorpion.GetComponent<ScorpionBehaviour>().isPlayerTooClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thisScorpion.GetComponent<ScorpionBehaviour>().isPlayerTooClose = false;
        }
    }
}
