using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUse : MonoBehaviour
{
    //Statement

    private float attackSpeed;
    private float useSpeed;
    private float imobilisationTime;
    public int attackDirection;

    //[SerializeField] private GameObject usedWeapon;
    public GameObject equipiedItem;


    void Update()
    {
        if (Input.GetAxisRaw("AtkUse") > 0 && PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] != null)
        {          
                if (equipiedItem.tag == "Weapon")
                {             
                        StartCoroutine(Attack());                    
                }
                else if (equipiedItem.tag == "Consumable")
                {                
                        StartCoroutine(ItemUse());                    
                }       
        }
    }

    IEnumerator Attack()
    {
        GameObject usedWeapon;

        if (PlayerStatusManager.canAttack == true && PlayerStatusManager.isDashing == false)
        {
            PlayerStatusManager.isAttacking = true;

            usedWeapon = Instantiate(equipiedItem);
            usedWeapon.transform.parent = GetComponent<Transform>();
            usedWeapon.transform.localPosition = new Vector3(0, 0, 0);            

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
            PlayerStatusManager.needToEndAttack = true;
            PlayerStatusManager.cdOnAttack = true;

            yield return new WaitForSeconds(attackSpeed);

            PlayerStatusManager.cdOnAttack = false;
        }
    }

    IEnumerator ItemUse()
    {
        if (PlayerStatusManager.canUse == true && PlayerStatusManager.isDashing == false)
        {
            PlayerStatusManager.isUsing = true;

            useSpeed = equipiedItem.GetComponent<ItemManager>().useSpeed;
            equipiedItem.GetComponent<ItemManager>().ItemEffectActivation();

            yield return new WaitForSeconds(useSpeed);

            PlayerStatusManager.needToEndUse = true;
        }
        
    }
}
