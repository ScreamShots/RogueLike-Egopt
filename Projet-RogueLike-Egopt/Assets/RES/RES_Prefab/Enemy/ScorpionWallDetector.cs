using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionWallDetector : MonoBehaviour
{
    public GameObject thisScorpion;

    private void Start()
    {
        thisScorpion = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Props")
        {
            thisScorpion.GetComponent<ScorpionBehaviour>().isOnAWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Props")
        {
            thisScorpion.GetComponent<ScorpionBehaviour>().isOnAWall = false;
        }
    }
}
