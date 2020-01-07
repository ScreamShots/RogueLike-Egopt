using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSpot : MonoBehaviour
{
    public static List<GameObject> shopObjects;
    public int randomNumber;
    public Text priceDisplay;

    public SpriteRenderer spriteDisplay;
    public int price;
    public GameObject pickableObject;
    public string ObjectType;
    public void Initialize(GameObject selectionnedObj)
    {

        if (selectionnedObj != null)
        {
            spriteDisplay.sprite = selectionnedObj.GetComponent<ShopItem>().itemSprite;
            price = selectionnedObj.GetComponent<ShopItem>().basePrice + Random.Range(selectionnedObj.GetComponent<ShopItem>().basePrice / -2, selectionnedObj.GetComponent<ShopItem>().basePrice / 2);
            pickableObject = selectionnedObj.GetComponent<ShopItem>().storageObject;
            Debug.Log(pickableObject);

            priceDisplay.text = price.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
}
