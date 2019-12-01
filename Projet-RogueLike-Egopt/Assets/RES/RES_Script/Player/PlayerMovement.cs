using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Statement

    public static Rigidbody2D playerRgb;
    public GameObject respawnPoint;

    //Move

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

    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;
    public AnimationCurve dashCurve;

    //Fall

    void Awake()
    {
        playerRgb = GetComponent<Rigidbody2D>();

        playerDirection = 0;
        lastMove = new Vector3(1, 0, 0);
    }

    void FixedUpdate()
    {
        //Move
        if (PlayerStatusManager.isPlayerMoveAvailable == true)
        {
            Move();
        }
          
        //Direction

        Direction();

        //Dash

        if (Input.GetAxisRaw("Roll") > 0 && PlayerStatusManager.isPlayerDashAvailable == true )
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

        playerRgb.velocity = move.normalized * speed * Time.fixedDeltaTime;
        
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
        PlayerStatusManager.isPlayerDashing = true;

        while (timer < dashTime)
        {
            playerRgb.velocity = dashDirection.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime);
            timer += Time.deltaTime;
            yield return null;
        }

        playerRgb.velocity = Vector3.zero;

        PlayerStatusManager.isPlayerMoveAvailable = true;
        PlayerStatusManager.isPlayerDashing = false;
        PlayerStatusManager.isPlayerUtilisationAvailable = true;
        PlayerStatusManager.isPlayerAttackAvailable = true;

        yield return new WaitForSeconds(dashCooldown);
        PlayerStatusManager.isPlayerDashAvailable = true;
    }

    //Fall

    public IEnumerator PlayerFall(float dmg)
    {
        if (PlayerStatusManager.isPlayerFallAvailable)
        {
            PlayerStatusManager.isPlayerFalling = true;


            yield return new WaitForSeconds(1.3f);

            GetComponent<Transform>().position = new Vector3(0, 0, 0);

            GetComponent<SpriteRenderer>().color = Color.white; // Temporary FeedBack
            GetComponent<PlayerHealthSystem>().IsTakingDmg(dmg);

            PlayerStatusManager.isPlayerMoveAvailable = true;
            PlayerStatusManager.isPlayerDashAvailable = true;
            PlayerStatusManager.isPlayerFallAvailable = true;
            PlayerStatusManager.isPlayerFalling = false;
            PlayerStatusManager.isPlayerUtilisationAvailable = true;
            PlayerStatusManager.isPlayerAttackAvailable = true;
        }
       
    }
}
