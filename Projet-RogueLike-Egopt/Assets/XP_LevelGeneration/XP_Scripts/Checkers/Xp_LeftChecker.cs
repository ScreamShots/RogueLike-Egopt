using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp_LeftChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftDoors;
    private BoxCollider2D boxCollider2D;
    private void Awake()
    {

        leftDoors.SetActive(false);
        

    }
   

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MiddleCenter")
        {
            leftDoors.SetActive(true);
            Destroy(gameObject);
        }


    }



}

