using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStyleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] roomStyle;
    private int randomNumber;

    private void Awake()
    {
        randomNumber = Random.Range(0, roomStyle.Length);
        Instantiate(roomStyle[randomNumber], transform.parent, false);
        Destroy(this.gameObject);
    }
}
