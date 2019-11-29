using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationHandler : MonoBehaviour
{
    public GameObject[] allRoomCreated;
    public GameObject[] allEnemy;
    public GameObject bossRoomSpawnObject;
    public RoomGenerator roomGenerator;
    public RoomList roomList;
    public int maxNumberofRoomCreated;
    public int minNumberofRoomCreated;
    public float timerEndOfGeneration;
    public static bool isLevelPlayable;

    private void Start()
    {
        maxNumberofRoomCreated = roomGenerator.maxNumberOfRoomCreated;
        minNumberofRoomCreated = roomGenerator.minNumberOfRoomCreated;
        timerEndOfGeneration = 2f;
        isLevelPlayable = false;
    }
    public void Update()
    {
        allRoomCreated = GameObject.FindGameObjectsWithTag("Rooms");

        if (RoomGenerator.generationIsFinished == true)
        {
            timerEndOfGeneration -= Time.deltaTime;

            if (timerEndOfGeneration <= 0)
            {

                if (RoomGenerator.numberOfRoomCreated < minNumberofRoomCreated)
                {
                    Debug.Log("Nombre de Salle insuffisant, recréation du niveau en cours...");
                    

                    for (int i = 0; i < allRoomCreated.Length; i++)
                    {
                        Destroy(allRoomCreated[i]);
                    }

                    allEnemy = GameObject.FindGameObjectsWithTag("Enemy");

                    for (int i = 0; i < allEnemy.Length; i++)
                    {
                        Destroy(allEnemy[i]);
                    }

                    RoomGenerator.generationIsFinished = false;
                    RoomGenerator.numberOfRoomCreated = 0;
                    Instantiate(roomList.startRoom, new Vector3(0, 0, 0), transform.rotation);

                    Destroy(this.gameObject);

                }
                else if (RoomGenerator.numberOfRoomCreated >= minNumberofRoomCreated)
                {
                    Debug.Log("Nombre de salles suffisant, chargement de la salle de Boss en cours...");
                    

                    for (int a = allRoomCreated.Length; a > 0; a--)
                    {
                        Debug.Log("Création du spawner");
                        Instantiate(bossRoomSpawnObject, allRoomCreated[a-1].transform.position, transform.rotation);
                        
                        
                        if (BossRoomSpawner.bossRoomIsSpawned == true)
                        {
                            isLevelPlayable = true;
                            break;
                        }

                    }
                }
            }

        }
    }
}
