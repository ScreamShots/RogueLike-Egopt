using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionRendering : MonoBehaviour
{
    public Animator scorpionAnimator;
    public ScorpionBehaviour scorpionBehaviour;

    private void Start()
    {
        scorpionAnimator = GetComponent<Animator>();
        scorpionBehaviour = transform.parent.gameObject.GetComponent<ScorpionBehaviour>();
        
    }

    private void Update()
    {
        scorpionAnimator.SetBool("isAttacking", scorpionBehaviour.isShooting);

        if (scorpionBehaviour.isPlayerTooClose == false)
        {
            scorpionAnimator.SetFloat("xDirection", scorpionBehaviour.move.x);
            scorpionAnimator.SetFloat("yDirection", scorpionBehaviour.move.y);
        }
        else if (scorpionBehaviour.isPlayerTooClose == true)
        {
            scorpionAnimator.SetFloat("xDirection", -scorpionBehaviour.move.x);
            scorpionAnimator.SetFloat("yDirection", -scorpionBehaviour.move.y);
        }

        scorpionAnimator.SetFloat("xAttackDirection", scorpionBehaviour.lastMove.x);
        scorpionAnimator.SetFloat("yAttackDirection", scorpionBehaviour.lastMove.y);

        if(scorpionBehaviour.isShooting == false && scorpionBehaviour.isPlayerInRange == true && scorpionBehaviour.isPlayerTooClose == false)
        {
            scorpionAnimator.speed = 0;
        }
        else
        {
            scorpionAnimator.speed = 1;
        }

    }
}
