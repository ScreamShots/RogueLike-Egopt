using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSand : MonoBehaviour
{
    public float slowRatio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision")
        {
            if (collision.gameObject.transform.parent.gameObject.tag == "Player")
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().speed *= slowRatio;
            }
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision")
        {
            if (collision.gameObject.transform.parent.gameObject.tag == "Player")
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().speed /= slowRatio;
            }
        }
    }
}
