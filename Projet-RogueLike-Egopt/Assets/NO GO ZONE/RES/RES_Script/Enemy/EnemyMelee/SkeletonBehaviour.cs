using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehaviour : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D skeletonRgb;
    [HideInInspector] public Transform playerTransform;
    public GameObject equipiedWeapon;
    [HideInInspector] public Vector3 move;

    public float speed;
    [HideInInspector]public float attackSpeed;
    [HideInInspector] public float immobilizationTime;
    public float warningTime;

    [HideInInspector] public int direction;
    [HideInInspector] public int attackDirection;
    
    [HideInInspector] public bool isPlayerInRange;
    [HideInInspector] public bool isAttacking;
    [HideInInspector] public bool canAttack;
    [HideInInspector] public bool canMove;




    private void Start()
    {
        skeletonRgb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        isPlayerInRange = false;
        move = new Vector3(0, 0, 0);
        direction = 2;
        isAttacking = false;
        canAttack = true;
        canMove = true;
        attackDirection = 0;

    }

    private void FixedUpdate()
    {
        move = (playerTransform.position - transform.position).normalized;

        if (isPlayerInRange == false && canMove == true)
        {
            skeletonRgb.velocity = move * speed * Time.fixedDeltaTime;
        }
        else if (isPlayerInRange == true)
        {
            skeletonRgb.velocity = new Vector3(0, 0, 0);
            StartCoroutine(Attack());
        }

        Direction();


    }

    void Direction()
    {
        if (move != Vector3.zero)
        {
            if (move.y >= Mathf.Sqrt(2) / 2 && move.x <= Mathf.Sqrt(2) / 2 && move.x >= -Mathf.Sqrt(2) / 2)
            {
                direction = 0;        //up
            }
            else if (move.y <= -Mathf.Sqrt(2) / 2 && move.x <= Mathf.Sqrt(2) / 2 && move.x >= -Mathf.Sqrt(2) / 2)
            {
                direction = 2;        //down               
            }
            else if (move.x >= Mathf.Sqrt(2) / 2 && move.y <= Mathf.Sqrt(2) / 2 && move.y >= -Mathf.Sqrt(2) / 2)
            {
                direction = 1;        //right                
            }
            else if (move.x <= -Mathf.Sqrt(2) / 2 && move.y <= Mathf.Sqrt(2) / 2 && move.y >= -Mathf.Sqrt(2) / 2)
            {
                direction = 3;        //left 
            }
        }
    }

    IEnumerator Attack()
    {
        GameObject actualWeapon = null;

        if (canAttack == true)
        {

            canAttack = false;
            isAttacking = true;
            canMove = false;
            attackDirection = direction;


            yield return new WaitForSeconds(warningTime);

            switch (attackDirection)
            {
                case 0:
                    actualWeapon = Instantiate(equipiedWeapon, transform.position, Quaternion.Euler(0, 0, 0));
                    break;
                case 1:
                    actualWeapon = Instantiate(equipiedWeapon, transform.position, Quaternion.Euler(0, 0, -90));
                    break;
                case 2:
                    actualWeapon = Instantiate(equipiedWeapon, transform.position, Quaternion.Euler(0, 0, 180));
                    break;
                case 3:
                    actualWeapon = Instantiate(equipiedWeapon, transform.position, Quaternion.Euler(0, 0, 90));
                    break;
                default:
                    break;
            }

            attackSpeed = actualWeapon.GetComponent<EnemyWeaponManager>().weaponAttackSpeed;
            immobilizationTime = actualWeapon.GetComponent<EnemyWeaponManager>().weaponImobilisationTime;
            actualWeapon.transform.parent = transform;

            yield return new WaitForSeconds(0.001f);

            actualWeapon.GetComponent<EnemyWeaponManager>().WeaponAttack();

            yield return new WaitForSeconds(immobilizationTime);

            isAttacking = false;
            canMove = true;

            yield return new WaitForSeconds(attackSpeed);

            canAttack = true;

        }
    }
}
