using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject startingWeapon;
    [SerializeField] private GameObject selectionedObject;
    public static GameObject[] playerInventory;
    public List<GameObject> securityStock;

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

        if (Input.GetButtonDown("Pick") && securityStock.Count != 0)
        {
            StartCoroutine(PickingObject(securityStock[0]));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickableObject")
        {
            securityStock.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickableObject")
        {
            securityStock.Remove(collision.gameObject);
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
            Debug.Log( playerInventory[inventoryIndex]);
        }
    }

    public IEnumerator PickingObject(GameObject item)
    {
        if(PlayerStatusManager.canPick == true)
        {
            PlayerStatusManager.canPick = false;
            if (playerInventory[inventoryIndex] != null)
            {
                Instantiate(playerInventory[inventoryIndex].GetComponent<ItemDrop>().pickableVersionObject, transform.position - new Vector3(0,0.15f,0), transform.rotation) ;
                playerInventory[inventoryIndex] = item.GetComponent<PickableStorage>().storedObject;
                Destroy(item.gameObject);
            }
            else
            {
                playerInventory[inventoryIndex] = item.GetComponent<PickableStorage>().storedObject;
                Destroy(item.gameObject);
            }

            yield return new WaitForSeconds(0.00001f);
            PlayerStatusManager.canPick = true;
        }
        
    }

}
