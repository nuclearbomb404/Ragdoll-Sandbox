using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    public Text timeText;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        timer = Time.time / 1.5f;
        timeText.text = timer.ToString("F2");
    }
}
