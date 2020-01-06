using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDGoldDisplay : MonoBehaviour
{

    public Text goldDisplay;

    // Update is called once per frame
    void Update()
    {
        goldDisplay.text = GameManager.gameManager.gold.ToString();
    }
}
