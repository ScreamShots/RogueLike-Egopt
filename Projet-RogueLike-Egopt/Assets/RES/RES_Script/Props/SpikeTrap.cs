using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Sprite spikeEnable;
    public Sprite spikeDisable;
    public Sprite spikeWarning;
    public bool spikeEnabled;
    public float activationTime;
    public float desactivationTime;
    public float spikeDmg;
    public float timer;
    public List<GameObject> stayingTarget;
    private void FixedUpdate()
    {
        if (spikeEnabled == true)
        {
            if (timer < activationTime)
            {
                timer += Time.fixedDeltaTime;
            }
            else
            {
                spikeEnabled = false;
                GetComponent<SpriteRenderer>().sprite = spikeDisable;
                timer = 0;
            }
        }
        else if (spikeEnabled == false)
        {
            if (timer < desactivationTime)
            {
                timer += Time.fixedDeltaTime;
                if (timer > (desactivationTime * 0.66))
                {
                    GetComponent<SpriteRenderer>().sprite = spikeWarning;
                }

            }            
            else
            {
                spikeEnabled = true;
                GetComponent<SpriteRenderer>().sprite = spikeEnable;

                foreach (GameObject target in stayingTarget)
                {
                    SpikeHit(target);
                }
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CharacterGroundCollision")
        {
            if (spikeEnabled == true)
            {
                SpikeHit(collision.gameObject);
            }

            stayingTarget.Add(collision.gameObject);
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stayingTarget.Remove(collision.gameObject);
    }

    public void SpikeHit(GameObject target)
    {
            if (target.transform.parent.gameObject.tag == "Player")
            {
                target.transform.parent.gameObject.GetComponent<PlayerHealthSystem>().IsTakingDmg(spikeDmg);
            }
            if (target.transform.parent.gameObject.tag == "Enemy")
            {
                target.transform.parent.gameObject.GetComponent<EnemyHealthSystem>().IsTakingDmg(spikeDmg);
            }
        
    }
}
