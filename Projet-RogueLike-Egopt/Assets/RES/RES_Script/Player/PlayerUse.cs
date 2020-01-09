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
    private bool attackSecurityCheck;
    private bool useSecurityCheck;
    public PlayerInventory inventory;

    private void Start()
    {
        attackSecurityCheck = false;
        useSecurityCheck = false;
        inventory = GetComponent<PlayerInventory>();
    }
    void FixedUpdate()
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

        if (PlayerStatusManager.canAttack == true && PlayerStatusManager.isDashing == false && attackSecurityCheck == false)
        {
            PlayerStatusManager.isAttacking = true;
            attackSecurityCheck = true;

            yield return new WaitForSeconds(equipiedItem.GetComponent<WeaponManager>().launchingTime);

            
            actualItem = Instantiate(equipiedItem);
            
            actualItem.transform.parent = GetComponent<Transform>();
            actualItem.transform.localPosition = new Vector3(0, 0, 0);            

            attackSpeed = actualItem.GetComponent<WeaponManager>().weaponAttackSpeed;
            imobilisationTime = actualItem.GetComponent<WeaponManager>().weaponImobilisationTime;            

            switch (attackDirection)
            {
                case 0:     // up
                    actualItem.transform.Rotate(0, 0, 0);
                    if(actualItem.GetComponent<WeaponManager>().weaponId == 1)
                    {
                        actualItem.transform.localPosition += new Vector3(0.105f, 0,0);
                    }
                    break;
                case 1:     //right
                    actualItem.transform.Rotate(0, 0, -90);
                    break;
                case 2:     //down
                    actualItem.transform.Rotate(0, 0, 180);
                    if (actualItem.GetComponent<WeaponManager>().weaponId == 1)
                    {
                        actualItem.transform.localPosition += new Vector3(-0.06f, 0, 0);
                    }
                    break;
                case 3:     //left
                    actualItem.transform.Rotate(0, 0, 90);
                    break;

                default:
                    break;
            }

            yield return new WaitForSeconds(0.1f);

            if (actualItem.GetComponent<WeaponManager>().WeaponAttack(additionalStrength) == true)
            {
                PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().durability -= 1;

                if (PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().durability <= 0)
                {
                    PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().Break();
                }
            }

            yield return new WaitForSeconds(imobilisationTime);

            PlayerStatusManager.needToEndAttack = true;
            PlayerStatusManager.cdOnAttack = true;
            attackSecurityCheck = false;

            yield return new WaitForSeconds(attackSpeed);

            PlayerStatusManager.cdOnAttack = false;
        }
    }

    IEnumerator ItemUse()
    {
        if (PlayerStatusManager.canUse == true && PlayerStatusManager.isDashing == false && PlayerStatusManager.isDashing == false && useSecurityCheck == false)
        {
            float effectDuration;
            useSecurityCheck = true;

            PlayerStatusManager.isUsing = true;

            useSpeed = equipiedItem.GetComponent<ItemManager>().useSpeed;          

            yield return new WaitForSeconds(useSpeed);

            useSecurityCheck = false;
            actualItem = Instantiate(equipiedItem, transform.position, transform.rotation);
            actualItem.transform.parent = transform;
            actualItem.GetComponent<ItemManager>().ItemEffectActivation(this.gameObject);
            effectDuration = actualItem.GetComponent<ItemManager>().effectDuration; 

            PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] = null;

            PlayerStatusManager.needToEndUse = true;
            Debug.Log(PlayerStatusManager.canAttack);
        }
        
    }
}
