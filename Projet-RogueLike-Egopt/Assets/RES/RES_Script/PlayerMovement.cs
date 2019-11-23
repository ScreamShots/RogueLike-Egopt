using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Statement

    public Rigidbody2D playerRgb;

    //Move

    public static bool isPlayerMoovAvailable;
    public float speed;
    public Vector3 move;
    public float inputHorizontalMoove;
    public float inputVerticalMoove;

    //Direction

    public int playerDirection;
    public Vector3 lastMove;

    //Dash

    public static bool isPlayerDashAvailable;
    public static bool isPlayerDashing;
    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;
    public AnimationCurve dashCurve;

    void Awake()
    {
        playerRgb = GetComponent<Rigidbody2D>();

        isPlayerMoovAvailable = true;
        isPlayerDashAvailable = true;

        playerDirection = 0;
        lastMove = new Vector3(1, 0, 0);

        isPlayerDashing = false;


    }


    void FixedUpdate()
    {
        Debug.Log(Input.GetAxisRaw("Roll"));

        //Move

        Move();


        //Direction

        Direction();

        //Dash

        if (/*Input.GetButtonDown("Roll") ||*/ Input.GetAxisRaw("Roll") > 0 && isPlayerDashAvailable == true)
        {
            Debug.Log("entrée dans le if");
            StartCoroutine(Dash(lastMove));
        }

    }

    //Move

    public void Move()
    {
        inputHorizontalMoove = Input.GetAxisRaw("HorizontalMove");
        inputVerticalMoove = Input.GetAxisRaw("VerticalMove");

        move = new Vector3(inputHorizontalMoove, inputVerticalMoove, 0);

        if (isPlayerMoovAvailable == true)
        {
            playerRgb.velocity = move.normalized * speed * Time.fixedDeltaTime;
        }
    }

    //Direction

    public void Direction()
    {
        if (move != Vector3.zero)
        {
            lastMove = move;

            if (Mathf.Abs(inputHorizontalMoove) > Mathf.Abs(inputVerticalMoove))
            {
                if (inputHorizontalMoove > 0)
                {
                    playerDirection = 0;      //right
                }
                else if (inputHorizontalMoove < 0)
                {
                    playerDirection = 1;      //left
                }
            }
            else
            {

                if (inputVerticalMoove > 0)
                {
                    playerDirection = 2;      //up
                }
                else if (inputVerticalMoove < 0)
                {
                    playerDirection = 3;      //down
                }
            }
        }
    }


    //Dash

    IEnumerator Dash(Vector3 dashDirection)
    {
        float timer = 0.0f;
        isPlayerDashAvailable = false;
        isPlayerMoovAvailable = false;
        isPlayerDashing = true;

        while (timer < dashTime)
        {
            playerRgb.velocity = dashDirection.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime);
            timer += Time.deltaTime;
            yield return null;
        }

        playerRgb.velocity = Vector3.zero;

        isPlayerMoovAvailable = true;
        isPlayerDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        isPlayerDashAvailable = true;

    }
}
