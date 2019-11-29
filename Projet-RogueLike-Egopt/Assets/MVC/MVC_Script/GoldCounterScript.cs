using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounterScript : MonoBehaviour
{
    public static int goldsCounter = 0;
    Text golds;

    
    void Start()
    {
        golds = GetComponent<Text>();
    }

   
    void Update()
    {
        golds.text = "Golds: " + goldsCounter;
    }
    // ajouter dans le script de l'objet qui fait monter les golds : GoldCounterScript.goldsCounter += valeur choisit

}
