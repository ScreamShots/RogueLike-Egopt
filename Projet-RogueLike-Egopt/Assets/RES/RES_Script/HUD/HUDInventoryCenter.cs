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
            centerInventorySlot.color = new Color(255f, 255f, 255f, 1f);

            if (PlayerInventory.playerInventory[PlayerInventory.inventoryIndex].tag == "Consumable" && PlayerStatusManager.isUsing == true)
            {

                cdDisplay.fillAmount = cdTime;
                cdTime += (1 / PlayerInventory.playerInventory[PlayerInventory.inventoryIndex].GetComponent<ItemManager>().useSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            centerInventorySlot.sprite = null;
            centerInventorySlot.color = new Color(0f, 0f, 0f, 0f);
            cdTime = 0;
            cdDisplay.fillAmount = 0;
        }        
    }

}
