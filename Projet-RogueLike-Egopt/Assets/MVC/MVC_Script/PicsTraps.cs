using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicsTraps : MonoBehaviour
{
   /* private SpriteRenderer spr;
    public Sprite activatedPics;
    public Sprite desactivatedPics;
    bool picsActivated = false;
    bool inRoom = true;
    public int HP = 100;
    public int picsDamage = 10;
    bool canTakeDamage = true;
    bool isInPics = false;
    private GameObject player;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

     void Update()
    {
        if (inRoom && !picsActivated)
        {
            StartCoroutine(PicsMovement());
        }


        //Debug.Log(isInPics);

        if (picsActivated && canTakeDamage && isInPics)
        {
            
            player.GetComponent<PlayerMovement>().health -= picsDamage;
            Debug.Log("le joueur n'a plus que " + player.GetComponent<PlayerMovement>().health + " HP");

            StartCoroutine(DamageReload());
        }
      
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInPics = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInPics = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (picsActivated && collision.gameObject.tag == "Player" && isInPics && canTakeDamage)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = 1.3f;
        }     
       
    }

    IEnumerator PicsMovement() //Coroutine de l'animation des pics
    {
        // début de l'animation
        yield return new WaitForSeconds(2);
        picsActivated = true;
        spr.sprite = activatedPics;

        // début de l'animation
        yield return new WaitForSeconds(2);
        picsActivated = false;
        spr.sprite = desactivatedPics;
    }

    IEnumerator DamageReload()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(2);
        canTakeDamage = true;
    }
    */
}
