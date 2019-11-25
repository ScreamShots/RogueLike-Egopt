﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeMovement : MonoBehaviour
{
    // Statement

    public bool isEnnemyMoovAvailable;
    public bool playerIsInRang;

    public Vector3 move;
    public Rigidbody2D ennemyRgb;
    public Transform playerTransform;

    public float horizontalMoove;
    public float verticalMoove;
    public float speed;
    public int enemyDirection;

    void Start()
    {
        isEnnemyMoovAvailable = true;
        playerIsInRang = false;
        ennemyRgb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        enemyDirection = 0;
    }

    void FixedUpdate()
    {

        Move();

        Direction();
    }

    
    public void Direction()
    {

        if (move != Vector3.zero)
        {
            if (verticalMoove >= Mathf.Sqrt(2) / 2)
            {
                enemyDirection = 0;        //up
            }
            else if (verticalMoove <= -Mathf.Sqrt(2) / 2)
            {
                enemyDirection = 2;        //down
            }
            else if (horizontalMoove >= Mathf.Sqrt(2) / 2)
            {
                enemyDirection = 1;        //right
            }
            else if (horizontalMoove <= -Mathf.Sqrt(2) / 2)
            {
                enemyDirection = 3;        //left
            }
        }

        //GetComponent<EnemyMeleeAttack>().attackDirection = enemyDirection;
    }

    void Move()
    {
        horizontalMoove = playerTransform.position.x - transform.position.x;
        verticalMoove = playerTransform.position.y - transform.position.y;

        move = new Vector3(horizontalMoove, verticalMoove, 0);

        move.Normalize();

        if (isEnnemyMoovAvailable == true && playerIsInRang == false)
        {
            ennemyRgb.velocity = move * speed * Time.fixedDeltaTime;
        }
    }
}
