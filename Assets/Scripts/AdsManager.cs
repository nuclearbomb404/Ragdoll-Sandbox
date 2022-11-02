using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4884355");
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void PlayAd()
    {
        Debug.Log("bruh");
        if (Advertisement.IsReady("AndroidReward"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("AndroidReward",options);
        }
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                float AdBonus = PlayerPrefs.GetFloat("TotalScore") + 100f;
                PlayerPrefs.SetFloat("TotalScore",AdBonus);
                Debug.Log(AdBonus);
                SaveScoreData.SaveCurrentScore();
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
}
