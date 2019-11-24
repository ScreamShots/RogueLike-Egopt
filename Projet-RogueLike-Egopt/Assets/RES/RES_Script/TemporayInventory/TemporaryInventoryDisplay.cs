using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryInventoryDisplay : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = ("Inventory Slot: " + PlayerInventory.inventoryIndex);
    }
}
