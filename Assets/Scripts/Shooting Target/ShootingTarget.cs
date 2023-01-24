using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingTarget : MonoBehaviour
{
    [SerializeField] bool isMoving = false;
    [SerializeField] float speed = 1f;

    [Header("Points")]
    [SerializeField] int headPoint = 500;
    [SerializeField] int bodyPoint = 100;


    [SerializeField] int healthPoint = 3;
    ScoreSystem scoreSystem;

    Vector3 startpos, endPos;
    Vector3 curPos, targetPos;
    AudioManager manager;

    [SerializeField] GameObject explosionEffects;

    private void Awake()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        manager = FindObjectOfType<AudioManager>();
        
    }

    private void Start()
    {
        startpos = transform.position;
        FindAEndSpot();

        curPos = startpos;
        targetPos = endPos;
    }

    private void Update()
    {
        if(isMoving)
        {
            

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            curPos = transform.position;
            if(Vector3.Distance(curPos, targetPos) <= 0.2f)
            {
                ChangeTarget();
            }


        }
    }

    private void ChangeTarget()
    {
        float curToStart = Vector3.Distance(curPos, startpos);
        float curToEnd = Vector3.Distance(curPos, endPos);

        if(curToStart > curToEnd)
        {
            targetPos = startpos;
        }
        else
        {
            targetPos = endPos;
        }
    }

    public void HitHead()
    {
        //tobeadded VFX meledak
        scoreSystem.IncreaseScore(headPoint);
        manager.PlaySound("Explode");
        ExplodeEffect();
        Destroy(gameObject);
    }

    public void HitBody()
    {
        healthPoint--;

        
        if(healthPoint <= 0)
        {
            //tobeadded VFX meledak
            manager.PlaySound("Explode");
            ExplodeEffect();
            Destroy(gameObject);
        }

        scoreSystem.IncreaseScore(bodyPoint);
    }


    private void FindAEndSpot()
    {
        Transform endTrans = GetComponentInParent<TargetSpawn>().FindALocation(transform);
        endPos = endTrans.position;
    }

    private void ExplodeEffect()
    {
        GameObject newExplosion = Instantiate(explosionEffects, transform.position, Quaternion.identity);
        Destroy(newExplosion, 5f);
    }
}
