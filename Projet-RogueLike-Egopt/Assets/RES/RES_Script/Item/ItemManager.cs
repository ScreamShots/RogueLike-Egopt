using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public float useSpeed;
    [SerializeField] private int itemId; //0 = life potion 1 = agility potion
    [SerializeField] private float healBoostRatio;
    [SerializeField] private float speedBoostRatio;
    [SerializeField] private float strengthBoostValue;
    [SerializeField] public float effectDuration;

    private void Start()
    {
        if (healBoostRatio < 1)
        {
            healBoostRatio = 1/healBoostRatio;
        }
    }

    public void ItemEffectActivation(GameObject characterUsing)
    {
        if (characterUsing.tag == "Player")
        {

            switch (itemId)
            {
                case 0:
                    LifePotion(characterUsing);
                    break;
                case 1:
                    StartCoroutine(AgilityPotion(characterUsing));
                    break;
                case 2:
                    StartCoroutine(StrengthPotion(characterUsing));
                    break;
                default:
                    break;
            }           
        }
    }

    void LifePotion(GameObject characterUsing)
    {
        characterUsing.GetComponent<PlayerHealthSystem>().PlayerIsHealing(characterUsing.GetComponent<PlayerHealthSystem>().playerMaxHp * healBoostRatio);
        Destroy(this.gameObject);
    }

    IEnumerator AgilityPotion(GameObject characterUsing)
    {
        Debug.Log("Start");
        characterUsing.GetComponent<PlayerMovement>().speed = characterUsing.GetComponent<PlayerMovement>().speed * speedBoostRatio;
        HUDIcono.speedboost = true;
        HUDIcono.effectdurationSpeed = effectDuration;
        yield return new WaitForSeconds(effectDuration);
        HUDIcono.speedboost = false;
        characterUsing.GetComponent<PlayerMovement>().speed = characterUsing.GetComponent<PlayerMovement>().speed / speedBoostRatio;
        Debug.Log("Stop");
        Destroy(this.gameObject);
    }

    IEnumerator StrengthPotion(GameObject characterUsing)
    {
        Debug.Log("Start");
        characterUsing.GetComponent<PlayerUse>().additionalStrength += strengthBoostValue;
        HUDIcono.boostforce = true;
        HUDIcono.effectdurationForce = effectDuration;
        yield return new WaitForSeconds(effectDuration);
        HUDIcono.boostforce = false;
        characterUsing.GetComponent<PlayerUse>().additionalStrength -= strengthBoostValue;
        Debug.Log("Stop");
        Destroy(this.gameObject);
    }
}
