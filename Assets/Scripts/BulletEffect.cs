using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject bulletParticle;


    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;

        GameObject newParticle = Instantiate(bulletParticle, normal, Quaternion.identity);

        Destroy(newParticle, 2f);
    }
}
