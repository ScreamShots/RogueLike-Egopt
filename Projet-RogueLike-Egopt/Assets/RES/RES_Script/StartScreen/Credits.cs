using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public float timer = 0;
    public Image charger;
    private void FixedUpdate()
    {
        if (Input.GetButton("SelectMenu"))
        {
            if (timer < 1.5f)
            {
                timer += Time.fixedDeltaTime;
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetButtonUp("SelectMenu"))
        {
            timer = 0;
        }

        charger.fillAmount = (timer / 1.5f);
    }
}
