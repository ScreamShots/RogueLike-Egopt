using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperateCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GoldCounterScript.goldsCounter += 10;
            Destroy(gameObject);
        }
    }



}
