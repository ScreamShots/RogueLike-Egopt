using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp_LeftChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topDoors;
    public GameObject bottomDoors;
    public GameObject rightDoors;


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(bottomDoors);
        Destroy(rightDoors);
        Destroy(rightDoors);
    }
}
