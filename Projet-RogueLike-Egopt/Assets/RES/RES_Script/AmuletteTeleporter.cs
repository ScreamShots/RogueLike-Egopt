using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AmuletteTeleporter : MonoBehaviour
{
    bool playerInRange;
    public GameObject buttonA;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pick") && playerInRange == true)
        {
            buttonA.SetActive(false);
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerInventory>().buttonADisplay.SetActive(true);
            buttonA = collision.gameObject.GetComponent<PlayerInventory>().buttonADisplay;
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerInventory>().buttonADisplay.SetActive(false);
            

            playerInRange = false;
        }
    }
}
