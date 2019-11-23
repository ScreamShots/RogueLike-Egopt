using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_TopChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bottomDoors;
    public GameObject leftDoors;
    public GameObject rightDoors;


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(bottomDoors);
        Destroy(leftDoors);
        Destroy(rightDoors);
    }
    
      
}
