using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionBehaviour : MonoBehaviour
{
    [HideInInspector] public bool isPlayerInRange;
    [HideInInspector] public bool isPlayerTooClose;
    [HideInInspector] public bool isOnAWall;

    [SerializeField] private float speed;
    [SerializeField] private float shotCd;
    private float actualShotCd;

    private Rigidbody2D scorpionRgb;
    private Transform playerTransform;
    private Vector3 move;
    [SerializeField] private GameObject scorpionsMunition;
    private GameObject actualMunition;
    

    private void Start()
    {
        isPlayerInRange = false;
        isPlayerTooClose = false;
        isOnAWall = false;

        actualShotCd = 0;

        scorpionRgb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindWithTag("Player").transform;

        move = new Vector3(0, 0, 0);
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

        if (actualShotCd <= 0 && isPlayerInRange == true && isPlayerTooClose == false)
        {
            actualMunition = Instantiate(scorpionsMunition, transform.position, Quaternion.identity);
            Debug.Log(isOnAWall);


            actualShotCd = shotCd;
        }
        else
        {
            actualShotCd -= Time.fixedDeltaTime;
        }

        if (isOnAWall == false && actualMunition != null)
        {
            actualMunition.GetComponent<ScorpionMunition>().isDestructible = true;
        }
    }
}
