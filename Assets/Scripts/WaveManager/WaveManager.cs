using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("variables")]
    [SerializeField] int maxWave = 3;

    [Header("TargetSpawn")]
    [SerializeField] GameObject waveContainer;
    [SerializeField] TargetSpawn spawn1;
    [SerializeField] TargetSpawn spawn2;
    [SerializeField] TargetSpawn spawn3;

    [Header("Initialization")]
    [SerializeField] GameObject scoreContainer;
    [SerializeField] GameObject waveStartingContainer;
    [SerializeField] GameObject GameObjectwaveEndingContainer;

    // Update is called once per frame
    int currWave = 1;
    private void Start()
    {
        StartCoroutine(ChangeToScorePanel());
    }
    void Update()
    {
        CheckForNewSession();

       
    }

    private void CheckForNewSession()
    {
        ShootingTarget[] allTargets = FindObjectsOfType<ShootingTarget>();

        if (spawn1.IsAllSpawned() && spawn2.IsAllSpawned() && spawn3.IsAllSpawned()
            && allTargets.Length == 0)
        {
            NewSession();
            currWave++;

            if (currWave > maxWave)
            {
                GameObjectwaveEndingContainer.SetActive(true);
                Destroy(waveContainer);
            }
        }
    }

    private void NewSession()
    {
        spawn1.ResetCurr();
        spawn2.ResetCurr();
        spawn3.ResetCurr();
        

        spawn2.IncreaseMaxSpawn(1);
        spawn3.IncreaseMaxSpawn(1);


        StartCoroutine(ChangeToScorePanel());
    }

    IEnumerator ChangeToScorePanel()
    {
        scoreContainer.SetActive(false);
        waveStartingContainer.SetActive(true);

        yield return new WaitForSeconds(3f);

        scoreContainer.SetActive(true);
        waveStartingContainer.SetActive(false);

    }
}
