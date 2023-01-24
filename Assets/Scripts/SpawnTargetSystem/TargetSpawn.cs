using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform[] spawnLoc;

    [SerializeField] float maxTimeToSpawnAtPoint = 3f;
    [SerializeField] float minTimeToSpawnAtPoint = 1f;

    [SerializeField] GameObject target;
    
    [SerializeField] int maxSpawn;
    int curSpawn;
    bool[] spawnedLoc;
    bool spawned = false;
    void Start()
    {
        
        spawnedLoc = new bool[spawnLoc.Length];

        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnATarget();

    }

    private void SpawnATarget()
    {
        if (spawned == false && curSpawn < maxSpawn)
        {
            Transform spawn = GetRandomSpawnLocation();

            float timeToSpawn = Random.Range(minTimeToSpawnAtPoint, maxTimeToSpawnAtPoint);

            if (spawn != null)
            {
                spawned = true;
                StartCoroutine(SpawnTarget(timeToSpawn, spawn));
            }
            
            //Debug.Log(spawn);
        }
    }

    IEnumerator SpawnTarget(float timeValue, Transform transform)
    {
        Instantiate(target, transform);
        yield return new WaitForSeconds(timeValue);

        spawned = false;
    }



    private Transform GetRandomSpawnLocation()
    {
        do
        {
            int randomNumber = Random.Range(0, spawnLoc.Length);
            //Debug.Log(randomNumber);
            if (spawnedLoc[randomNumber] == false)
            {
                curSpawn++;
                spawnedLoc[randomNumber]= true;
                return spawnLoc[randomNumber];
            }

        } while (curSpawn < maxSpawn);

        return null;
    }


    public Transform FindALocation(Transform curLoc)
    {
        int randomSpawnLoc;

        do
        {
            randomSpawnLoc = Random.Range(0, spawnLoc.Length);

        } while (curLoc == spawnLoc[randomSpawnLoc]);

        return spawnLoc[randomSpawnLoc];

    }

    public void ResetCurr()
    {
        curSpawn = 0;
    }

    public void IncreaseMaxSpawn(int value)
    {
        maxSpawn += value;
    }

    public bool IsAllSpawned()
    {
        if(curSpawn >= maxSpawn)
        {
            Debug.Log("true");
            return true;
        }
        else
        {
            Debug.Log("false");
            return false;
        }
    }
}
