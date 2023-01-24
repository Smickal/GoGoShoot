using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ActivateTeleportLine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rightRay;
    public float activateTreshold = 0.5f;

    public InputActionProperty rightActionRay;

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = rightActionRay.action.ReadValue<Vector2>();
        rightRay.SetActive(moveDir.y < -activateTreshold);  
    }
}
