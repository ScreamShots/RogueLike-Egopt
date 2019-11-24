using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappeTraps : MonoBehaviour
{
    private SpriteRenderer spr;
    public Sprite openTrappe;
    public Sprite closeTrappe;
    bool isOpen = false;
    bool isActivated = false;
    public GameObject respawnPoint;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActivated == false)
        {
            StartCoroutine(LoadOpenTrappe());
        }

        IEnumerator LoadOpenTrappe()
        {
            //début animation
            isActivated = true;
            yield return new WaitForSeconds(1);    //à remplacer par un trigger de fin d'animation
            print("la trappe est ouverte");
            isOpen = true;
            spr.sprite = openTrappe;

            //début d'animation
            yield return new WaitForSeconds(5);
            print("la trappe est fermé");
            isOpen = false;
            spr.sprite = closeTrappe;
            isActivated = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOpen == true && collision.gameObject.tag == "Player") // les ennemis aussi sont impactés !!!
        {
            StartCoroutine(Fallen());

            IEnumerator Fallen()
            {
                print("Fallen Start Execution");
                collision.GetComponent<PlayerMovement>().canMove = false;
                yield return new WaitForSeconds(1);
                print("Fallen is finish");
                collision.transform.position = respawnPoint.transform.position;
                print("Player is Respawn");
                collision.GetComponent<PlayerMovement>().canMove = true;
                // Ajouter la perte de vie
            }

        }
    }
}
