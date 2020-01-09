using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Transform[] spawnPointList;
    public GameObject[] enemyPool;
    public float timeBtwWave;
    public List<GameObject> allEnemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            KillAllEnemy();
        }  
    }

    public void KillAllEnemy()
    {
        for (int i = 0; i < allEnemy.Count; i++)
        {
            if (allEnemy[i] != null)
            {
                Destroy(allEnemy[i]);
            }
        }
    }
    public void LaunchPhaseOne()
    {
        for (int i = 0; i < spawnPointList.Length; i++)
        {
            allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
        }
        StartCoroutine(PhaseOne());
    }

    public void LaunchPhaseTwo()
    {
        int skeletonAmount = 0;
        int scorpionAmount = 0;
        int mobSelected;

        StopAllCoroutines();

        for (int i = 0; i < spawnPointList.Length; i++)
        {
            mobSelected = Random.Range(0, 1);

            if (mobSelected == 0)
            {
                if (skeletonAmount < 4)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
            }
            else if (mobSelected == 1)
            {
                if (scorpionAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
            }

        }
        StartCoroutine(PhaseTwo());
    }

    public void LaunchPhaseThree()
    {
        int skeletonAmount = 0;
        int scorpionAmount = 0;
        int golemAmount = 0;
        int mobSelected;

        StopAllCoroutines();

        for (int i = 0; i < spawnPointList.Length; i++)
        {
            mobSelected = Random.Range(0, 2);

            if (mobSelected == 0)
            {
                if (skeletonAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (golemAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
            }
            else if (mobSelected == 1)
            {
                if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (skeletonAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (golemAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
            }
            else if (mobSelected == 2)
            {
                if (golemAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
                else if (skeletonAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
            }
        }
        StartCoroutine(PhaseThree());
    }

    public void LaunchPhaseFour()
    {
        int skeletonAmount = 0;
        int scorpionAmount = 0;
        int golemAmount = 0;
        int mobSelected;

        StopAllCoroutines();

        for (int i = 0; i < spawnPointList.Length; i++)
        {
            mobSelected = Random.Range(0, 2);

            if (mobSelected == 0)
            {
                if (skeletonAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (golemAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
            }
            else if (mobSelected == 1)
            {
                if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (skeletonAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (golemAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
            }
            else if (mobSelected == 2)
            {
                if (golemAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
                else if (skeletonAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
            }
        }

        StartCoroutine(PhaseFour());
    }

    public void LaunchPhaseFive()
    {
        int skeletonAmount = 0;
        int scorpionAmount = 0;
        int golemAmount = 0;
        int mobAmout = 0;
        int mobSelected;
        int spawnPointIndex = 0;

        StopAllCoroutines();

        while (mobAmout < 7)
        {
            spawnPointIndex += 1;
            if (spawnPointIndex >= spawnPointList.Length)
            {
                spawnPointIndex = 0;
            }

            mobSelected = Random.Range(0, 2);

            if (mobSelected == 0 && skeletonAmount < 3)
            {
                allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                skeletonAmount += 1;
                mobAmout += 1;
            }
            else if (mobSelected == 1 && scorpionAmount < 2)
            {
                allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                scorpionAmount += 1;
                mobAmout += 1;
            }
            else if (mobSelected == 2 && golemAmount < 2)
            {
                allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                golemAmount += 1;
                mobAmout += 1;
            }
            else if (skeletonAmount < 2)
            {
                allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                skeletonAmount += 1;
                mobAmout += 1;
            }
            else if (scorpionAmount < 2)
            {
                allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                scorpionAmount += 1;
                mobAmout += 1;
            }
            else
            {
                allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                golemAmount += 1;
                mobAmout += 1;
            }
        }
        StartCoroutine(PhaseFive());
    }

    public void StopPhaseFive()
    {
        KillAllEnemy();
        StopAllCoroutines();
    }

    IEnumerator PhaseOne()
    {
        Debug.Log("phaseOne");
        yield return new WaitForSeconds(timeBtwWave);

        for (int i = 0; i < spawnPointList.Length; i++)
        {
            allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
        }

        StartCoroutine(PhaseOne());
    }

    IEnumerator PhaseTwo()
    {
        int skeletonAmount = 0;
        int scorpionAmount = 0;
        int mobSelected;

        Debug.Log("phaseTwo");
        yield return new WaitForSeconds(timeBtwWave);

        for (int i = 0; i < spawnPointList.Length; i++)
        {
            mobSelected = Random.Range(0, 1);

            if (mobSelected == 0)
            {
                if(skeletonAmount < 4)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
            }
            else if (mobSelected == 1)
            {
                if (scorpionAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (skeletonAmount <  4)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
            }
            
        }

        StartCoroutine(PhaseTwo());
    }

    IEnumerator PhaseThree()
    {
        int skeletonAmount = 0;
        int scorpionAmount = 0;
        int golemAmount = 0;
        int mobSelected;

        Debug.Log("phaseThree");
        yield return new WaitForSeconds(timeBtwWave);

        for (int i = 0; i < spawnPointList.Length; i++)
        {
            mobSelected = Random.Range(0, 2);

            if (mobSelected == 0)
            {
                if (skeletonAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (golemAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
            }
            else if (mobSelected == 1)
            {
                if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (skeletonAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (golemAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
            }
            else if (mobSelected == 2)
            {
                if (golemAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
                else if (skeletonAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
            }
        }

        StartCoroutine(PhaseThree());

    }

    IEnumerator PhaseFour()
    {
        int skeletonAmount = 0;
        int scorpionAmount = 0;
        int golemAmount = 0;
        int mobSelected;

        Debug.Log("phaseFour");
        yield return new WaitForSeconds(timeBtwWave);

        for (int i = 0; i < spawnPointList.Length; i++)
        {
            mobSelected = Random.Range(0, 2);

            if (mobSelected == 0)
            {
                if (skeletonAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (golemAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
            }
            else if (mobSelected == 1)
            {
                if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
                else if (skeletonAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (golemAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
            }
            else if (mobSelected == 2)
            {
                if (golemAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[i].position, Quaternion.identity));
                    golemAmount += 1;
                }
                else if (skeletonAmount < 1)
                {
                    allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[i].position, Quaternion.identity));
                    skeletonAmount += 1;
                }
                else if (scorpionAmount < 2)
                {
                    allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[i].position, Quaternion.identity));
                    scorpionAmount += 1;
                }
            }
        }

        StartCoroutine(PhaseFour());
    }

    IEnumerator PhaseFive()
    {
        int skeletonAmount = 0;
        int scorpionAmount = 0;
        int golemAmount = 0;
        int mobAmout = 0;
        int mobSelected;
        int spawnPointIndex = 0;

        Debug.Log("phaseFive");
        yield return new WaitForSeconds(timeBtwWave);

        while (mobAmout < 7)
        {
            spawnPointIndex += 1;
            if (spawnPointIndex >= spawnPointList.Length)
            {
                spawnPointIndex = 0;
            }
            
            mobSelected = Random.Range(0, 2);

            if(mobSelected == 0 && skeletonAmount < 3)
            {
                allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                skeletonAmount += 1;
                mobAmout += 1;
            }
            else if (mobSelected == 1 && scorpionAmount < 2)
            {
                allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                scorpionAmount += 1;
                mobAmout += 1;
            }
            else if (mobSelected == 2 && golemAmount < 2)
            {
                allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                golemAmount += 1;
                mobAmout += 1;
            }
            else if(skeletonAmount < 2)
            {
                allEnemy.Add(Instantiate(enemyPool[0], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                skeletonAmount += 1;
                mobAmout += 1;
            }
            else if(scorpionAmount < 2)
            {
                allEnemy.Add(Instantiate(enemyPool[1], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                scorpionAmount += 1;
                mobAmout += 1;
            }
            else
            {
                allEnemy.Add(Instantiate(enemyPool[2], spawnPointList[spawnPointIndex].position, Quaternion.identity));
                golemAmount += 1;
                mobAmout += 1;
            }
        }
        StartCoroutine(PhaseFive());
    }
}
