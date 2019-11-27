using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSystem : MonoBehaviour
{
    //Statement

    public float enemyMaxHp;
    public float enemyHp;
    public Image healthBar;

    void Start()
    {
        enemyHp = enemyMaxHp;
    }

    private void Update()
    {
        healthBar.fillAmount = enemyHp / enemyMaxHp;
    }

    public void IsTakingDmg(float damageValue)       //Put every action requiered when the player is taking dmg on this fonction
    {
        enemyHp -= damageValue;
        Debug.Log("enemy is taking dmg" + enemyHp);

        if (enemyHp <= 0)
        {
            EnemyDeath();
        }
        //Debug.Log(playerHp);
    }

    public void EnemyIsHealing(float healValue)             //Put every action requiered when the player is healed on this fonction  
    {
        enemyHp += healValue;

        if (enemyHp > enemyMaxHp)
        {
            enemyHp = enemyMaxHp;
        }

    }

    void EnemyDeath()                                  //Put every action requiered when the player is dead on this function
    {
        Destroy(this.gameObject);
    }
}
