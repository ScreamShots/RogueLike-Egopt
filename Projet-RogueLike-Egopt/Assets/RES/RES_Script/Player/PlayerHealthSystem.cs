using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthSystem : MonoBehaviour
{
    //Statement

    public float playerMaxHp;
    public float playerMinHp;
    public float playerHp;

    public float playerLostHp;

    [SerializeField] private float playerImmuneTime;
    public static bool playerIsImune;
    public bool playerTookDmg;
    public float timer;
    public GameObject gameOverBackGround;
    public GameObject gameOverUI;
    public bool godMod = false;


    //Music
    public AudioSource playerAudioSource;
    void Start()
    {
        playerHp = playerMaxHp;
        playerIsImune = false;
        playerTookDmg = false;
        playerLostHp = playerMaxHp;

        //Sound
        playerAudioSource = GetComponent<Audio_Manager_Player>().audioSourcePlayer;
    }
    
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (godMod == true)
            {
                godMod = false;
            }
            else if (godMod == false)
            {
                godMod = true;
            }
        }

        if (playerHp <= 0)
        {
            
            StartCoroutine(PlayerDeath());
            

        }

        if (playerTookDmg == true)
        {
            if(timer >= 1)
            {
                playerLostHp = playerHp;
                playerTookDmg = false;
            }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }
    }

    public void IsTakingDmg(float damageValue)       //Put every action requiered when the player is taking dmg on this fonction
    {
        if (playerIsImune == false && godMod == false)
        {
            
            playerHp -= damageValue;
            playerAudioSource.clip = GetComponent<Audio_Manager_Player>().playerAudioClip[0];
            playerAudioSource.Play();
            //StartCoroutine(PlayerImmunityActivation());
            playerTookDmg = true;
            timer = 0;
        }      
    }

    public void PlayerIsHealing(float healValue)             //Put every action requiered when the player is healed on this fonction  
    {
        playerHp += healValue;
       

        if (playerHp > playerMaxHp)
        {
            playerHp = playerMaxHp;
        }
    }

    IEnumerator PlayerDeath()                                  //Put every action requiered when the player is dead on this function
    {
        
        Collider2D[] allColliders = GetComponentsInChildren<Collider2D>();
        for (int i =0; i < allColliders.Length; i++)
        {
            allColliders[i].enabled = false;
        }
        
        GetComponentInChildren<Animator>().SetTrigger("Die");
        PlayerStatusManager.isLoading = true;
        yield return new WaitForSeconds(1f);
        gameOverBackGround.SetActive(true);
        gameOverBackGround.GetComponentInChildren<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        gameOverUI.SetActive(true);

        
    }

    public IEnumerator PlayerImmunityActivation()
    {
        playerIsImune = true;

        yield return new WaitForSeconds(playerImmuneTime);

        playerIsImune = false;
    }
}
