using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthBar : MonoBehaviour
{
    public PlayerHealthSystem playerHealthSystem;
    public Image healthBarFront;
    public Image healthBarBack;
    public bool playerSpawned;
    public float lastHpAmout;


    private void Start()
    {
        playerSpawned = false;
    }

    private void Update()
    {
        if (playerSpawned == true)
        {
            healthBarFront.fillAmount = playerHealthSystem.playerHp / playerHealthSystem.playerMaxHp;
            healthBarBack.fillAmount = lastHpAmout / playerHealthSystem.playerMaxHp;

            /*if (PlayerHealthSystem.playerIsImune == true)
            {
                healthBarFront.color = Color.magenta;
            }
            else
            {
                healthBarFront.color = Color.white;
            }*/

            if (playerHealthSystem.playerLostHp < lastHpAmout)
            {
                lastHpAmout -= Time.fixedDeltaTime * 50;
            }
            else if(playerHealthSystem.playerLostHp > lastHpAmout)
            {
                lastHpAmout = playerHealthSystem.playerLostHp;
            }



        }
        else
        {
            GameObject player = GameObject.FindWithTag("Player");

            if(player != null)
            {
                playerHealthSystem = player.GetComponent<PlayerHealthSystem>();
                playerSpawned = true;
            }
        }

        
    }
    
}
