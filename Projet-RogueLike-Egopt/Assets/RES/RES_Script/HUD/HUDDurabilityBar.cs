using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDurabilityBar : MonoBehaviour
{
    public Image upBar;
    public Image centerBar;
    public Image downBar;
    public Image upFill;
    public Image centerFill;
    public Image downFill;

    public int nextInventoryIndex;
    public int previousInventoryIndex;

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

            if (PlayerInventory.playerInventory[nextInventoryIndex] != null && PlayerInventory.durabilityStock[nextInventoryIndex].tag == "Weapon" && PlayerInventory.durabilityStock[nextInventoryIndex].GetComponent<WeaponManager>().isBroke == false)
            {
                upBar.enabled = true;
                upFill.enabled = true;
                upFill.fillAmount = PlayerInventory.durabilityStock[nextInventoryIndex].GetComponent<WeaponManager>().durability / PlayerInventory.durabilityStock[nextInventoryIndex].GetComponent<WeaponManager>().maxdurability;
            }
            else
            {
                upBar.enabled = false;
                upFill.enabled = false;
            }



            if (PlayerInventory.inventoryIndex > 0)
            {
                previousInventoryIndex = PlayerInventory.inventoryIndex - 1;
            }
            else if (PlayerInventory.inventoryIndex == 0)
            {
                previousInventoryIndex = PlayerInventory.playerInventory.Length - 1;
            }

            if (PlayerInventory.playerInventory[previousInventoryIndex] != null && PlayerInventory.durabilityStock[previousInventoryIndex].tag == "Weapon" && PlayerInventory.durabilityStock[previousInventoryIndex].GetComponent<WeaponManager>().isBroke == false)
            {
                downBar.enabled = true;
                downFill.enabled = true;
                downFill.fillAmount = PlayerInventory.durabilityStock[previousInventoryIndex].GetComponent<WeaponManager>().durability / PlayerInventory.durabilityStock[previousInventoryIndex].GetComponent<WeaponManager>().maxdurability;
            }
            else
            {
                downFill.enabled = false;
                downBar.enabled = false;
            }

            if (PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] != null && PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].tag == "Weapon" && PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().isBroke == false)
            {
                centerBar.enabled = true;
                centerFill.enabled = true;
                centerFill.fillAmount = PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().durability / PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].GetComponent<WeaponManager>().maxdurability;
            }
            else
            {
                centerBar.enabled = false;
                centerFill.enabled = false;
            }
            
        }
    }

}
