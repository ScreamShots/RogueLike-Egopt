using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomGenerationHandler : MonoBehaviour
{
    public List<GameObject> allRoomCreated;
    public GameObject[] allEnemy;
    public GameObject bossRoomSpawnObject;
    public RoomGenerator roomGenerator;
    public RoomList roomList;
    public int maxNumberofRoomCreated;
    public int minNumberofRoomCreated;
    public float timerEndOfGeneration;
    public static bool isLevelPlayable;
    public static bool bossRoomIsSpawned;

    private void Start()
    {
        maxNumberofRoomCreated = roomGenerator.maxNumberOfRoomCreated;
        minNumberofRoomCreated = roomGenerator.minNumberOfRoomCreated;
        timerEndOfGeneration = 0.1f;
        isLevelPlayable = false;
        bossRoomIsSpawned = false;
    }
    public void Update()
    {
        

        if (RoomGenerator.generationIsFinished == true)
        {
            timerEndOfGeneration -= Time.deltaTime;

            if (timerEndOfGeneration <= 0)
            {
                allRoomCreated = GameObject.FindGameObjectsWithTag("Rooms").ToList();
                allEnemy = GameObject.FindGameObjectsWithTag("Enemy");

                if (RoomGenerator.numberOfRoomCreated < minNumberofRoomCreated)
                {
                    ResetLevelGeneration();
                }
                else if (RoomGenerator.numberOfRoomCreated >= minNumberofRoomCreated && isLevelPlayable == false)
                {
                    CreateBossRoom();
                }
            }

        }
    }

    void ResetLevelGeneration()
    {
        Debug.Log("Nombre de Salle insuffisant, recréation du niveau en cours...");

        for (int i = 0; i < allRoomCreated.Count; i++)
        {
            Destroy(allRoomCreated[i]);
        }

        for (int i = 0; i < allEnemy.Length; i++)
        {
            Destroy(allEnemy[i]);
        }

        RoomGenerator.generationIsFinished = false;
        RoomGenerator.numberOfRoomCreated = 0;
        Instantiate(roomList.startRoom, new Vector3(0, 0, 0), transform.rotation);

        Destroy(this.gameObject);
    }

    void CreateBossRoom()
    {
        Debug.Log("Nombre de salles suffisant, chargement de la salle de Boss en cours..." + isLevelPlayable);

        var targetRoom = allRoomCreated.Count - 1;
        Instantiate(bossRoomSpawnObject, allRoomCreated[targetRoom].transform.position, transform.rotation);
        allRoomCreated.Remove(allRoomCreated[targetRoom]);
    }
}
