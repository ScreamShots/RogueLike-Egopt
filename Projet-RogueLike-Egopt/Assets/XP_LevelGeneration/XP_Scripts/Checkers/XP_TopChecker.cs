using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_TopChecker : MonoBehaviour
{
    public GameObject topDoors;
   

    private void Awake()
    {

        topDoors.SetActive(false);

     

    }


  
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MiddleCenter" || collision.gameObject.tag == "Floor")
        {
            topDoors.SetActive(true);
            Destroy(gameObject);
        }


    }

 

}

