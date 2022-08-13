using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        anim.Play("RainbowAnim");
    }
}
