using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    private GameObject equipiedItem;
    private int attackDirection;
    private Vector3 lastMove;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        equipiedItem = transform.parent.gameObject.GetComponent<PlayerUse>().equipiedItem;
        attackDirection = transform.parent.gameObject.GetComponent<PlayerUse>().attackDirection;
        lastMove = transform.parent.gameObject.GetComponent<PlayerMovement>().lastMove;

        playerAnimator.SetBool("isDashing", PlayerStatusManager.isDashing);
        playerAnimator.SetBool("isFalling", PlayerStatusManager.isFalling);
        playerAnimator.SetBool("isAttacking", PlayerStatusManager.isAttacking);

        if (PlayerStatusManager.canAttack == true)
        {  
            switch (attackDirection)
            {
                case 0:     // up
                    playerAnimator.SetFloat("yAttackDirection", 1);
                    playerAnimator.SetFloat("xAttackDirection", 0);
                    break;
                case 1:     //right
                    playerAnimator.SetFloat("yAttackDirection", 0);
                    playerAnimator.SetFloat("xAttackDirection", 1);
                    break;
                case 2:     //down
                    playerAnimator.SetFloat("yAttackDirection", -1);
                    playerAnimator.SetFloat("xAttackDirection", 0);
                    break;
                case 3:     //left
                    playerAnimator.SetFloat("yAttackDirection", 0);
                    playerAnimator.SetFloat("xAttackDirection", -1);
                    break;

                default:
                    break;
            }
        }

        if(PlayerStatusManager.isAttacking == true)
        {
            playerAnimator.SetInteger("WeaponId", equipiedItem.GetComponent<WeaponManager>().weaponId);
        }

        if (PlayerMovement.playerRgb.velocity.x != 0 || PlayerMovement.playerRgb.velocity.y != 0)
        {
            playerAnimator.SetBool("isRuning", true);
        }
        else if (PlayerMovement.playerRgb.velocity.x == 0 || PlayerMovement.playerRgb.velocity.y == 0)
        {
            playerAnimator.SetBool("isRuning", false);
        }

        playerAnimator.SetFloat("xDirection", lastMove.x);
        playerAnimator.SetFloat("yDirection", lastMove.y);
    }
}
