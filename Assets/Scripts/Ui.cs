using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public GameObject Blocks;
    public GameObject Character;
    public Text BlocksLefttext;
    public GameObject Play;
    public GameObject SwitchCube;
    public GameObject Restart;
    public int Started = 0;
    public Transform PlayStage2;
    public GameObject PauseBlur;
    public bool Paused;
    public GameObject PauseText;
    public GameObject TotalText;
    public float period;
    public GameObject CubeText;
    public GameObject ExplosiveText;


    public void RestartLevel()
    {
        TotalText.GetComponent<Text>().text = PlayerPrefs.GetFloat("TotalScore").ToString("f0");
        SaveScoreData.SaveCurrentScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if(period > 1)
        {
            PlayerPrefs.SetFloat("TotalScore", PlayerPrefs.GetFloat("TotalScore")+1);
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
        TotalText.GetComponent<Text>().text = PlayerPrefs.GetFloat("TotalScore").ToString("f0");
        PauseText.SetActive(false);
        if(Started > 1)
        {
            Time.timeScale = 1f;
            SwitchCube.SetActive(false);
            Play.SetActive(false);
            TotalText.SetActive(false);
            
        }
        if(Started >= 1)
        {
            PauseBlur.SetActive(false);
            
        }
        if(Started == 1)
        {
            ExplosiveText.SetActive(true);
            CubeText.SetActive(true);
        }
        if(Started != 1)
        {
            ExplosiveText.SetActive(false);
            CubeText.SetActive(false);
        }
        if(Paused)
        {
            Time.timeScale = 0f;
            PauseBlur.SetActive(true);
            PauseText.SetActive(true);
            TotalText.SetActive(true);
            ExplosiveText.SetActive(false);
            CubeText.SetActive(false);
        }
    }
    void Start()
    {
       TotalText.GetComponent<Text>().text = PlayerPrefs.GetFloat("TotalScore").ToString("f0");
       Time.timeScale = 0f;
       Started = 0;
    }
    public void StartLevel()
    {
        Started++;
        Play.transform.position = Vector3.MoveTowards(Play.transform.position,PlayStage2.position,1000f);
        Restart.SetActive(true);
        SwitchCube.SetActive(true);
    }
    public void Pause()
    {
        if(Started >= 2 )
        {
            Paused = !Paused;
        }

    }
}
