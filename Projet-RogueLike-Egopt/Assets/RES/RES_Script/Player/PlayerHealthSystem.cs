using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float playerHp;

    public void IsTakingDmg(float dmg)
    {
        playerHp -= dmg;
        Debug.Log(playerHp);
    }
}
