using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthSystem : MonoBehaviour
{
    //Statement

    public float playerMaxHp;
    public float playerMinHp;
    public float playerHp;
    public float playerImmuneTime;

    public static bool playerIsImune;

    void Start()
    {
        playerHp = playerMaxHp;
        playerIsImune = false;
    }
    
    private void Update()
    {
        if (playerHp <= 0)
        {
            PlayerDeath();
        }
    }

    public void IsTakingDmg(float damageValue)       //Put every action requiered when the player is taking dmg on this fonction
    {
        if (playerIsImune == false)
        {
            playerHp -= damageValue;
            StartCoroutine(PlayerImmunityActivation());
        }      
    }

    public void PlayerIsHealing(float healValue)             //Put every action requiered when the player is healed on this fonction  
    {
        playerHp += healValue;

        if (playerHp > playerMaxHp)
        {
            playerHp = playerMaxHp;
        }
    }

    void PlayerDeath()                                  //Put every action requiered when the player is dead on this function
    {
        Debug.Log("Vous êtes mort");

        Destroy(this.gameObject);

    }

    public IEnumerator PlayerImmunityActivation()
    {
        playerIsImune = true;
        Debug.Log("vous êtes temporairement imunisé");

        yield return new WaitForSeconds(playerImmuneTime);

        playerIsImune = false;
        Debug.Log("vous n'êtes plus imunisé");
    }
}
