using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float weaponAttackSpeed;
    public float weaponDmg;
    public float weaponImobilisationTime;
    public float launchingTime;
    public float durability;
    public float maxdurability;

    public bool isBroke;
    public GameObject brokeMode;

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


    public void Break()
    {
        if (isBroke == false)
        {
            PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] = brokeMode;
            Destroy(PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex]);
            PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex] = Instantiate(brokeMode);
            PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].SetActive(false);

            Destroy(gameObject);
        }


    }

    public bool WeaponAttack(float adDmg)
    {
        bool enemyInRang = false;
        StartCoroutine(WeaponAttackBis(adDmg));
        Debug.Log(enemyInRangList.Count);

        for (int i = 0; i <enemyInRangList.Count; i++)
        {
            if(enemyInRangList[i] != null)
            {
                Debug.Log("test");
                enemyInRang = true;
            }
        }

        if(enemyInRang == true)
        {
            return true;
        }
        else
        {
            return false;
        }     

    }

    IEnumerator WeaponAttackBis(float adDmg)
    {

        for (int i = 0; i < enemyInRangList.Count; i++)
        {
            if (enemyInRangList[i] != null)
            {
                enemyInRangList[i].GetComponent<EnemyHealthSystem>().IsTakingDmg(weaponDmg + adDmg);
            }

        }
        yield return new WaitForSeconds(0.01f);

        Destroy(this.gameObject);
    }
}
