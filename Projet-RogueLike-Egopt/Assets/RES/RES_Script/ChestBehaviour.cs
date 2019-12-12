using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public int numberOfDrop;
    public List<GameObject> itemToDrop;
    public GameObject[] dropZone;
    public bool isOpen;

    private void Start()
    {
        numberOfDrop = 0;
        isOpen = false;
    }

    private void Update()
    {
        if(isOpen == true)
        {
            numberOfDrop = Random.Range(0, dropZone.Length /2);

            for(int i =0; i <= numberOfDrop; i++)
            {
                GameObject itemDroped = itemToDrop[Random.Range(0, itemToDrop.Count)];
                Instantiate(itemDroped, dropZone[i].transform.position, Quaternion.identity);
                itemToDrop.Remove(itemDroped);
            }

            Destroy(this.gameObject);
        }
    }

}
