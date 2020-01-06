using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPicking : MonoBehaviour
{
    public int goldValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.gameManager.gold += goldValue;
            GameManager.gameManager.score += goldValue;
            Destroy(gameObject);
        }
    }


}
