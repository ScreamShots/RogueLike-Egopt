using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp_LeftChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftDoors;

   

    private void Start()
    {
        
        leftDoors.SetActive(false);
    }
    private void Update()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "MiddleCenter")
            {
                leftDoors.SetActive(true);
            }
        
    }
}

