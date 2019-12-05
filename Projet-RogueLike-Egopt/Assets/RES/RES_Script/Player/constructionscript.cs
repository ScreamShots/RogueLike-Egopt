using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructionscript : MonoBehaviour
{
    //Current State Algorithm

    public int currentState;
    public int lastState;
    public bool stateTurnOff;

    //In Time Status

    public static bool isDashing;       // state 1
    public static bool isFalling;       // state 2
    public static bool isAttacking;     // state 3
    public static bool isUsing;         // state 4
    public static bool isInteracting;   // state 5

    //Status Ending

    public bool needToEndDash;       
    public bool needToEndFall;       
    public bool needToEndAttack;     
    public bool needToEndUse;         
    public bool needToEndInteract;

    //CD Status

    public static bool cdOnDash;       
    public static bool cdOnFall;       
    public static bool cdOnAttack;     
    public static bool cdOnUse;         
    public static bool cdOnInteract;   

    //Availability

    public static bool canMove;
    public static bool canDash;
    public static bool canFall;
    public static bool canAttack;
    public static bool canUse;
    public static bool canInteract;
    public static bool canPick;
    public static bool canScroll;


    private void Update()
    {

        if (isDashing == false && needToEndDash == true)
        {
            if (cdOnFall == false) { canFall = true; }

            if (cdOnAttack == false) { canAttack = true; }

            if (cdOnInteract == false) { canInteract = true; }

            if (cdOnUse == false) { canUse = true; }

            canMove = true;
            canPick = true;

        }
        else if (isFalling == false && needToEndFall == true)
        {
            if (cdOnDash == false) { canDash = true; }

            if (cdOnAttack == false) { canAttack = true; }

            if (cdOnInteract == false) { canInteract = true; }

            if (cdOnUse == false) { canUse = true; }

            canMove = true;
            canPick = true;
        }
        else if (isAttacking == false && needToEndAttack == true)
        {
            if (cdOnFall == false) { canFall = true; }

            if (cdOnDash == false) { canDash = true; }

            if (cdOnInteract == false) { canInteract = true; }

            if (cdOnUse == false) { canUse = true; }

            canMove = true;
            canPick = true;
        }
        else if (isUsing == false && needToEndUse == true)
        {
            if (cdOnFall == false) { canFall = true; }

            if (cdOnAttack == false) { canAttack = true; }

            if (cdOnInteract == false) { canInteract = true; }

            if (cdOnDash == false) { canDash = true; }

            canMove = true;
            canPick = true;
        }
        else if (isInteracting == false && needToEndInteract == true)
        {
            if (cdOnFall == false) { canFall = true; }

            if (cdOnAttack == false) { canAttack = true; }

            if (cdOnDash == false) { canDash = true; }

            if (cdOnUse == false) { canUse = true; }

            canMove = true;
            canPick = true;
            canScroll = true;
        }


        if (isDashing == true) { currentState = 1; }

        else if(isFalling == true) { currentState = 2; }

        else if (isAttacking == true) { currentState = 3; } 
       
        else if (isUsing == true) { currentState = 4; }
        
        else if (isInteracting == true) { currentState = 5; }
       
        else 
        { currentState = 0; }

     
        if (currentState != lastState)
        {
            lastState = currentState;
            
            switch (currentState)
            {
                case 0:
                    break;

                case 1:
                    canMove = false;
                    canDash = false;
                    canFall = false;
                    canAttack = false;
                    canInteract = false;
                    canUse = false;
                    canPick = false;                    
                    break;

                case 2:
                    canMove = false;
                    canDash = false;
                    canFall = false;
                    canAttack = false;
                    canUse = false;
                    canInteract = false;
                    canPick = false;                    
                    break;

                case 3:
                    canMove = false;
                    canDash = false;
                    canFall = false;
                    canAttack = false;
                    canUse = false;
                    canInteract = false;
                    canPick = false;                    
                    break;

                case 4:
                    canMove = false;
                    canDash = false;
                    canFall = false;
                    canAttack = false;
                    canUse = false;
                    canInteract = false;
                    canPick = false;
                    canScroll = false;                    
                    break;

                case 5:
                    canMove = false;
                    canDash = false;
                    canFall = false;
                    canAttack = false;
                    canUse = false;
                    canInteract = false;
                    canPick = false;
                    canScroll = false;                    
                    break;

                default:
                    if (cdOnDash == false) { canDash = true; }

                    if (cdOnAttack == false) { canAttack = true; }

                    if (cdOnInteract == false) { canInteract = true; }

                    if (cdOnUse == false) { canUse = true; }

                    if (cdOnFall == false) { canFall = true; }
                    break;
            }
            
        }
    }


}
