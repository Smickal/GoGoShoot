using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTarget : MonoBehaviour
{
    [SerializeField] ShootingTarget shootingTarget;


    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioManager>().PlaySound("HitHead");
        shootingTarget.HitHead();
        //Debug.Log("Hit Head");
    }
}
