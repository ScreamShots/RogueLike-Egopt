﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float weaponAttackSpeed;
    public float weaponDmg;
    public float weaponImobilisationTime;
    public float launchingTime;

    [SerializeField] public Sprite iconDisplay; //Temporary Inventory UI

    public List<GameObject> enemyInRangList;

    public int weaponId; // 0 = saber 1 = spear 2 = hammer

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
    public void WeaponAttack(float adDmg)
    {
        for (int i = 0; i < enemyInRangList.Count; i++)
        {
            if(enemyInRangList[i] != null)
            {
                enemyInRangList[i].GetComponent<EnemyHealthSystem>().IsTakingDmg(weaponDmg + adDmg);
            }
            
        }
        Destroy(this.gameObject);
    }
}
