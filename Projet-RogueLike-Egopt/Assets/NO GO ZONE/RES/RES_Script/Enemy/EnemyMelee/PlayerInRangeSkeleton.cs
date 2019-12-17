using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRangeSkeleton : MonoBehaviour
{
    public GameObject thisSkeleton;

    private void Start()
    {
        thisSkeleton = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision" && collision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            thisSkeleton.GetComponent<SkeletonBehaviour>().isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision" && collision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            thisSkeleton.GetComponent<SkeletonBehaviour>().isPlayerInRange = false;
        }
    }
}
