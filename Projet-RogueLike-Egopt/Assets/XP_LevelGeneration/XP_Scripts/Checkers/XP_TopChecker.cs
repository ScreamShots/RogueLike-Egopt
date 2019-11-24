using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_TopChecker : MonoBehaviour
{
    public GameObject topDoors;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {

        topDoors.SetActive(false);
 

    }



    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MiddleCenter")
        {
            topDoors.SetActive(true);
            Destroy(gameObject);
        }


    }

 

}

