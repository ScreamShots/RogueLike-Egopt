using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman : MonoBehaviour
{
    public int repearValue;



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision" && collision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            StopAllCoroutines();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CharacterGroundCollision" && collision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            StartCoroutine(RepearWeapon());
        }
    }    

    IEnumerator RepearWeapon()
    {
        if(PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].tag == "Weapon")
        {
            if (PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().durability < PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().maxdurability)
            {
                PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().durability += repearValue;
            }
        }

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(RepearWeapon());
    }
}
