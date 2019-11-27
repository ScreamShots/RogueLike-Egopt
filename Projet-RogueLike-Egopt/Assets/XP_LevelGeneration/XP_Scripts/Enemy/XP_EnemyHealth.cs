using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP_EnemyHealth : MonoBehaviour
{
    //Statement
    public float enemyMaxHp;
    public float enemyHp;

    public Image healthBarUI;




    void Start()
    {
        enemyHp = enemyMaxHp;
    }


    void Update()
    {
        healthBarUI.fillAmount = enemyHp / enemyMaxHp;
    }

    public void EnemyIsTakingDamage(float damageValue)
    {
        enemyHp -= damageValue;

        if (enemyHp <= 0)
        {
            EnemyIsDead();
        }
    }

    public void EnemyIsDead()
    {
        Destroy(gameObject);
    }

    public void PlayerIsHealing(float healValue)
    {
        enemyHp += healValue;

        if (enemyHp > enemyMaxHp)
        {
            enemyHp = enemyMaxHp;
        }
    }
}
