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
    }

    IEnumerator AgilityPotion(GameObject characterUsing)
    {
        Debug.Log("AgilityPotion Consumed, speed increased for " + effectDuration);
        characterUsing.GetComponent<PlayerMovement>().speed = characterUsing.GetComponent<PlayerMovement>().speed * speedBoostRatio;

        yield return new WaitForSeconds(effectDuration);

        characterUsing.GetComponent<PlayerMovement>().speed = characterUsing.GetComponent<PlayerMovement>().speed / speedBoostRatio;
        Debug.Log("End of the AgilityPotion effect");
    }

    IEnumerator StrengthPotion(GameObject characterUsing)
    {
        Debug.Log("StrengthPotion Consumed, strength increased for " + effectDuration);

        characterUsing.GetComponent<PlayerUse>().additionalStrength += strengthBoostValue;

        yield return new WaitForSeconds(effectDuration);

        characterUsing.GetComponent<PlayerUse>().additionalStrength -= strengthBoostValue;
        Debug.Log("End of the StrengthPotion effect");
    }
}
