using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    public  List<GameObject> props;
    private SpriteRenderer charaSpr;
    private SpriteRenderer propsSpr;
    private bool needReOrdering;


    void Start()
    {
        charaSpr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        LayerManaging();
    }

    private void LayerManaging()
    {
        if (props.Count != 0)
        {
            for (int i=0; i<props.Count; i++)
            {
                if (props[i].transform.position.y < transform.position.y - 0.25)
                {

                    propsSpr = props[i].GetComponent<SpriteRenderer>();
                    charaSpr.sortingOrder = propsSpr.sortingOrder - 1;
                    
                }
                else 
                {
                    propsSpr = props[i].GetComponent<SpriteRenderer>();

                    charaSpr.sortingOrder = propsSpr.sortingOrder + 1;                   
                }
            }
        }
    }
}
