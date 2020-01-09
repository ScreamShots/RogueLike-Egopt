using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingLayerManager : MonoBehaviour
{
    SpriteRenderer[] thisSpriteRenderer;
    public float lastY;
    public int[] baseSortingOrder;
    void Start()
    {       
        lastY = 0;
        if(transform.childCount == 0)
        {
            thisSpriteRenderer = GetComponents<SpriteRenderer>();
        }
        else
        {
            thisSpriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();
        }

        baseSortingOrder = new int[thisSpriteRenderer.Length];

        for (int i = 0; i < baseSortingOrder.Length; i++)
        {
            baseSortingOrder[i] = thisSpriteRenderer[i].sortingOrder;
        }
        
    }

   
    void FixedUpdate()
    {
        if (lastY != transform.position.y)
        {
            lastY = transform.position.y;

            if(gameObject.tag == "Player" || gameObject.tag == "Enemy")
            {

                for (int i = 0; i < thisSpriteRenderer.Length; i++)
                {
                    thisSpriteRenderer[i].sortingOrder = baseSortingOrder[i] - (int)((transform.position.y - 0.25) * 10f);
                }
                
            }
            else
            {

                for (int i = 0; i < thisSpriteRenderer.Length; i++)
                {
                    thisSpriteRenderer[i].sortingOrder = baseSortingOrder[i] - (int)(transform.position.y * 10f);
                }
                
            }           

        }

        
    }
}
