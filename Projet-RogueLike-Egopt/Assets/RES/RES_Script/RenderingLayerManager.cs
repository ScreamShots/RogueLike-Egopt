using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingLayerManager : MonoBehaviour
{
    SpriteRenderer thisSpriteRenderer;
    public float lastY;
    public int baseSortingOrder;
    void Start()
    {       
        lastY = 0;
        if(transform.childCount == 0)
        {
            thisSpriteRenderer = GetComponent<SpriteRenderer>();
        }
        else
        {
            thisSpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        }        
        baseSortingOrder = thisSpriteRenderer.sortingOrder;
    }

   
    void FixedUpdate()
    {
        if (lastY != transform.position.y)
        {
            lastY = transform.position.y;

            if(gameObject.tag == "Player" || gameObject.tag == "Enemy")
            {
                thisSpriteRenderer.sortingOrder = baseSortingOrder - (int)((transform.position.y - 0.25) * 10f);
            }
            else
            {
                thisSpriteRenderer.sortingOrder = baseSortingOrder - (int)(transform.position.y * 10f);
            }           

        }

        
    }
}
