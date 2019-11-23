﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int WeaponId;
    public float weaponAttackSpeed;
    public float weaponDmg;
    public float weaponImobilisationTime;

    public List<GameObject> enemyInRangList;

    private void OnTriggerEnter2D(Collider2D character)
    {
        if (character.gameObject.tag == "Enemy")
        {
            enemyInRangList.Add(character.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D character)
    {
        if (character.gameObject.tag == "Enemy")
        {
            enemyInRangList.Remove(character.gameObject);
        }

    }
    public void WeaponAttack()
    {
        foreach (GameObject enemy in enemyInRangList)
        {
            enemy.GetComponent<EnemyHealthSystem>().IsTakingDmg(weaponDmg);
        }        
    }
}
