using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPicking : MonoBehaviour
{
    public int goldValue;

    public GameObject musicManagerEnvironnement;

    private void Awake()
    {
        musicManagerEnvironnement = GameObject.FindGameObjectWithTag("MusicManager_Environnement");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            musicManagerEnvironnement.GetComponent<AudioSource>().clip = musicManagerEnvironnement.GetComponent<Audio_Manager_Environnement>().environnementAudioClip[0];
            musicManagerEnvironnement.GetComponent<AudioSource>().Play();
            GameManager.gameManager.gold += goldValue;
            GameManager.gameManager.score += goldValue;
            Destroy(gameObject);
        }
    }


}
