using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRangeScorpion : MonoBehaviour
{
    public GameObject thisScorpion;

    private void Start()
    {
        thisScorpion = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision" && collision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            thisScorpion.GetComponent<ScorpionBehaviour>().isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision" && collision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            thisScorpion.GetComponent<ScorpionBehaviour>().isPlayerInRange = false;
        }
    }
}
