using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Statement

    public static Rigidbody2D playerRgb;

    //Move

    public static bool isPlayerMoovAvailable;
    public float speed;
    public Vector3 move;
    public float inputHorizontalMoove;
    public float inputVerticalMoove;

    //Direction

    public int playerDirection;
    public Vector3 lastMove;
    public float directionHorizontal;
    public float directionVertical;

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
        //Move

        Move();

        //Direction

        Direction();

        //Dash

        if (Input.GetAxisRaw("Roll") > 0 && isPlayerDashAvailable == true && PlayerUse.isPlayerInUse == false && PlayerHealthSystem.isPlayerDead == false)
        {
            StartCoroutine(Dash(lastMove));
        }
    }

    //Move

    public void Move()
    {
        inputHorizontalMoove = Input.GetAxisRaw("HorizontalMove");
        inputVerticalMoove = Input.GetAxisRaw("VerticalMove");

        move = new Vector3(inputHorizontalMoove, inputVerticalMoove, 0);

        if (isPlayerMoovAvailable == true && PlayerHealthSystem.isPlayerDead == false)
        {
            playerRgb.velocity = move.normalized * speed * Time.fixedDeltaTime;
        }
    }

    //Direction

    public void Direction()
    {
        directionHorizontal = Input.GetAxis("HorizontalMove");
        directionVertical = Input.GetAxis("VerticalMove");
        
        if (move != Vector3.zero)
        {
            lastMove = move;

            if (directionVertical >= Mathf.Sqrt(2)/2)
            {
                playerDirection = 0;        //up
            }
            else if (directionVertical <= -Mathf.Sqrt(2)/2)
            {
                playerDirection = 2;        //down
            }
            else if (directionHorizontal >= Mathf.Sqrt(2)/2)
            {
                playerDirection = 1;        //right
            }
            else if (directionHorizontal <= -Mathf.Sqrt(2)/2)
            {
                playerDirection = 3;        //left
            }
        }

        GetComponent<PlayerUse>().attackDirection = playerDirection;
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
