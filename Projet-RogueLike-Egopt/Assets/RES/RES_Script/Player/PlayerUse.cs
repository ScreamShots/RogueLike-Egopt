using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUse : MonoBehaviour
{
    //Statement

    public static bool isPlayerAttackAvailable;
    public static bool isPlayerUtilisationAvailable;
    public static bool isPlayerInUse;

    public float attackSpeed;
    public float useSpeed;
    public float imobilisationTime;
    public int attackDirection;

    public GameObject usedWeapon;
    public GameObject equipiedItem;

    void Start()
    {
        isPlayerAttackAvailable = true;
        isPlayerUtilisationAvailable = true;
        isPlayerInUse = false;
    }

    void Update()
    {
        if (Input.GetAxisRaw("AtkUse") > 0)
        {
            if(PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] != null)
            {
                if (equipiedItem.tag == "Weapon")
                {
                    if (isPlayerAttackAvailable == true && PlayerMovement.isPlayerDashing == false)
                    {
                        StartCoroutine(Attack());
                    }
                }

                if (equipiedItem.tag == "Consumable")
                {
                    if (isPlayerUtilisationAvailable == true && PlayerMovement.isPlayerDashing == false)
                    {
                        StartCoroutine(Attack());
                    }
                }
            }        
        }
    }

    IEnumerator Attack()
    {
        usedWeapon = Instantiate(equipiedItem);
        usedWeapon.transform.parent = GetComponent<Transform>();
        usedWeapon.transform.localPosition = new Vector3(0, 0, 0);

        isPlayerAttackAvailable = false;
        PlayerMovement.isPlayerMoovAvailable = false;
        PlayerMovement.isPlayerDashAvailable = false;
        PlayerMovement.playerRgb.velocity = new Vector3(0, 0, 0);
        isPlayerInUse = true;

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
        PlayerMovement.isPlayerMoovAvailable = true;
        PlayerMovement.isPlayerDashAvailable = true;
        isPlayerInUse = false;

        yield return new WaitForSeconds(attackSpeed);

        isPlayerAttackAvailable = true;
    }

    IEnumerator ItemUse()
    {
        isPlayerUtilisationAvailable = false;
        PlayerMovement.isPlayerDashAvailable = false;
        isPlayerAttackAvailable = false;
        isPlayerInUse = true;

        yield return null;

        useSpeed = equipiedItem.GetComponent<ItemManager>().useSpeed;

        equipiedItem.GetComponent<ItemManager>().ItemEffectActivation();

        yield return new WaitForSeconds(useSpeed);

        isPlayerUtilisationAvailable = true;
        PlayerMovement.isPlayerDashAvailable = true;
        isPlayerAttackAvailable = true;
        isPlayerInUse = false;
    }
}
