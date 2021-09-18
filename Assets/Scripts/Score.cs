using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject ScoreText;
    public float ScoreFloat;
    public LayerMask CollideMask;
    public bool Collided;
    void Update()
    {
        ScoreText.GetComponent<Text>().text = ScoreFloat.ToString("f0");
        ScoreFloat = Time.timeSinceLevelLoad;
        if(Canvas.GetComponent<Ui>().Paused)
        {
            ScoreText.SetActive(false);
        }
        else
        {
            ScoreText.SetActive(true);
        }
    }
    
}
