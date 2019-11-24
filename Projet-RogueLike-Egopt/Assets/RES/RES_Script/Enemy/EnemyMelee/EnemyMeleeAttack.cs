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

    private void Start()
    {
        isEnemyAttackAvailable = true;
        isEnemyAttacking = false;
    }

    private void Update()
    {

        if (isPlayerinRang == true)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        usedWeapon = Instantiate(equipiedItem);
        usedWeapon.transform.parent = GetComponent<Transform>();
        usedWeapon.transform.localPosition = new Vector3(0, 0, 0);

        isEnemyAttackAvailable = false;
        GetComponent<EnemyMeleeMovement>().isEnnemyMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        isEnemyAttacking = true;

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
        isEnemyAttacking = false;

        yield return new WaitForSeconds(attackSpeed);

        isEnemyAttackAvailable = true;
    }
}
