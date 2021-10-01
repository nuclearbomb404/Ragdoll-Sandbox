using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public int currentText = 0;
    public Animator Chat1;
    public Animator Chat2;
    public Animator Chat4;
    // Start is called before the first frame update
    void Start()
    {
        SelectText();
    }

    // Update is called once per frame
    void Update()
    {
        int previousText = currentText;
        if(Input.GetButtonDown("Fire1"))
        {
            currentText++;
        }
        if(previousText != currentText)
        {
            SelectText();
        }
    }
    void SelectText()
    {
        int i = 0;
        foreach (Transform Text in transform)
        {
            if(i == currentText)
                Text.gameObject.SetActive(true);
            else
                Text.gameObject.SetActive(false);
            i++;
        }
    }
}
