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
    public GameObject equipiedItem;
    private GameObject actualItem;
    [HideInInspector] public float additionalStrength;

    //Animator

    public Animator playerAnimator; 


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

        if (PlayerStatusManager.canAttack == true && PlayerStatusManager.isDashing == false && actualItem == null)
        {
            PlayerStatusManager.isAttacking = true;



            actualItem = Instantiate(equipiedItem);
            actualItem.transform.parent = GetComponent<Transform>();
            actualItem.transform.localPosition = new Vector3(0, 0, 0);            

            attackSpeed = actualItem.GetComponent<WeaponManager>().weaponAttackSpeed;
            imobilisationTime = actualItem.GetComponent<WeaponManager>().weaponImobilisationTime;            

            switch (attackDirection)
            {
                case 0:     // up
                    actualItem.transform.Rotate(0, 0, 0);
                    break;
                case 1:     //right
                    actualItem.transform.Rotate(0, 0, -90);
                    break;
                case 2:     //down
                    actualItem.transform.Rotate(0, 0, 180);
                    break;
                case 3:     //left
                    actualItem.transform.Rotate(0, 0, 90);
                    break;

                default:
                    break;
            }

            yield return new WaitForSeconds(0.001f);
            actualItem.GetComponent<WeaponManager>().WeaponAttack(additionalStrength);

            yield return new WaitForSeconds(imobilisationTime);
            Destroy(actualItem);
            PlayerStatusManager.needToEndAttack = true;
            PlayerStatusManager.cdOnAttack = true;

            yield return new WaitForSeconds(attackSpeed);

            PlayerStatusManager.cdOnAttack = false;
        }
    }

    IEnumerator ItemUse()
    {
        if (PlayerStatusManager.canUse == true && PlayerStatusManager.isDashing == false && PlayerStatusManager.isDashing == false && actualItem == null)
        {
            float effectDuration;

            PlayerStatusManager.isUsing = true;

            useSpeed = equipiedItem.GetComponent<ItemManager>().useSpeed;          

            yield return new WaitForSeconds(useSpeed);

            actualItem = Instantiate(equipiedItem, transform.position, transform.rotation);
            actualItem.transform.parent = transform;
            actualItem.GetComponent<ItemManager>().ItemEffectActivation(this.gameObject);
            effectDuration = actualItem.GetComponent<ItemManager>().effectDuration; 

            PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] = null;

            PlayerStatusManager.needToEndUse = true;

            yield return new WaitForSeconds(effectDuration);
            Destroy(actualItem);
        }
        
    }
}
