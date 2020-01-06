using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScoreDisplay : MonoBehaviour
{
    public Text scoreDisplay;

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = GameManager.gameManager.score.ToString();
    }
}
