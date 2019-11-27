using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthSystem : MonoBehaviour
{
    //Statement

    public float playerMaxHp;
    public float playerHp;
    //public Image healthBar;

    void Start()
    {
        playerHp = playerMaxHp;
    }

    private void Update()
    {
        //healthBar.fillAmount = playerHp / playerMaxHp;
    }

    public void IsTakingDmg(float damageValue)       //Put every action requiered when the player is taking dmg on this fonction
    {
        playerHp -= damageValue;

        if (playerHp <= 0)
        {
            PlayerDeath();
        }
        Debug.Log(playerHp);
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
        PlayerMovement.isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

    }
}
