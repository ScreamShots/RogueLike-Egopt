using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledColider : MonoBehaviour
{
    private BoxCollider2D bxC;


    // Start is called before the first frame update
    void Start()
    {
        bxC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<GameManager>().canDeleted == true)
        {
            bxC.enabled = false;
        }
    }
}
