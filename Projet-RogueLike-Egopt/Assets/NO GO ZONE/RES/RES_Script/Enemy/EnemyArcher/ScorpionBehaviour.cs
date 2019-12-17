using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionBehaviour : MonoBehaviour
{
    [HideInInspector] public bool isPlayerInRange;
    [HideInInspector] public bool isPlayerTooClose;

    public float speed;
    public float shotCd;
    [HideInInspector] public float launchingTime;
    [HideInInspector] public bool canShot;
    [HideInInspector] public bool isShooting;


    [HideInInspector] public Rigidbody2D scorpionRgb;
    [HideInInspector] public Transform playerTransform;
    [HideInInspector] public Vector3 move;
    [HideInInspector] public Vector3 lastMove;
    public GameObject scorpionsMunition;

    

    private void Start()
    {
        isPlayerInRange = false;
        isPlayerTooClose = false;
        isShooting = false;

        canShot = true;

        scorpionRgb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindWithTag("Player").transform;

        move = new Vector3(0, 0, 0);
        lastMove = new Vector3(0, 0, 0);
    }

    private void FixedUpdate()
    {
        move = -(transform.position - playerTransform.position).normalized;

        if (isPlayerInRange == false)
        {
            scorpionRgb.velocity = move * speed * Time.fixedDeltaTime;
        }
        else if (isPlayerInRange == true && isPlayerTooClose == false)
        {
            scorpionRgb.velocity = new Vector3(0, 0, 0);
        }
        else if (isPlayerTooClose == true)
        {
            scorpionRgb.velocity = -move * speed * Time.fixedDeltaTime;
        }

        if (isPlayerInRange == true && isPlayerTooClose == false)
        {

            StartCoroutine(Shoot());

        }  
    }

    IEnumerator Shoot()
    {
        if (canShot == true)
        {
            lastMove = move;
            canShot = false;
            isShooting = true;

            yield return new WaitForSeconds(launchingTime);

            if (isPlayerTooClose == true)
            {
                isShooting = false;
                canShot = true;
                lastMove = new Vector3(0, 0, 0);
                yield break;
                
            }
            else
            {
                Instantiate(scorpionsMunition, transform.position, Quaternion.identity);
                isShooting = false;
            }
            
            isShooting = false;

            yield return new WaitForSeconds(shotCd);
            canShot = true;
            lastMove = new Vector3(0, 0, 0);
        }
        
    }
}
