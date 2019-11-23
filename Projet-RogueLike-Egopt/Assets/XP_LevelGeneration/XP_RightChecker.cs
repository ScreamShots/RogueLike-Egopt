using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_RightChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rightDoors;
    


    private void Start()
    {
        
        rightDoors.SetActive(false);
    }
    private void Update()
    {

    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "MiddleCenter")
            {
                rightDoors.SetActive(true);
            }
        
            

        
    }
}
