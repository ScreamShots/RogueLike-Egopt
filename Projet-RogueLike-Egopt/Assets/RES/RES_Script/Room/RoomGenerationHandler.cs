using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomGenerationHandler : MonoBehaviour
{
    private List<GameObject> allRoomCreated;
    [SerializeField] private GameObject player;
    [SerializeField] private RoomList roomList;

    [SerializeField] private int inspectorMaxNumberOfRoom;
    [SerializeField] private int inspectorMinNumberOfRoom;
    public static int maxNumberOfRoom;
    public static int minNumberOfRoom;
    public static int numberOfRoomCreated;

    private float roomSpawnerAutoDestructionSecurityTimeGap;
    private float basicGenerationEndSecurityTimeGap;
    private float bossRoomGenerationEndSecurityTimeGap;

    public static bool isARoomCreatedRecently;
    public static bool isBossRoomCreated;
    public static bool isBasicGenerationFinished;
    public static bool isLevelPlayable;
    private bool security;

    private void Start()
    {
        numberOfRoomCreated = 0;
        minNumberOfRoom = inspectorMinNumberOfRoom;
        maxNumberOfRoom = inspectorMaxNumberOfRoom;

        roomSpawnerAutoDestructionSecurityTimeGap = 1f;
        bossRoomGenerationEndSecurityTimeGap = 1f;
        basicGenerationEndSecurityTimeGap = 0.1f;

        isARoomCreatedRecently = false;
        isBasicGenerationFinished = false;
        isLevelPlayable = false;
        isBossRoomCreated = false;
        security = true;

    }
    private void Update()
    {
        if (isARoomCreatedRecently == false)
        {
            roomSpawnerAutoDestructionSecurityTimeGap -= Time.deltaTime;

            if (roomSpawnerAutoDestructionSecurityTimeGap <= 0)
            {
                isBasicGenerationFinished = true;
                Debug.Log("Fin de la génération des salles de base");
                Debug.Log("Nombre de salles " + numberOfRoomCreated);
            }
        }
        else if (isARoomCreatedRecently == true)
        {
            isARoomCreatedRecently = false;
        }

        if (isBasicGenerationFinished == true && security == true)
        {
            basicGenerationEndSecurityTimeGap -= Time.deltaTime;

            if (basicGenerationEndSecurityTimeGap <= 0)
            {
                allRoomCreated = GameObject.FindGameObjectsWithTag("Rooms").ToList();

                if (numberOfRoomCreated < minNumberOfRoom)
                {
                    Debug.Log("Nombre de Salle insuffisant");
                    ResetLevelGeneration();
                }
                else if (RoomGenerator.shopIsSpawned == false)
                {
                    ResetLevelGeneration();
                }
                else if (numberOfRoomCreated >= minNumberOfRoom && isLevelPlayable == false)
                {
                    CreateBossRoom();
                    security = false;
                }
               
            }
        }

        if (isBossRoomCreated == true)
        {
            bossRoomGenerationEndSecurityTimeGap -= Time.deltaTime;

            if (bossRoomGenerationEndSecurityTimeGap <= 0)
            {
                if (BossRoomGenerationSecurity.isBossRoomSpawnedCorrectly == true)
                {
                    isLevelPlayable = true;
                }
                if (BossRoomGenerationSecurity.isBossRoomSpawnedCorrectly == false)
                {
                    Debug.Log("Bug dans la génération de la salle de Boss");
                    ResetLevelGeneration();
                }
            }            
        }

        if (isLevelPlayable == true)
        {
            Debug.Log("Fin de la génération du niveau. Amusez vous bien!");
            Instantiate(player, transform.position, transform.rotation);
            Destroy(GetComponent<RoomGenerationHandler>());
        }
    }

    public void ResetLevelGeneration()
    {
        Debug.Log("recréation du niveau en cours...");
        RoomGenerator.shopIsSpawned = false;
        GameObject[] allRoom = GameObject.FindGameObjectsWithTag("Rooms");

        Instantiate(roomList.startRoom, new Vector3(0, -0.162f, 0), transform.rotation);

        /*for (int i = 0; i < allRoomCreated.Count; i++)
        {
            //Destroy(allRoomCreated[i]);
        }*/
        for (int i = 0; i < allRoom.Length; i++)
       {
           Destroy(allRoom[i]);
       }

    }

    void CreateBossRoom()
    {
        if (isBossRoomCreated == false)
        {
            Debug.Log("Nombre de salles suffisant, chargement de la salle de Boss en cours...");

            int targetRoom = allRoomCreated.Count - 1;

            Instantiate(roomList.bossRoomSpawnEntity, allRoomCreated[targetRoom].transform.position, transform.rotation);
            allRoomCreated.Remove(allRoomCreated[targetRoom]);
        }        
    }
}
