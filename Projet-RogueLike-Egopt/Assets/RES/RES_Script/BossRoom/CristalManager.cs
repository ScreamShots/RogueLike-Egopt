using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalManager : MonoBehaviour
{
    public static CristalManager cristalInstance;

    [SerializeField] float maxCristalHealthPhaseOne;
    [SerializeField] float maxCristalHealthPhaseTwo;
    [SerializeField] float maxCristalHealthPhaseThree;
    [SerializeField] float maxCristalHealthPhaseFour;
    [SerializeField] float maxCristalHealthPhaseFive;

    [SerializeField] float cristalHealthPhaseOne;
    [SerializeField] float cristalHealthPhaseTwo;
    [SerializeField] float cristalHealthPhaseThree;
    [SerializeField] float cristalHealthPhaseFour;
    [SerializeField] float cristalHealthPhaseFive;

    [SerializeField] Transform[] standPositions;

    [SerializeField] WaveManager waveManager;

    [SerializeField] bool canTakeDmgOnOne = true;
    [SerializeField] bool canTakeDmgOnTwo = false;
    [SerializeField] bool canTakeDmgOnThree = false;
    [SerializeField] bool canTakeDmgOnFour = false;
    [SerializeField] bool canTakeDmgOnFive = false;

    [SerializeField] GameObject[] fragements;
    [SerializeField] GameObject[] talismans;

    void Start()
    {
        if (cristalInstance == null)
        {
            cristalInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        transform.position = standPositions[0].position;

        cristalHealthPhaseFive = maxCristalHealthPhaseFive;
        cristalHealthPhaseFour = maxCristalHealthPhaseFour;
        cristalHealthPhaseOne = maxCristalHealthPhaseOne;
        cristalHealthPhaseThree = maxCristalHealthPhaseThree;
        cristalHealthPhaseTwo = maxCristalHealthPhaseTwo;

        talismans[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmgValue)
    {
        Debug.Log("Hit");
        if (cristalHealthPhaseOne > 0)
        {
            if (cristalHealthPhaseOne == maxCristalHealthPhaseOne && canTakeDmgOnOne == true)
            {
                waveManager.LaunchPhaseOne();
                cristalHealthPhaseOne -= dmgValue;
            }
            else if (canTakeDmgOnOne == true)
            {
                cristalHealthPhaseOne -= dmgValue;
            }

            if (cristalHealthPhaseOne <= 0)
            {
                DestroyCristal(1);
            }

        }
        else if(cristalHealthPhaseTwo > 0 && canTakeDmgOnTwo == true)
        {
            if (cristalHealthPhaseTwo == maxCristalHealthPhaseTwo)
            {
                waveManager.LaunchPhaseTwo();
                cristalHealthPhaseTwo -= dmgValue;
            }
            else if(canTakeDmgOnTwo == true)
            {
                cristalHealthPhaseTwo -= dmgValue;
            }

            if (cristalHealthPhaseTwo <= 0)
            {
                DestroyCristal(2);
            }

        }
        else if(cristalHealthPhaseThree > 0)
        {
            if (cristalHealthPhaseThree == maxCristalHealthPhaseThree && canTakeDmgOnThree == true)
            {
                waveManager.LaunchPhaseThree();
                cristalHealthPhaseThree -= dmgValue;
            }
            else if(canTakeDmgOnThree == true)
            {
                cristalHealthPhaseThree -= dmgValue;
            }

            if (cristalHealthPhaseThree <= 0)
            {
                DestroyCristal(3);
            }

        }
        else if(cristalHealthPhaseFour > 0)
        {
            if (cristalHealthPhaseFour == maxCristalHealthPhaseFour && canTakeDmgOnFour == true)
            {
                waveManager.LaunchPhaseFour();
                cristalHealthPhaseFour -= dmgValue;
            }
            else if(canTakeDmgOnFour == true)
            {
                cristalHealthPhaseFour -= dmgValue;
            }

            if (cristalHealthPhaseFour <= 0)
            {
                DestroyCristal(4);
            }

        }
        else
        {
            if (cristalHealthPhaseFive == maxCristalHealthPhaseFive && canTakeDmgOnFive == true)
            {
                waveManager.LaunchPhaseFive();
                cristalHealthPhaseFive -= dmgValue;
            }
            else if(canTakeDmgOnFive == true)
            {
                cristalHealthPhaseFive -= dmgValue;
            }

            if (cristalHealthPhaseFive <= 0)
            {
                DestroyCristal(5);
            }

        }        
    }

    void DestroyCristal(int phase)
    {
        switch (phase)
        {
            case 1:
                transform.position = standPositions[3].position;
                fragements[0].SetActive(false);                
                waveManager.StopAllCoroutines();
                canTakeDmgOnTwo = true;
                canTakeDmgOnOne = false;
                break;
            case 2:
                transform.position = standPositions[2].position;
                fragements[1].SetActive(false);
                talismans[0].SetActive(false);
                talismans[1].SetActive(true);
                waveManager.StopAllCoroutines();
                canTakeDmgOnThree = true;
                canTakeDmgOnTwo = false;
                break;
            case 3:
                transform.position = standPositions[1].position;
                fragements[2].SetActive(false);
                talismans[1].SetActive(false);
                talismans[2].SetActive(true);
                waveManager.StopAllCoroutines();
                canTakeDmgOnFour = true;
                canTakeDmgOnThree = false;
                break;
            case 4:
                transform.position = standPositions[0].position;
                fragements[3].SetActive(false);
                waveManager.StopAllCoroutines();
                canTakeDmgOnFive = true;
                canTakeDmgOnFour = false;
                break;
            case 5:
                waveManager.StopPhaseFive();
                talismans[2].SetActive(false);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
