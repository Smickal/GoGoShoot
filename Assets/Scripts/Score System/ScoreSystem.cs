using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int score = 0;

    [SerializeField] TextMeshPro scoreCounter;

    private void Awake()
    {
        scoreCounter.text = score.ToString();
    }

    public void IncreaseScore(int value)
    {
        FindObjectOfType<AudioManager>().PlaySound("Point");
        score += value;
        scoreCounter.text = score.ToString();
    }
}
