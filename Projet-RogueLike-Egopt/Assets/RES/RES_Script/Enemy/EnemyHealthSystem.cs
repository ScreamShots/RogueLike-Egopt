using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
  public void IsTakingDmg(float dmg)
    {
        Debug.Log("Enemy prend" + dmg);
    }
}
