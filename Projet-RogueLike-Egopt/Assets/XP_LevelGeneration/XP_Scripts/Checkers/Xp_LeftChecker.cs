using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp_LeftChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftDoors;
   
    private void Awake()
    {

        leftDoors.SetActive(false);

        

    }


  

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MiddleCenter" || collision.gameObject.tag == "Floor")
        {
            leftDoors.SetActive(true);
            Destroy(gameObject);
        }


    }



}

