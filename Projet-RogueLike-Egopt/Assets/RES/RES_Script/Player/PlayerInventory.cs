using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject[] playerInventory;
    public GameObject selectionedObject;

    public int inventoryIndex;
    public int inventorySize;

    private void Start()
    {
        playerInventory = new GameObject[inventorySize];
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inv"))
        {
            InventoryRotation((int)Input.GetAxisRaw("Inv"));

            Debug.Log(inventoryIndex);
        }
        selectionedObject = playerInventory[inventoryIndex];
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Pick") && collision.gameObject.tag == "PickableObject")
        {
            PickingObject(collision.gameObject);
        }
    }

    public void InventoryRotation(int slidingdirection)
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

    public void PickingObject(GameObject item)
    {
        if (playerInventory[inventoryIndex] != null)
        {
            playerInventory[inventoryIndex].GetComponent<ItemDrop>().Drop();
        }
        playerInventory[inventoryIndex] = item;
    }

}
