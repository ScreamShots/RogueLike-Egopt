using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDIcono : MonoBehaviour
{
    public GameObject forceBoostUI;
    public GameObject speedBoostUI;

    public Image forceFill;
    public Image speedFill;

    public float forceTimer=0;
    public float speedTimer=0;

    static public bool boostforce = false;
    static public bool speedboost = false;
    static public float effectdurationSpeed;
    static public float effectdurationForce;

    private void Update()
    {
       if (boostforce == true)
        {
            forceBoostUI.SetActive(true);
            forceTimer += Time.fixedDeltaTime;
            forceFill.fillAmount =  1-(forceTimer / effectdurationForce);
            
        }
        else
        {
            forceTimer = 0;
            forceBoostUI.SetActive(false);
        }

       if(speedboost == true)
        {
            speedBoostUI.SetActive(true);
            speedTimer += Time.fixedDeltaTime;
            speedFill.fillAmount = 1-(speedTimer / effectdurationSpeed);
        }
        else
        {
            speedTimer = 0;
            speedBoostUI.SetActive(false);
        }
    }
}
