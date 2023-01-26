using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HoldCub : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image radialFill;
    [SerializeField] float timeToReset = 2f;



    [Header("XRorigin")]
    [SerializeField] GameObject textHint;
    [SerializeField] Transform head;

    float timeCounter = 0f;
    bool isActivate = false;
    bool isEntered = false;

    void Start()
    {
        timeCounter = 0f;

        isActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        HoldCube();
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        textHint.transform.LookAt(new Vector3(head.position.x, textHint.transform.position.y, head.position.z));
        textHint.transform.forward *= -1;
    }

    private void HoldCube()
    {
        if (isActivate)
        {
            timeCounter += Time.deltaTime;
            radialFill.fillAmount = timeCounter / timeToReset;
        }

        if (timeCounter >= timeToReset)
        {
            SceneManagement.ResetScene();
        }
    }

    public void ActivateCounter()
    {
        isActivate = true;
    }

    public void DisableCounter()
    {
        isActivate = false;
        timeCounter = 0f;
        radialFill.fillAmount = timeCounter / timeToReset;
    }


}
