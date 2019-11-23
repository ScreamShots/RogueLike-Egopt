using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_BottomChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topDoors;
    public GameObject leftDoors;
    public GameObject rightDoors;


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(topDoors);
        Destroy(leftDoors);
        Destroy(rightDoors);
    }
}
