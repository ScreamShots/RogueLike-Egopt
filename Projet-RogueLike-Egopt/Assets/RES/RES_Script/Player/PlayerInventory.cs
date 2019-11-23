using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject[] playerIventory;
    public GameObject selectionedObject;

    public int inventoryIndex;

    private void Start()
    {
        playerIventory = new GameObject[3];
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inv"))
        {
            Debug.Log(Input.GetAxisRaw("Inv"));
            InventoryRotation((int)Input.GetAxisRaw("Inv"));
        }
        
    }

    void InventoryRotation(int slidingdirection)
    {

    }

}
