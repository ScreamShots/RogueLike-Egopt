using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject startingWeapon;
    [SerializeField] private GameObject selectionedObject;
    public static GameObject[] playerInventory;

    public static int inventoryIndex;
    [SerializeField] private int inventorySize;

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
        if (Input.GetButtonDown("Pick") && collision.gameObject.tag == "PickableObject")
        {
            PickingObject(collision.gameObject);
            Destroy(collision.gameObject);            
        }
    }

    public void InventoryRotation(int slidingdirection)
    {
        if (PlayerStatusManager.canScroll == true)
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
        if(PlayerStatusManager.canPick == true)
        {
            if (playerInventory[inventoryIndex] != null)
            {
                playerInventory[inventoryIndex].GetComponent<ItemDrop>().Drop();
            }
            playerInventory[inventoryIndex] = item.GetComponent<PickableStorage>().storedObject;
        }
        
    }

}
