﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Statement

    public static Rigidbody2D playerRgb;

    //Move

    public float speed;
    [SerializeField]private Vector3 move;
    private float inputHorizontalMoove;
    private float inputVerticalMoove;

    //Direction

    private int direction;
    public Vector3 lastMove;
    private float directionHorizontal;
    private float directionVertical;

    //Dash

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    [SerializeField] private AnimationCurve dashCurve;
    public float dashDistance;

    //Fall

    public static Vector3 respawnPosition;
    [SerializeField] private float fallingTime;


    //Music
    public AudioSource playerAudioSource;

    void Start()
    {
        playerRgb = GetComponent<Rigidbody2D>();

        direction = 0;
        lastMove = new Vector3(1, 0, 0);
        respawnPosition = new Vector3(0, 0, 0);

        playerAudioSource = GetComponent<Audio_Manager_Player>().audioSourcePlayer;
    }

    void FixedUpdate()
    {
        //Direction

        Direction();

        //Move
        inputHorizontalMoove = Input.GetAxisRaw("HorizontalMove");

        inputVerticalMoove = Input.GetAxisRaw("VerticalMove");

        move = new Vector3(inputHorizontalMoove, inputVerticalMoove, 0);

        if (PlayerStatusManager.canMove == true)
        {
            Move();
        }


        //Dash

        if (Input.GetAxisRaw("Roll") > 0)
        {
            if (PlayerStatusManager.canDash == true)
            {
                playerAudioSource.clip = GetComponent<Audio_Manager_Player>().playerAudioClip[4];
                playerAudioSource.Play();
                StartCoroutine(Dash(lastMove));
                
            }

        }
        dashTime = dashDistance / dashSpeed;
    }

    //Move

    void Move()
    {
        playerRgb.velocity = move.normalized * speed * Time.fixedDeltaTime;
        
    }

    //Direction

    void Direction()
    {
        directionHorizontal = Input.GetAxis("HorizontalMove");
        directionVertical = Input.GetAxis("VerticalMove");

       

        if (move != Vector3.zero)
        {
            lastMove = move;

            if (directionVertical >= Mathf.Sqrt(2)/2 && directionHorizontal <= Mathf.Sqrt(2) / 2 && directionHorizontal >= -Mathf.Sqrt(2) / 2)
            {
                direction = 0;        //up
            }
            else if (directionVertical <= -Mathf.Sqrt(2)/2 && directionHorizontal <= Mathf.Sqrt(2) / 2 && directionHorizontal >= -Mathf.Sqrt(2) / 2)
            {
                direction = 2;        //down               
            }
            else if (directionHorizontal >= Mathf.Sqrt(2)/2 && directionVertical <= Mathf.Sqrt(2) / 2 && directionVertical >= -Mathf.Sqrt(2) / 2)
            {
                direction = 1;        //right                
            }
            else if (directionHorizontal <= -Mathf.Sqrt(2)/2 && directionVertical <= Mathf.Sqrt(2) / 2 && directionVertical >= -Mathf.Sqrt(2) / 2)
            {
                direction = 3;        //left 
            }
        }
        GetComponent<PlayerUse>().attackDirection = direction;        
    }


    //Dash

    IEnumerator Dash(Vector3 dashDirectio)
    {
        if (PlayerStatusManager.canDash == true && PlayerStatusManager.isAttacking == false && PlayerStatusManager.isUsing == false)
        {
            
            PlayerStatusManager.isDashing = true;
            PlayerStatusManager.canDash = false;

            float timer = 0.0f;
            Vector3 dashDirection = new Vector3(0,0,0);

            if(move != Vector3.zero) //move.x != 0 || move.y != 0
            {
                dashDirection = move.normalized;
            }
            else if (move == Vector3.zero) //move.x == 0 && move.y == 0
            {
                dashDirection = lastMove.normalized;
            }
            

            while (timer < dashTime)
            {
                playerRgb.velocity = dashDirection.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime) * Time.deltaTime;
                timer += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }

            playerRgb.velocity = Vector3.zero;

            PlayerStatusManager.needToEndDash = true;
            
            PlayerStatusManager.cdOnDash = true;

            yield return new WaitForSeconds(dashCooldown);

            PlayerStatusManager.cdOnDash = false;
        }     
    }

    //Fall
    public void StartFall(float dmg, Transform fallPosition, Transform playerPosition)
    {
        playerAudioSource.clip = GetComponent<Audio_Manager_Player>().playerAudioClip[5];
        playerAudioSource.Play();
        StartCoroutine(PlayerFall(dmg, fallPosition, playerPosition));
    }
    public IEnumerator PlayerFall(float dmg, Transform fallPosition, Transform playerPosition)
    {
        if (PlayerStatusManager.canFall)
        {
            PlayerStatusManager.isFalling = true;

            GetComponent<Transform>().position = fallPosition.position + new Vector3(0,0.3f,0) ;
            

            yield return new WaitForSeconds(fallingTime);

            GetComponent<Transform>().position = respawnPosition;

            GetComponent<PlayerHealthSystem>().IsTakingDmg(dmg);

            PlayerStatusManager.needToEndFall = true;
        }
       
    }

    public void StartFallBis(float dmg, Transform fallPosition, Transform playerPosition)
    {
        StartCoroutine(PlayerFallBis(dmg, fallPosition, playerPosition));
    }
    public IEnumerator PlayerFallBis(float dmg, Transform fallPosition, Transform playerPosition)
    {
        if (PlayerStatusManager.canFall)
        {
            PlayerStatusManager.isFalling = true;

            GetComponent<Transform>().position = fallPosition.position;


            yield return new WaitForSeconds(fallingTime);

            GetComponent<Transform>().position = respawnPosition;

            GetComponent<PlayerHealthSystem>().IsTakingDmg(dmg);

            PlayerStatusManager.needToEndFall = true;
        }

    }


}
