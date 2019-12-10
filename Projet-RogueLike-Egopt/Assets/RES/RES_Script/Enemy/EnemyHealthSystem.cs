using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSystem : MonoBehaviour
{
    //Statement

    public float enemyMaxHp;
    public float enemyHp;

    public Image HpBarFront;
    public Image HpBarBack;


    void Start()
    {
        enemyHp = enemyMaxHp;
        
    }

    private void Update()
    {
        HpBarFront.fillAmount = enemyHp / enemyMaxHp;
    }

    public void IsTakingDmg(float damageValue)       //Put every action requiered when the player is taking dmg on this fonction
    {
        enemyHp -= damageValue;
        Debug.Log("enemy is taking dmg" + enemyHp);

        if (enemyHp <= 0)
        {
            EnemyDeath();
        }
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
        Debug.Log("dead");
        Destroy(this.gameObject);
    }
}
