using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameObject startingWeapon;
    public static GameObject[] playerInventory;
    public GameObject selectionedObject;

    public static int inventoryIndex;
    public int inventorySize;

    private void Start()
    {
        playerInventory = new GameObject[inventorySize];
        playerInventory[0] = startingWeapon;
        inventoryIndex = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inv"))
        {
            InventoryRotation((int)Input.GetAxisRaw("Inv"));
        }
        selectionedObject = playerInventory[inventoryIndex];
        GetComponent<PlayerUse>().equipiedItem = selectionedObject;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Pick") && collision.gameObject.tag == "PickableObject" && PlayerStatusManager.isPickingAvailable)        //casser si il y a plusieur objet détecté en m^me temps
        {
            PickingObject(collision.gameObject);
            Destroy(collision.gameObject);
            
        }
    }

    public void InventoryRotation(int slidingdirection)
    {
        if (PlayerStatusManager.isInventoryScrollingAvailable == true)
        {
            inventoryIndex += slidingdirection;
            if (inventoryIndex > 2)
            {
                inventoryIndex = 0;
            }
            else if (inventoryIndex < 0)
            {
                inventoryIndex = 2;
            }
        }
    }

    public void PickingObject(GameObject item)
    {
        if(PlayerStatusManager.isPickingAvailable == true)
        {
            if (playerInventory[inventoryIndex] != null)
            {
                playerInventory[inventoryIndex].GetComponent<ItemDrop>().Drop();
            }
            playerInventory[inventoryIndex] = item.GetComponent<PickableStorage>().storedObject;
        }
        
    }

}
