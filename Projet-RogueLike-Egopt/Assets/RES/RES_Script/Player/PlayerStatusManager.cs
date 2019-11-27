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
    public static bool isPlayerInUse;

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
        isPlayerInUse = false;

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

        if (isPlayerMoveAvailable == true)
        {

        }
        else if (isPlayerMoveAvailable == false)
        {
            isPlayerDashAvailable = false;
        }

        if (isPlayerDashAvailable == true)
        {

        }
        else if (isPlayerDashAvailable == false)
        {

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

        else if (isPlayerDashing == false)
        {

        }

        if (isPlayerFallAvailable == false)
        {

        }
        
        else if (isPlayerFallAvailable == false)
        {

        }

        if (isPlayerFalling == true)
        {

        }
        else if (isPlayerFalling == false)
        {

        }

        //Use - Attack Status

        if (isPlayerAttackAvailable == true)
        {

        }
        else if (isPlayerAttackAvailable == false)
        {

        }

        if (isPlayerUtilisationAvailable == true)
        {

        }
        else if (isPlayerUtilisationAvailable == false)
        {

        }

        if (isPlayerInUse == true)
        {
            //Movement Status

            isPlayerDashAvailable = false;
            isPlayerMoveAvailable = false;

            //Use - Attack Status

            isPlayerAttackAvailable = false;
            isPlayerUtilisationAvailable = false;


            //Inventory Status

            isInventoryScrollingAvailable = false;
            isPickingAvailable = false;


        }
        else if (isPlayerInUse == false)
        {

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
            isPlayerInUse = false;

            //Health Status

            isPlayerImmune = false;

            //Inventory Status

            isInventoryScrollingAvailable = false;
            isPickingAvailable = false;

        }
        else if (isPlayerDead == false)
        {

        }

        if (isPlayerImmune == true)
        {
            //Movement Status

            isPlayerFallAvailable = false;

        }
        else if (isPlayerImmune == false)
        {

        }

        //Inventory Status

        if (isInventoryScrollingAvailable == true)
        {

        }
        else if (isInventoryScrollingAvailable == false)
        {

        }

        if (isPickingAvailable == true)
        {

        }
        else if (isPickingAvailable == false)
        {

        }
    }
}
