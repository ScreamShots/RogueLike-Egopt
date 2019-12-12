using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthBar : MonoBehaviour
{
    public PlayerHealthSystem playerHealthSystem;
    public Image healthBarFront;
    public Text hpAmoutDisplay;
    public float hpPercentage;

    private void Update()
    {
        playerHealthSystem = GameObject.FindWithTag("Player").GetComponent<PlayerHealthSystem>();
        healthBarFront.fillAmount = playerHealthSystem.playerHp / playerHealthSystem.playerMaxHp;
        hpPercentage = (playerHealthSystem.playerHp / playerHealthSystem.playerMaxHp) * 100;
        hpAmoutDisplay.text = hpPercentage.ToString() + " %";

        if (PlayerHealthSystem.playerIsImune == true)
        {
            healthBarFront.color = Color.magenta;
        }
        else
        {
            healthBarFront.color = Color.white;
        }
    }
    
}
