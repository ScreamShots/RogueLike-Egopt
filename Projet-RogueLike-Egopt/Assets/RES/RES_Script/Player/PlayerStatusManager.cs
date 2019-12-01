using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    //Movement Status

    public static bool isPlayerMoveAvailable;
    public static bool isPlayerDashAvailable;
    public static bool isPlayerDashing;
    public static bool isPlayerFallAvailable;
    public static bool isPlayerFalling;

    //Use - Attack Status

    public static bool isPlayerAttackAvailable;
    public static bool isPlayerUtilisationAvailable;
    public static bool isPlayerUsing;
    public static bool isPlayerAttacking;

    //Health Status

    public static bool isPlayerDead;
    public static bool isPlayerImmune;

    //Inventory Status

    public static bool isInventoryScrollingAvailable;
    public static bool isPickingAvailable;

    private void Start()
    {
        //Movement Status

        isPlayerMoveAvailable = true;
        isPlayerDashAvailable = true;
        isPlayerDashing = false;
        isPlayerFallAvailable = true;
        isPlayerFalling = false;

        //Use - Attack Status

        isPlayerAttackAvailable = true;
        isPlayerUtilisationAvailable = true;
        isPlayerUsing = false;
        isPlayerAttacking = false;

        //Health Status

        isPlayerDead = false;
        isPlayerImmune = false;

        //Inventory Status

        isInventoryScrollingAvailable = true;
        isPickingAvailable = true;

    }




    private void Update()
    {

        //Movement Status

        if (isPlayerMoveAvailable == false)
        {
            isPlayerDashAvailable = false;
        }

        if (isPlayerDashing == true)
        {
            //Movement Status

            isPlayerMoveAvailable = false;
            isPlayerDashAvailable = false;
            isPlayerFallAvailable = false;

            //Use - Attack Status

            isPlayerAttackAvailable = false;
            isPlayerUtilisationAvailable = false;

            //Inventory Status

            isPickingAvailable = false;
        }

        if (isPlayerFalling == true)
        {
            GetComponent<SpriteRenderer>().color = Color.red;       //TemporaryFeedBack
            PlayerMovement.playerRgb.velocity = new Vector3(0, 0, 0);

            //Movement Status

            isPlayerMoveAvailable = false;
            isPlayerDashAvailable = false;
            isPlayerFallAvailable = false;

            //Use - Attack Status

            isPlayerAttackAvailable = false;
            isPlayerUtilisationAvailable = false;

        }

        //Use - Attack Status

        if (isPlayerUsing == true)
        {
            //Movement Status

            isPlayerDashAvailable = false;

            //Use - Attack Status

            isPlayerAttackAvailable = false;
            isPlayerUtilisationAvailable = false;


            //Inventory Status

            isInventoryScrollingAvailable = false;
            isPickingAvailable = false;


        }

        if (isPlayerAttacking == true)
        {
            //Movement Status

            isPlayerDashAvailable = false;
            isPlayerMoveAvailable = false;
            PlayerMovement.playerRgb.velocity = new Vector3(0, 0, 0);

            //Use - Attack Status

            isPlayerAttackAvailable = false;
            isPlayerUtilisationAvailable = false;


            //Inventory Status

            isInventoryScrollingAvailable = false;
            isPickingAvailable = false;


        }


        //Health Status

        if (isPlayerDead == true)
        {
            //Movement Status

            isPlayerMoveAvailable = false;
            isPlayerDashAvailable = false;
            isPlayerDashing = false;
            isPlayerFallAvailable = false;
            isPlayerFalling = false;

            //Use - Attack Status

            isPlayerAttackAvailable = false;
            isPlayerUtilisationAvailable = false;
            isPlayerUsing = false;

            //Health Status

            isPlayerImmune = false;

            //Inventory Status

            isInventoryScrollingAvailable = false;
            isPickingAvailable = false;

            GetComponent<SpriteRenderer>().color = Color.black;     //temporary FeedBack

        }

        if (isPlayerImmune == true)
        {
            //Movement Status
            GetComponent<SpriteRenderer>().color = Color.green;     //temporary FeedBack
        }
    }     
}
