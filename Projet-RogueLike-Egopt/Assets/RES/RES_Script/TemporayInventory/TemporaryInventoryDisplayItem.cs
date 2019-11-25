using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryInventoryDisplayItem : MonoBehaviour
{
    [SerializeField] private Sprite iconNothingToDisplay;
    private void Update()
    {
        if(PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] != null)
        {
            GetComponent<Image>().sprite = PlayerInventory.playerInventory[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().iconDisplay;
        }
        else
        {
            GetComponent<Image>().sprite = iconNothingToDisplay;
        }
        
    }
}
