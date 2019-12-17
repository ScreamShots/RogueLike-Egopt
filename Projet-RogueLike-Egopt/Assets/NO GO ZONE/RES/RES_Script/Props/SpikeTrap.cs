using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [HideInInspector] public Sprite spikeEnable;
    [HideInInspector] public Sprite spikeDisable;
    public float activationTime;
    public float desactivationTime;
    public float spikeDmg;
    [HideInInspector] public bool spikeTimerActivated;
    [HideInInspector] public bool spikeDmgActivated;
    [HideInInspector] public List<GameObject> objectInRange;

    private void Awake()
    {
        spikeTimerActivated = false;
    }

    private void Update()
    {
        if (spikeTimerActivated == false)
        {
            StartCoroutine("SpikeActivation");
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CharacterGroundCollision")
        {
            objectInRange.Add(collision.gameObject);
    
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectInRange.Remove(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (spikeDmgActivated == true)
        {
            SpikeHit();
        }
    }

    IEnumerator SpikeActivation()
    {
        spikeTimerActivated = true;
        yield return new WaitForSeconds(desactivationTime);
        spikeDmgActivated = true;


        GetComponent<SpriteRenderer>().sprite = spikeEnable;

        yield return new WaitForSeconds(activationTime);

        spikeTimerActivated = false;
        spikeDmgActivated = false;
        GetComponent<SpriteRenderer>().sprite = spikeDisable;

    }

    public void SpikeHit()
    {
        for (int i = 0; i < objectInRange.Count; i++)
        {
            if (objectInRange[i].transform.parent.gameObject.tag == "Player")
            {
                objectInRange[i].transform.parent.gameObject.GetComponent<PlayerHealthSystem>().IsTakingDmg(spikeDmg);
            }
            if (objectInRange[i].transform.parent.gameObject.tag == "Enemy")
            {
                objectInRange[i].transform.parent.gameObject.GetComponent<EnemyHealthSystem>().IsTakingDmg(spikeDmg);
            }
        }
    }
}
