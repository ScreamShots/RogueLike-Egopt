using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrap : MonoBehaviour
{
    public float activationTime;
    public List<GameObject> objectInRange;
    public bool trapActivated;
    public float trapDmg;

    private void Start()
    {
        trapActivated = false;
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
                HoleTrapEffect();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectInRange.Remove(collision.gameObject);
    }

    IEnumerator HoleTRapActivation()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow; // Temporary FeedBack

        yield return new WaitForSeconds(activationTime);
        trapActivated = true;

        GetComponent<SpriteRenderer>().color = Color.red; // Temporary FeedBack

        HoleTrapEffect();
    }

    void HoleTrapEffect()
    {
        for (int i = 0; i < objectInRange.Count; i++)
        {
            if (objectInRange[i].transform.parent.gameObject.tag == "Player")
            {
                objectInRange[i].transform.parent.gameObject.GetComponent<PlayerMovement>().StartFall(trapDmg,transform, objectInRange[i].transform);
            }
        }

    }
}
