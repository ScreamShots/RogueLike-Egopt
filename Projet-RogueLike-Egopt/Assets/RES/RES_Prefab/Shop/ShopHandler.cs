using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    public GameObject[] sellSlot;
    public List<GameObject> allShopPotion;
    public List<GameObject> allShopWeapon;

    private void Start()
    {
        for (int i = 0; i < sellSlot.Length; i++)
        {
            GameObject selectionItem;

            switch (sellSlot[i].GetComponent<ShopSpot>().ObjectType)
            {
                case "Potion":
                    selectionItem = allShopPotion[Random.Range(0, allShopPotion.Count)];
                    sellSlot[i].GetComponent<ShopSpot>().Initialize(selectionItem);
                    allShopPotion.Remove(selectionItem);
                    break;
                case "Weapon":
                    selectionItem = allShopWeapon[Random.Range(0, allShopWeapon.Count)];
                    sellSlot[i].GetComponent<ShopSpot>().Initialize(selectionItem);
                    allShopWeapon.Remove(selectionItem);
                    break;
                case "All":
                    int rng = Random.Range(0, 1);
                    if (rng == 0)
                    {
                        selectionItem = allShopPotion[Random.Range(0, allShopPotion.Count)];
                        sellSlot[i].GetComponent<ShopSpot>().Initialize(selectionItem);
                        allShopPotion.Remove(selectionItem);
                    }
                    else if (rng == 1)
                    {
                        selectionItem = allShopWeapon[Random.Range(0, allShopWeapon.Count)];
                        sellSlot[i].GetComponent<ShopSpot>().Initialize(selectionItem);
                        allShopWeapon.Remove(selectionItem);
                    }
                    break;
                default:
                    break;
            }            
        }
    }
}
