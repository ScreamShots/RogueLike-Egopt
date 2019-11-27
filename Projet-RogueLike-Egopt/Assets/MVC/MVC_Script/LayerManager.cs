using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    private GameObject[] props;
    private SpriteRenderer charaSpr;
    private SpriteRenderer propsSpr;


    void Start()
    {
        props = GameObject.FindGameObjectsWithTag("Props");
        charaSpr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        LayerManaging();
    }

    private void LayerManaging()
    {
        if (props.Length != 0)
        {
            for (int i=0; i<props.Length; i++)
            {
                if (props[i].transform.position.y < transform.position.y - 1)
                {
                    propsSpr = props[i].GetComponent<SpriteRenderer>();
                    propsSpr.sortingOrder = charaSpr.sortingOrder + 1; 
                }
                else 
                {
                    propsSpr = props[i].GetComponent<SpriteRenderer>();
                    propsSpr.sortingOrder = charaSpr.sortingOrder - 1;
                }
            }
        }
    }


}
