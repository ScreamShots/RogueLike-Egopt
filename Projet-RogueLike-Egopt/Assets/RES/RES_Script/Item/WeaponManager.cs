using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float weaponAttackSpeed;
    public float weaponDmg;
    public float weaponImobilisationTime;

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
    public void WeaponAttack()
    {
        for (int i = 0; i < enemyInRangList.Count; i++)
        {
            enemyInRangList[i].GetComponent<EnemyHealthSystem>().IsTakingDmg(weaponDmg);
        }
    }
}
