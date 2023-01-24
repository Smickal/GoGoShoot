using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AmmoSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxAmmo = 10;
    [SerializeField] float reloadSpeed = 2f;
    [SerializeField] float rotationTreshold = 90f;

    int curAmmo;

    [Header("Initialization")]
    [SerializeField] GameObject ammoCountOBJ;
    [SerializeField] GameObject radialOBJ;
    [SerializeField] GameObject hintReload;


    [SerializeField] TextMeshPro ammoCounter;
    [SerializeField] Image radialImage;

    bool reloaded = false;

    float currTime = 0f;
    bool timer = false;
    FireBulletOnActivate fireBulletOnActivate;

    private void Awake()
    {
        fireBulletOnActivate= GetComponent<FireBulletOnActivate>();

        curAmmo = maxAmmo;
        DisplayAmmoCount();
        EnableAmmoCount();
    }

    public void DecreaseAmmo()
    {
        if (curAmmo <= 0)
        {    
            return;
        }
        curAmmo --;
        DisplayAmmoCount();
        
    }

    private void Update()
    {
        Vector3 rotation = transform.rotation.eulerAngles;


        //Debug.Log(rotation);
        if(rotation.x >= 50f && rotation.x <= 70f && reloaded == false)
        {
            Debug.Log("Reload");
            if (curAmmo == maxAmmo) return;
            reloaded = true;
            Reload();
            timer = true;

            fireBulletOnActivate.Activate(false);
        }


        if(timer)
        {
            currTime += Time.deltaTime;
            float percentage = currTime / reloadSpeed;

            radialImage.fillAmount = percentage;

            if(currTime >= reloadSpeed)
            {
                timer = false;
                currTime= 0f;
            }
        }

        if (curAmmo <= 0)
        {
            hintReload.SetActive(true);
        }
        else
        {
            hintReload.SetActive(false);
        }
    }


    public void Reload()
    {
        DisableAmmoCount();
        FindObjectOfType<AudioManager>().PlaySound("Reload");
        StartCoroutine(StartReloading());
    }

    IEnumerator StartReloading()
    {

        yield return new WaitForSeconds(reloadSpeed);
        curAmmo = maxAmmo;
        DisplayAmmoCount();
        EnableAmmoCount();
        fireBulletOnActivate.Activate(true);
        hintReload.SetActive(false);
        reloaded = false;
    }

    public bool CheckAmmoReserve()
    {
        if(curAmmo == 0) return false;
        else
            return true;
    }

    private void DisplayAmmoCount()
    {
        ammoCounter.text = curAmmo.ToString();
    }

    private void DisableAmmoCount()
    {
        ammoCountOBJ.SetActive(false);
        radialOBJ.SetActive(true);
    }

    private void EnableAmmoCount()
    {
        ammoCountOBJ.SetActive(true);
        radialOBJ.SetActive(false);
    }
}
