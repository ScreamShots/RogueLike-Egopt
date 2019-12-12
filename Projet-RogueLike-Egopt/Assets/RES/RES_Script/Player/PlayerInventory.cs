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
    public List<GameObject> chestSecurityStock;
    public GameObject buttonADisplay;

    public static int inventoryIndex;
    [SerializeField] private int inventorySize;
    public bool canOpen;

    private void Start()
    {
        playerInventory = new GameObject[inventorySize];
        playerInventory[0] = startingWeapon;
        inventoryIndex = 0;
        buttonADisplay.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inv"))
        {
            InventoryRotation((int)Input.GetAxisRaw("Inv"));
        }
        selectionedObject = playerInventory[inventoryIndex];
        GetComponent<PlayerUse>().equipiedItem = selectionedObject;

        if (Input.GetButtonDown("Pick"))
        {
            if (securityStock.Count != 0 && chestSecurityStock.Count == 0)
            {
                StartCoroutine(PickingObject(securityStock[0]));
            }
            if(chestSecurityStock.Count != 0)
            {
                OpenChest(chestSecurityStock[0]);
            }           

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickableObject")
        {
            buttonADisplay.SetActive(true);
            securityStock.Add(collision.gameObject);
        }

        if (collision.gameObject.tag == "Chest")
        {
            chestSecurityStock.Add(collision.gameObject);
            buttonADisplay.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickableObject")
        {
            buttonADisplay.SetActive(false);
            securityStock.Remove(collision.gameObject);
        }
        if (collision.gameObject.tag == "Chest")
        {
            chestSecurityStock.Remove(collision.gameObject);
            buttonADisplay.SetActive(false);
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

    void OpenChest(GameObject chest)
    {
        Debug.Log("yo");
        if (PlayerStatusManager.canUse == true)
        {
            
            PlayerStatusManager.canUse = false;
            PlayerStatusManager.isUsing = true;

            chest.GetComponent<ChestBehaviour>().isOpen = true;

            PlayerStatusManager.needToEndUse = true;
        }
    }

}
