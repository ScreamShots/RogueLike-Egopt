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

    public string enemyType;

    public GameObject bronzCoin;
    public GameObject silverCoin;
    public GameObject goldCoin;


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
        float randomGold;

        randomGold = Random.Range(1, 101);

        switch (enemyType)
        {
            case "Golem":
                randomGold *= 1.5f;
                break;
            case "Skeleton":
                randomGold *= 0.8f;
                break;
            case "Scorpion":
                randomGold *= 1.1f;
                break;
        }



        if (randomGold < 65 && randomGold > 10)
        {
            Instantiate(bronzCoin, transform.position, Quaternion.identity);
        }
        else if (randomGold < 90)
        {
            Instantiate(silverCoin, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(goldCoin, transform.position, Quaternion.identity);
        }

        GameManager.gameManager.AddScore(enemyType);


        Destroy(this.gameObject);
    }
}
