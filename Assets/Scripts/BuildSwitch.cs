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
    bool Switched = false;
    public GameObject Button;
    // Start is called before the first frame update

    void Start()
    {
       SelectBlock(); 
    }
    public void ButtonPress()
    {
        Switched = !Switched;
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
        if(Switched)
        {
            selectedBlock = 1;
        }
        if(!Switched)
        {
            selectedBlock = 0;
        }
        if(previousSelectedBlock != selectedBlock)
        {
            SelectBlock();
        }
        
    }

}
