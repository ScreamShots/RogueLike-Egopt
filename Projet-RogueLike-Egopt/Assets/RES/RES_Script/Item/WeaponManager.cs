using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float weaponAttackSpeed;
    public float weaponDmg;
    public float weaponImobilisationTime;
    public float launchingTime;
    public float durability;
    public float maxdurability;

    public bool isBroke;
    public GameObject brokeMode;

    [SerializeField] public Sprite iconDisplay; //Temporary Inventory UI

    public List<GameObject> enemyInRangList;

    public int weaponId; // 0 = saber 1 = spear 2 = hammer


    public AudioSource weaponAudioSource;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponAudioSource = player.GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter2D(Collider2D character)
    {
        if (character.gameObject.tag == "Enemy" || character.gameObject.tag == "Cristal" && character.gameObject.tag != "CharacterGroundCollision" && character.gameObject.tag != "CristalComposite")
        {
            enemyInRangList.Add(character.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D character)
    {
        if (character.gameObject.tag == "Enemy" || character.gameObject.tag == "Cristal")
        {
            enemyInRangList.Remove(character.gameObject);
        }

    }


    public void Break()
    {
        if (isBroke == false)
        {
            PlayerInventory.playerInventory[PlayerInventory.inventoryIndex] = brokeMode;
            Destroy(PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex]);
            PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex] = Instantiate(brokeMode);
            PlayerInventory.durabilityStock[PlayerInventory.inventoryIndex].SetActive(false);

            Destroy(gameObject);
        }


    }

    public bool WeaponAttack(float adDmg)
    {
        bool enemyInRang = false;
        StartCoroutine(WeaponAttackBis(adDmg));


        for (int i = 0; i < enemyInRangList.Count; i++)
        {
            if (enemyInRangList[i] != null)
            {
                Debug.Log("test");
                enemyInRang = true;
            }
        }

        if (enemyInRang == true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    IEnumerator WeaponAttackBis(float adDmg)
    {
        if (weaponId == 0)
        {
            weaponAudioSource.clip = player.GetComponent<Audio_Manager_Player>().playerAudioClip[6];
            weaponAudioSource.Play();
        }
        else if (weaponId == 1)
        {
            weaponAudioSource.clip = player.GetComponent<Audio_Manager_Player>().playerAudioClip[7];
            weaponAudioSource.Play();
        }
        else if (weaponId == 2)
        {
            weaponAudioSource.clip = player.GetComponent<Audio_Manager_Player>().playerAudioClip[8];
            weaponAudioSource.Play();
        }

        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < enemyInRangList.Count; i++)
        {
            if (enemyInRangList[i] != null)
            {
               
                if (enemyInRangList[i].tag == "Cristal")
                {
                    CristalManager.cristalInstance.TakeDamage(weaponDmg + adDmg);
                }
                else
                {
                    enemyInRangList[i].GetComponent<EnemyHealthSystem>().IsTakingDmg(weaponDmg + adDmg);


                }
                
            }

        }
        yield return new WaitForSeconds(0.1f);

        Destroy(this.gameObject);
    }
}
