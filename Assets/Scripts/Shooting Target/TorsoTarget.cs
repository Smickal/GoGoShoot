using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TorsoTarget : MonoBehaviour
{
    [SerializeField] ShootingTarget shootingTarget;


    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioManager>().PlaySound("HitBody");
        shootingTarget.HitBody();
        //Debug.Log("hit Torso");
    }
}
