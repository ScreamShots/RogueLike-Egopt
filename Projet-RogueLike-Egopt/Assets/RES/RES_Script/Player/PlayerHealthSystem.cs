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
    public Image healthBar;

    void Start()
    {
        playerHp = playerMaxHp;
    }
    
    private void Update()
    {

        //healthBar.fillAmount = playerHp / playerMaxHp;

        if (playerHp <= 0)
        {
            PlayerDeath();
        }
    }

    public void IsTakingDmg(float damageValue)       //Put every action requiered when the player is taking dmg on this fonction
    {
        if (PlayerStatusManager.isPlayerImmune == false)
        {
            playerHp -= damageValue;
            StartCoroutine("PlayerImmunityActivation");
        }      
    }

    public void PlayerIsHealing(float healValue)             //Put every action requiered when the player is healed on this fonction  
    {
        if(PlayerStatusManager.isPlayerDead == false)
        {
            playerHp += healValue;

            if (playerHp > playerMaxHp)
            {
                playerHp = playerMaxHp;
            }
        }
    }

    void PlayerDeath()                                  //Put every action requiered when the player is dead on this function
    {
        Debug.Log("Vous êtes mort");

        PlayerStatusManager.isPlayerDead = true;

        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);


    }

    public IEnumerator PlayerImmunityActivation()
    {
        PlayerStatusManager.isPlayerImmune = true;

        yield return new WaitForSeconds(playerImmuneTime);

        GetComponent<SpriteRenderer>().color = Color.white; //TEmporaryFeedBack

        PlayerStatusManager.isPlayerImmune = false;
    }
}
