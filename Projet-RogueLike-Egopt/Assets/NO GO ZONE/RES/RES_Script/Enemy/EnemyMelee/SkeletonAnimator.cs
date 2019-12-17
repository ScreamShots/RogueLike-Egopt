using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimator : MonoBehaviour
{
    private Animator skeletonAnimator;
    private SkeletonBehaviour thisSkeletonBehaviour;

    private void Start()
    {
        skeletonAnimator = GetComponent<Animator>();
        thisSkeletonBehaviour = transform.parent.gameObject.GetComponent<SkeletonBehaviour>();

    }

    private void Update()
    {
        skeletonAnimator.SetFloat("xDirection", thisSkeletonBehaviour.move.x);
        skeletonAnimator.SetFloat("yDirection", thisSkeletonBehaviour.move.y);

        skeletonAnimator.SetBool("isAttacking", thisSkeletonBehaviour.isAttacking);
        

        switch (thisSkeletonBehaviour.attackDirection)
        {
            case 0:
                skeletonAnimator.SetFloat("xAttackDirection", 0f);
                skeletonAnimator.SetFloat("yAttackDirection", 1f);
                break;
            case 1:
                skeletonAnimator.SetFloat("xAttackDirection", 1f);
                skeletonAnimator.SetFloat("yAttackDirection", 0f);
                break;
            case 2:
                skeletonAnimator.SetFloat("xAttackDirection", 0);
                skeletonAnimator.SetFloat("yAttackDirection", -1f);
                break;
            case 3:
                skeletonAnimator.SetFloat("xAttackDirection", -1f);
                skeletonAnimator.SetFloat("yAttackDirection", 0f);
                break;
            default:
                break; ;
        }
    }
}
