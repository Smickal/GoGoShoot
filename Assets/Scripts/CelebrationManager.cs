using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] fireworks;

    bool activated = false;

    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("Firework");
    }

    // Update is called once per frame
    
}
