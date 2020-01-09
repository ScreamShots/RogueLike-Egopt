using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public List<GameObject> objectInRange;
    public float trapDmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision" && collision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            objectInRange.Add(collision.gameObject);
            StartCoroutine(HoleTrapEffect());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectInRange.Remove(collision.gameObject);
    }

    IEnumerator HoleTrapEffect()
    {
        yield return new WaitForSeconds(0.10f);

        for (int i = 0; i < objectInRange.Count; i++)
        {
            if (objectInRange[i].transform.parent.gameObject.tag == "Player")
            {
                objectInRange[i].transform.parent.gameObject.GetComponent<PlayerMovement>().StartFallBis(trapDmg, objectInRange[i].transform, objectInRange[i].transform);
            }
        }

    }
}
