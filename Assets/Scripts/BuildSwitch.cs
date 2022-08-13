using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSwitch : MonoBehaviour
{
    public Vector3 touchpos;
    public GameObject Blocks;  
    public float BlocksLeft = 2f;
    public int selectedBlock = 0;
    int Switched = 0;
    public GameObject Button;
    // Start is called before the first frame update

    void Start()
    {
       SelectBlock(); 
    }
    public void ButtonPress()
    {
        Switched++;
    }
    void SelectBlock()
    {
        int i = 0;
        foreach (Transform Block in transform)
        {
            if(i == selectedBlock)
                Block.gameObject.SetActive(true);
            else
                Block.gameObject.SetActive(false);
            i++;
        }
    }
    void Update()
    {
        int previousSelectedBlock = selectedBlock;
        if(Switched == 1)
        {
            selectedBlock = 1;
        }
        if(Switched == 0)
        {
            selectedBlock = 0;
        }
        if(Switched == 2)
        {
            selectedBlock = 2;
        }
        if(Switched > 2)
        {
            Switched = 0;
        }
        if(previousSelectedBlock != selectedBlock)
        {
            SelectBlock();
        }
        
    }

}
