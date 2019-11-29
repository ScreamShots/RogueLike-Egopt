using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStyleGenerator : MonoBehaviour
{
    public GameObject[] roomStyle;
    public int randomNumber;
    public GameObject roomStyleChoosed;

    private void Awake()
    {
        randomNumber = Random.Range(0, roomStyle.Length);
        roomStyleChoosed = Instantiate(roomStyle[randomNumber]);
        roomStyleChoosed.transform.position = GetComponent<Transform>().position;
        roomStyleChoosed.transform.parent = GetComponent<Transform>().parent;
        Destroy(this.gameObject);

    }
}
