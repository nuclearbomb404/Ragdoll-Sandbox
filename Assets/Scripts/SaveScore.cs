using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour 
{
}
public static class SaveScoreData
{
    public static float PreviousScore;
    public static float TotalScore = 0;
    public static void SaveCurrentScore()
    {
        PlayerPrefs.SetFloat("TotalScore", PlayerPrefs.GetFloat("TotalScore"));
    }
}
