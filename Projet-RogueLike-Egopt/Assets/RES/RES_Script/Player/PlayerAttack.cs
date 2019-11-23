using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Statement

    public static bool isPlayerAttackAvailable;

    public float attackSpeed;
    public float imobilisationTime;
    public int attackDirection;

    public GameObject equipiedWeapon;
    public GameObject usedWeapon;

    void Start()
    {
        isPlayerAttackAvailable = true;
    }

    void Update()
    {
        if (Input.GetAxisRaw("AtkUse") > 0)
        {
            if (isPlayerAttackAvailable == true && PlayerMovement.isPlayerDashing == false)
            {
                StartCoroutine(Attack());
            }
        }

    }

    IEnumerator Attack()
    {
        usedWeapon = Instantiate(equipiedWeapon);
        usedWeapon.transform.parent = GetComponent<Transform>();
        usedWeapon.transform.localPosition = new Vector3(0, 0, 0);

        isPlayerAttackAvailable = false;
        PlayerMovement.isPlayerMoovAvailable = false;
        PlayerMovement.isPlayerDashAvailable = false;
        PlayerMovement.playerRgb.velocity = new Vector3(0,0,0);

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

        yield return new WaitForSeconds(attackSpeed);
        
        isPlayerAttackAvailable = true;
    }
}
