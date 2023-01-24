using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SetTurnType : MonoBehaviour
{
    // Start is called before the first frame update
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider continuousTurn;


    private void Start()
    {
        continuousTurn.enabled = true;
        snapTurn.enabled = false;
    }


    public void SetTypeFromIndex(int index)
    {
       if(index == 0)
        {
            continuousTurn.enabled = true;
            snapTurn.enabled = false;
        }
       else if(index == 1)
        {
            continuousTurn.enabled = false;
            snapTurn.enabled = true;
        }
    }
}
