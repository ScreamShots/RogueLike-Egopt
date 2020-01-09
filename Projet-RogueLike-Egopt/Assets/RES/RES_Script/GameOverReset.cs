using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverReset : MonoBehaviour
{
    public Text gold;
    public Text score;

    void Update()
    {
        gold.text =  GameManager.gameManager.gold.ToString();
        score.text = GameManager.gameManager.score.ToString();

        if (Input.GetButtonDown("SelectMenu"))
        {
            GameManager.gameManager.ResetGame();
        }
    }
}
