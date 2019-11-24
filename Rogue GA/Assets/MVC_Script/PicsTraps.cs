using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicsTraps : MonoBehaviour
{
    private SpriteRenderer spr;
    public Sprite activatedPics;
    public Sprite desactivatedPics;
    bool picsActivated = false;
    bool inRoom = true;
    public int HP = 100;
    public int picsDamage = 10;
    public GameObject player;
    bool canTakeDamage = true;
    bool isInPics = false;
    int newHP;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

     void Update()
    {
        if (inRoom == true && picsActivated == false)
        {
            StartCoroutine(PicsMovement());
        }

        IEnumerator PicsMovement()
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

        if (picsActivated == true && canTakeDamage == true && isInPics == true)
        {
            newHP = HP -= picsDamage;
            Debug.Log("le joueur n'a plus que " + newHP + " HP");

            StartCoroutine(DamageReload());
        }
      
        IEnumerator DamageReload()
        {
            canTakeDamage = false;
            yield return new WaitForSeconds(2);
            canTakeDamage = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (picsActivated == true && collision.gameObject.tag == "Player")
        {
            isInPics = true;
            canTakeDamage = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (picsActivated == true && collision.gameObject.tag == "Player" && isInPics == true && canTakeDamage == true)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = 1.3f;
        }     
       
    }

}
