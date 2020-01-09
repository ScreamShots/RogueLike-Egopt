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

    public bool onSpeedCoRu;
    public bool onForceCoRu;

    private void Update()
    {
       if (boostforce == true && onForceCoRu == false)
        {
            onForceCoRu = true;
            forceBoostUI.SetActive(true);
            StartCoroutine(TimerForceBoost());


        }

       if(speedboost == true && onSpeedCoRu == false)
        {
            onSpeedCoRu = true;
            speedBoostUI.SetActive(true);
            StartCoroutine(TimerForceSpeed());
        }

    }

    IEnumerator TimerForceBoost()
    {
        yield return new WaitForSeconds(effectdurationForce / 10);
        forceTimer += effectdurationForce / 10;
        forceFill.fillAmount = 1 - (forceTimer / effectdurationForce);

        if(forceTimer < effectdurationForce)
        {
            StartCoroutine(TimerForceBoost());
        }
        else
        {
            onForceCoRu = false;
            forceTimer = 0;
            forceBoostUI.SetActive(false);
        }
    }

    IEnumerator TimerForceSpeed()
    {
        yield return new WaitForSeconds(effectdurationSpeed / 10);
        speedTimer += effectdurationSpeed / 10;
        speedFill.fillAmount = 1 - (speedTimer / effectdurationSpeed);

        if (speedTimer < effectdurationSpeed)
        {
            StartCoroutine(TimerForceSpeed());
        }
        else
        {
            onSpeedCoRu = false;
            speedTimer = 0;
            speedBoostUI.SetActive(false);
        }
    }
}
