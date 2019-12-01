using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUse : MonoBehaviour
{
    //Statement

    public float attackSpeed;
    public float useSpeed;
    public float imobilisationTime;
    public int attackDirection;

    public GameObject usedWeapon;
    public GameObject equipiedItem;


    void Update()
    {
        if (Input.GetAxisRaw("AtkUse") > 0 && PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] != null)
        {          
                if (equipiedItem.tag == "Weapon")
                {
                    if (PlayerStatusManager.isPlayerAttackAvailable == true )
                    {
                        StartCoroutine(Attack());
                    }
                }
                else if (equipiedItem.tag == "Consumable")
                {
                    if (PlayerStatusManager.isPlayerUtilisationAvailable == true )
                    {
                        StartCoroutine(ItemUse());
                    }
                }       
        }
    }

    IEnumerator Attack()
    {
        usedWeapon = Instantiate(equipiedItem);
        usedWeapon.transform.parent = GetComponent<Transform>();
        usedWeapon.transform.localPosition = new Vector3(0, 0, 0);

        PlayerStatusManager.isPlayerAttacking = true;

        attackSpeed = usedWeapon.GetComponent<WeaponManager>().weaponAttackSpeed;
        imobilisationTime = usedWeapon.GetComponent<WeaponManager>().weaponImobilisationTime;

        switch (attackDirection)
        {
            case 0:     // up
                usedWeapon.transform.Rotate(0, 0, 0);
                break;
            case 1:     //right
                usedWeapon.transform.Rotate(0, 0, -90);
                break;
            case 2:     //down
                usedWeapon.transform.Rotate(0, 0, 180);
                break;
            case 3:     //left
                usedWeapon.transform.Rotate(0, 0, 90);
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(0.001f);
        usedWeapon.GetComponent<WeaponManager>().WeaponAttack();

        yield return new WaitForSeconds(imobilisationTime);
        Destroy(usedWeapon);
        PlayerStatusManager.isPlayerMoveAvailable = true;
        PlayerStatusManager.isPlayerDashAvailable = true;
        PlayerStatusManager.isPlayerAttacking = false;

        yield return new WaitForSeconds(attackSpeed);

        PlayerStatusManager.isPlayerAttackAvailable = true;
    }

    IEnumerator ItemUse()
    {
        PlayerStatusManager.isPlayerUsing = true;

        yield return null;

        useSpeed = equipiedItem.GetComponent<ItemManager>().useSpeed;

        equipiedItem.GetComponent<ItemManager>().ItemEffectActivation();

        yield return new WaitForSeconds(useSpeed);

        PlayerStatusManager.isPlayerUtilisationAvailable = true;
        PlayerStatusManager.isPlayerDashAvailable = true;
        PlayerStatusManager.isPlayerAttackAvailable = true;
        PlayerStatusManager.isPlayerUsing = false;
    }
}
