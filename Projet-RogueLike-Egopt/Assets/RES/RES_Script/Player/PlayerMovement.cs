using System.Collections;
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
    private Vector3 lastMove;
    private float directionHorizontal;
    private float directionVertical;

    //Dash

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    [SerializeField] private AnimationCurve dashCurve;

    //Fall

    public static Vector3 respawnPosition;
    [SerializeField] private float fallingTime;

    //Animator

    public Animator playerAnimator;


    void Start()
    {
        playerRgb = GetComponent<Rigidbody2D>();

        direction = 0;
        lastMove = new Vector3(1, 0, 0);
        respawnPosition = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        //Direction

        Direction();

        //Move

        if (PlayerStatusManager.canMove == true)
        {
            Move();
        }

        //Dash

        if (Input.GetAxisRaw("Roll") > 0)
        {
            StartCoroutine(Dash(lastMove));
        }

        
        
        if (playerRgb.velocity.x != 0 || playerRgb.velocity.y != 0)
        {
            playerAnimator.SetBool("isRuning", true);
        }
        else if (playerRgb.velocity.x == 0 || playerRgb.velocity.y == 0)
        {
            playerAnimator.SetBool("isRuning", false);
        }

    }

    //Move

    void Move()
    {
        
        inputHorizontalMoove = Input.GetAxisRaw("HorizontalMove");
        inputVerticalMoove = Input.GetAxisRaw("VerticalMove");

        

        move = new Vector3(inputHorizontalMoove, inputVerticalMoove, 0);

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

            if (directionVertical >= Mathf.Sqrt(2)/2)
            {
                direction = 0;        //up
            }
            else if (directionVertical <= -Mathf.Sqrt(2)/2)
            {
                direction = 2;        //down
            }
            else if (directionHorizontal >= Mathf.Sqrt(2)/2)
            {
                direction = 1;        //right
            }
            else if (directionHorizontal <= -Mathf.Sqrt(2)/2)
            {
                direction = 3;        //left
            }
        }

        GetComponent<PlayerUse>().attackDirection = direction;
        playerAnimator.SetFloat("xDirection", lastMove.x);
        playerAnimator.SetFloat("yDirection", lastMove.y);

    }


    //Dash

    IEnumerator Dash(Vector3 dashDirection)
    {
        if (PlayerStatusManager.canDash == true && PlayerStatusManager.isAttacking == false && PlayerStatusManager.isUsing == false)
        {
            float timer = 0.0f;

            PlayerStatusManager.isDashing = true;

            while (timer < dashTime)
            {
                playerRgb.velocity = dashDirection.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime) * Time.deltaTime;
                timer += Time.deltaTime;
                yield return null;
            }

            playerRgb.velocity = Vector3.zero;

            PlayerStatusManager.needToEndDash = true;
            PlayerStatusManager.cdOnDash = true;

            yield return new WaitForSeconds(dashCooldown);

            PlayerStatusManager.cdOnDash = false;
        }     
    }

    //Fall

    IEnumerator PlayerFall(float dmg)
    {
        if (PlayerStatusManager.canFall)
        {
            PlayerStatusManager.isFalling = true;

            yield return new WaitForSeconds(fallingTime);

            GetComponent<Transform>().position = respawnPosition;

            GetComponent<SpriteRenderer>().color = Color.white; // Temporary FeedBack
            GetComponent<PlayerHealthSystem>().IsTakingDmg(dmg);

            PlayerStatusManager.needToEndFall = true;
        }
       
    }
}
