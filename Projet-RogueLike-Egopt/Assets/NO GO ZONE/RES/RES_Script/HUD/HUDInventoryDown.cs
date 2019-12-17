using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUDInventoryDown : MonoBehaviour
{
    public Image downInventorySlot;
    public Sprite emptyDisplay;
    public int previousInventoryIndex;

    private void Update()
    {
        if (PlayerInventory.inventoryIndex > 0)
        {
            previousInventoryIndex = PlayerInventory.inventoryIndex - 1;
        }
        else if (PlayerInventory.inventoryIndex == 0)
        {
            previousInventoryIndex = PlayerInventory.playerInventory.Length - 1;
        }

        if (PlayerInventory.playerInventory[previousInventoryIndex] != null)
        {
            downInventorySlot.sprite = PlayerInventory.playerInventory[previousInventoryIndex].GetComponent<InventoryStorage>().inventoryDisplay;
            downInventorySlot.color = new Color(255f, 255f, 255f, 1f);
        }
        else
        {
            downInventorySlot.sprite = null;
            downInventorySlot.color = new Color(0f, 0f, 0f, 0f);
        }
    }
}
