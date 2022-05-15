using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public GameObject Blocks;
    public GameObject Cube,Explosive;
    public GameObject Character;
    public Text BlocksLeftText;
    public Text ExplosivesLeftText;
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
    public Text CubeText;
    public Text ExplosiveText;
    public GameObject BlockText;


    public void RestartLevel()
    {
        TotalText.GetComponent<Text>().text = PlayerPrefs.GetFloat("TotalScore").ToString("f0");
        SaveScoreData.SaveCurrentScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        ExplosiveText.text = Explosive.GetComponent<Building>().ExplosivesLeft.ToString();
        CubeText.text = Cube.GetComponent<Building>().CubesLeft.ToString();
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
            BlockText.SetActive(true);
        }
        if(Started != 1)
        {
            BlockText.SetActive(false);
        }
        if(Paused)
        {
            Time.timeScale = 0f;
            PauseBlur.SetActive(true);
            PauseText.SetActive(true);
            TotalText.SetActive(true);
            BlockText.SetActive(false);
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
