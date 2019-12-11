using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDInventoryCenter : MonoBehaviour
{
    public Image centerInventorySlot;
    public Sprite emptyDisplay;
    public Image cdDisplay;
    public float cdTime;
    private void FixedUpdate()
    { 
        if (PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] != null)
        {
            centerInventorySlot.sprite = PlayerInventory.playerInventory[PlayerInventory.inventoryIndex].GetComponent<InventoryStorage>().inventoryDisplay;

            if (PlayerInventory.playerInventory[PlayerInventory.inventoryIndex].tag == "Consumable" && PlayerStatusManager.isUsing == true)
            {

                cdDisplay.fillAmount = cdTime;
                Debug.Log("yo " + cdDisplay.fillAmount);
                cdTime += (1 / PlayerInventory.playerInventory[PlayerInventory.inventoryIndex].GetComponent<ItemManager>().useSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            centerInventorySlot.sprite = emptyDisplay;
            cdTime = 0;
            cdDisplay.fillAmount = 0;
        }

        
        
    }

}
