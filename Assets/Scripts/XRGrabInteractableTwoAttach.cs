using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    public Transform leftHandTransform;
    public Transform rightHandTransform;
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.CompareTag("leftHand"))
        {
            attachTransform = leftHandTransform;
        }
        else if(args.interactorObject.transform.CompareTag("rightHand"))
        {
            attachTransform = rightHandTransform;
        }

        base.OnSelectEntered(args);
    }


}
