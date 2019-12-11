using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthBar : MonoBehaviour
{
    public PlayerHealthSystem playerHealthSystem;

    public Image healthBarFront;

    private void Start()
    {
        playerHealthSystem = GameObject.FindWithTag("Player").GetComponent<PlayerHealthSystem>();
    }

    private void Update()
    {
        healthBarFront.fillAmount = playerHealthSystem.playerHp / playerHealthSystem.playerMaxHp;

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
