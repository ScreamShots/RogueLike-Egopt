using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_BottomChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bottomDoors;

  

    private void Start()
    {
        
        bottomDoors.SetActive(false);
    }
    private void Update()
    {
       
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject.tag == "MiddleCenter")
            {
                bottomDoors.SetActive(true);
            }
        
    }
}
