using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableStorage : MonoBehaviour
{
    [SerializeField] public GameObject storedObject;
    public float storedObjectDurability;
    public float baseStoredObjectDurability;
    public bool dropedByThePlayer;
    public bool duraSet = false;

    private void Start()
    {
        if(storedObject.tag == "Weapon")
        {
            baseStoredObjectDurability = storedObject.GetComponent<WeaponManager>().durability;
        }
        
    }

    private void Update()
    {
      if(dropedByThePlayer == false && duraSet == false)
        {
            duraSet = true;
            storedObjectDurability = baseStoredObjectDurability;            
            Debug.Log("yo");
        }   
    }
}
