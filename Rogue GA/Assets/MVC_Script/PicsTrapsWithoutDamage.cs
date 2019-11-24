using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicsTrapsWithoutDamage : MonoBehaviour
{
    private SpriteRenderer spr;
    public Sprite activatedPics;
    public Sprite desactivatedPics;
    bool picsActivated = false;
    bool inRoom = true;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (inRoom && !picsActivated)
        {
            StartCoroutine(PicsMovement());
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
    }

}
