using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrap : MonoBehaviour
{
    public float activationTime;
    public List<GameObject> objectInRange;
    public bool trapActivated;
    public float trapDmg;
    public Animator animator;

    private void Start()
    {
        trapActivated = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision")
        {
            objectInRange.Add(collision.gameObject);

            if (trapActivated == false)
            {
                StartCoroutine("HoleTRapActivation");
            }

            if (trapActivated == true)
            {
                StartCoroutine(HoleTrapEffect());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectInRange.Remove(collision.gameObject);
    }

    IEnumerator HoleTRapActivation()
    {
        animator.SetTrigger("Open");

        yield return new WaitForSeconds(activationTime);
        trapActivated = true;

        StartCoroutine(HoleTrapEffect());
    }

    IEnumerator HoleTrapEffect()
    {
        yield return new WaitForSeconds(0.12f);

        for (int i = 0; i < objectInRange.Count; i++)
        {
            if (objectInRange[i].transform.parent.gameObject.tag == "Player")
            {
                objectInRange[i].transform.parent.gameObject.GetComponent<PlayerMovement>().StartFall(trapDmg,transform, objectInRange[i].transform);
            }
        }

    }
}
