using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftHandRay;
    public GameObject rightHandRay;

    public XRDirectInteractor leftDirectGrab;
    public XRDirectInteractor rightDirectGrab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftHandRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0);
        rightHandRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
    }
}
