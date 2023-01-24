using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    // Start is called before the first frame update\\
    [SerializeField] XRBaseController rightController;

    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20f;
    AmmoSystem ammoSystem;

    [Header("Particle Effects")]
    [SerializeField] ParticleSystem ejectParticle;
    [SerializeField] ParticleSystem muzzleParticle;

    bool isActivated = true;

    public void Activate(bool isActivated)
    {
        this.isActivated = isActivated;
    }

    private void Awake()
    {
        ammoSystem = GetComponent<AmmoSystem>();
    }

    void Start()
    {
        XRBaseInteractable grabbable = GetComponent<XRBaseInteractable>();

        grabbable.activated.AddListener(FireBullet);
    }


    public void FireBullet(ActivateEventArgs arg)
    {
        if (isActivated)
        {
            if (!ammoSystem.CheckAmmoReserve()) return;

            rightController.SendHapticImpulse(0.2f, 0.5f);

            GameObject spawnBullet = Instantiate(bullet);
            spawnBullet.transform.position = spawnPoint.position;
            spawnBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            ammoSystem.DecreaseAmmo();
            FindObjectOfType<AudioManager>().PlaySound("Shoot");
            muzzleParticle.Play();
            ejectParticle.Play();
            Destroy(spawnBullet, 5f);
        }
    }
}
