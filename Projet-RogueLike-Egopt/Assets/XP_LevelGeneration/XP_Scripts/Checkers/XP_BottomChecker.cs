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


  

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MiddleCenter" || collision.gameObject.tag == "Floor")
        {
            bottomDoors.SetActive(true);
            Destroy(gameObject);
        }


    }




}
