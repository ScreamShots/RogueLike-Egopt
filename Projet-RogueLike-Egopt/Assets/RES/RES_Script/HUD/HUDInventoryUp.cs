using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDInventoryUp : MonoBehaviour
{
    public Image upInventorySlot;
    public Sprite emptyDisplay;
    public int nextInventoryIndex;

    private void Update()
    {
        if (PlayerInventory.playerInventory != null)
        {
            if (PlayerInventory.inventoryIndex < PlayerInventory.playerInventory.Length - 1)
            {
                nextInventoryIndex = PlayerInventory.inventoryIndex + 1;
            }
            else if (PlayerInventory.inventoryIndex == PlayerInventory.playerInventory.Length - 1)
            {
                nextInventoryIndex = 0;
            }

            if (PlayerInventory.playerInventory[nextInventoryIndex] != null)
            {
                upInventorySlot.sprite = PlayerInventory.playerInventory[nextInventoryIndex].GetComponent<InventoryStorage>().inventoryDisplay;
                upInventorySlot.color = new Color(255f, 255f, 255f, 1f);
            }
            else
            {
                upInventorySlot.sprite = null;
                upInventorySlot.color = new Color(0f, 0f, 0f, 0f);
            }
        }        
    }
}
