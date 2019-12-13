using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    public float weaponAttackSpeed;
    public float weaponDmg;
    public float weaponImobilisationTime;

    public List<GameObject> playerInRangList;

    private void OnTriggerEnter2D(Collider2D character)
    {
        if (character.gameObject.tag == "Player")
        {
            playerInRangList.Add(character.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D character)
    {
        if (character.gameObject.tag == "Player")
        {
            playerInRangList.Remove(character.gameObject);
        }

    }
    public void WeaponAttack()
    {
        foreach (GameObject player in playerInRangList)
        {
            player.GetComponent<PlayerHealthSystem>().IsTakingDmg(weaponDmg);
        }
        Destroy(this.gameObject);
    }
}
