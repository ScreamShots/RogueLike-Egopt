using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherShot : MonoBehaviour
{
    public GameObject projectile;
    //Shooting
    private float timeBtwShots;
    public float startTimeBtwShots;

    private void FixedUpdate()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.fixedDeltaTime;
        }
    }
}
