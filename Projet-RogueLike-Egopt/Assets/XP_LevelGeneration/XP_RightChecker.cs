using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_RightChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topDoors;
    public GameObject bottomDoors;
    public GameObject leftDoors;


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(bottomDoors);
        Destroy(leftDoors);
        Destroy(topDoors);
    }
}
