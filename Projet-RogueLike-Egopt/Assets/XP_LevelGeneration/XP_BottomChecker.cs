using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_BottomChecker : MonoBehaviour
{
    public GameObject bottomDoors;

   

    private void Awake()
    {

        bottomDoors.SetActive(false);
     

    }


    // Update is called once per frame


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MiddleCenter")
        {
            bottomDoors.SetActive(true);
            Destroy(gameObject);
        }
    }

  


}
