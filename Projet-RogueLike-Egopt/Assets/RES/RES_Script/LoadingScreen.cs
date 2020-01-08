using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public float timer;
    public Text loadingPoint;

    public void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if(timer >= 3f)
        {
            loadingPoint.text = " ";
            timer = 0;
        }
        if(timer >= 2.25f)
        {
            loadingPoint.text = ". . .";
            timer += Time.fixedDeltaTime;
        }
        else if (timer >= 1.5f)
        {
            loadingPoint.text = ". .";
            timer += Time.fixedDeltaTime;
        }
        else if (timer >= 0.75f)
        {
            loadingPoint.text = ".";
            timer += Time.fixedDeltaTime;
        }
        else
        {
            timer += Time.fixedDeltaTime;
        }
    }
    
}
