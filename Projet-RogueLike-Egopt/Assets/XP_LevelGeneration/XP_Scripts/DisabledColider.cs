using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledColider : MonoBehaviour
{
    private BoxCollider2D bxC;
    public GameObject gamemanager;


    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameController");
        bxC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.GetComponent<GameManager>().canDeleted == true)
        {
            bxC.enabled = false;
        }
    }
}
