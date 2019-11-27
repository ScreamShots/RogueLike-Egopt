using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public bool isEnemyAttackAvailable;
    public bool isEnemyAttacking;
    public bool isPlayerinRang;

    public float attackSpeed;
    public float imobilisationTime;
    public int attackDirection;

    public GameObject usedWeapon;
    public GameObject equipiedItem;
    public GameObject warning;
    public GameObject warningInstanciated;

    public Animator EAAnimator;

    private void Start()
    {
        isEnemyAttackAvailable = true;
        isEnemyAttacking = false;
    }

    private void Update()
    {

        if (isPlayerinRang == true)
        {
            if (isEnemyAttackAvailable == true)
            {
                StartCoroutine(Attack());
            }
            
        }
    }

    IEnumerator Attack()
    {       
        isEnemyAttackAvailable = false;
        GetComponent<EnemyMeleeMovement>().isEnnemyMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        isEnemyAttacking = true;
        attackDirection = GetComponent<EnemyMeleeMovement>().enemyDirection;
        EAAnimator.SetTrigger("isAttacking");

        warningInstanciated = Instantiate(warning);
        warningInstanciated.transform.parent = GetComponent<Transform>();
        warningInstanciated.transform.localPosition = new Vector3(0, 0, 0);

        switch (attackDirection)
        {
            case 0:     // up
                warningInstanciated.transform.Rotate(0, 0, 0);
                break;
            case 1:     //right
                warningInstanciated.transform.Rotate(0, 0, -90);
                break;
            case 2:     //down
                warningInstanciated.transform.Rotate(0, 0, 180);
                break;
            case 3:     //left
                warningInstanciated.transform.Rotate(0, 0, 90);
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(0.7f);
        Destroy(warningInstanciated);

        usedWeapon = Instantiate(equipiedItem);
        usedWeapon.transform.parent = GetComponent<Transform>();
        usedWeapon.transform.localPosition = new Vector3(0, 0, 0);

        attackSpeed = usedWeapon.GetComponent<EnemyWeaponManager>().weaponAttackSpeed;
        imobilisationTime = usedWeapon.GetComponent<EnemyWeaponManager>().weaponImobilisationTime;


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
        usedWeapon.GetComponent<EnemyWeaponManager>().WeaponAttack();

        yield return new WaitForSeconds(imobilisationTime);
        Destroy(usedWeapon);
        GetComponent<EnemyMeleeMovement>().isEnnemyMoovAvailable = true;
        isEnemyAttacking = false;

        yield return new WaitForSeconds(attackSpeed);

        isEnemyAttackAvailable = true;
    }
}
