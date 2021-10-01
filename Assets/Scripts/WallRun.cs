using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WallRun : MonoBehaviour
{
    public GameObject Player;
    public GameObject WRfloor;
    public GameObject WallrunThing;
    public GameObject cylinder;
    public GameObject groundcheck;
    public bool isWalled;
    public bool isWalledR;
    public Transform wallcheckR;
    public GameObject wallCheck;
    public float wallDistance = 2f;
    public LayerMask wallMask;
    IEnumerator wallchecksmall2;
    float walljumpheight = 1.5f;
    public GameObject capsule;
    public bool isNotWalled;
    public LayerMask notWallMask;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(wallCheck.transform.position, wallDistance);   
        Gizmos.DrawWireSphere(wallcheckR.position, wallDistance);
    }
    void Update()
    {
        isWalled = Physics.CheckSphere(wallCheck.transform.position, wallDistance, wallMask)&& Input.GetKey(KeyCode.LeftShift);
        isWalledR = Physics.CheckSphere(wallcheckR.position, wallDistance, wallMask)&& Input.GetKey(KeyCode.LeftShift);
        isNotWalled = Physics.CheckSphere(capsule.transform.position, 1f, notWallMask);
        playermovement script = Player.GetComponent<playermovement>();
        if(!isWalled && !isWalledR)
        {
            unwallrun();
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(!script.isGrounded)
            {
                if(isWalled) 
                {
                    wallrun();
                    if(Input.GetButton("Jump"))
                    {
                        wallchecksmall2 = wallchecksmall();
                        if(Input.GetKey("a"))
                        {
                            StartCoroutine(wallchecksmall2);
                            script.velocity.y = Mathf.Sqrt(walljumpheight * -2f * script.gravity);
                        }
                        if(Input.GetKey("d"))
                        {
                            StartCoroutine(wallchecksmall2);
                            script.velocity.y = Mathf.Sqrt(walljumpheight * -2f * script.gravity);
                        }
                    }
                }
                else
                {
                    unwallrun();
                }
                if(isWalledR) 
                {
                    wallrun();
                    if(Input.GetButton("Jump"))
                    {
                        wallchecksmall2 = wallchecksmall();
                        if(Input.GetKey("d"))
                        {
                            StartCoroutine(wallchecksmall2);
                            script.velocity.y = Mathf.Sqrt(walljumpheight * -2f * script.gravity);
                        }
                        if(Input.GetKey("a"))
                        {
                            StartCoroutine(wallchecksmall2);
                            script.velocity.y = Mathf.Sqrt(walljumpheight * -2f * script.gravity);
                        }
                    }
                }
                else
                {
                    unwallrun();
                }
            }
            
        }
        else
        {
            unwallrun();
        }

        if(script.isGrounded)
        {
            unwallrun();
        }
    }

    void OnCollisionEnter (Collision collider) 
    {
        GameObject other = collider.gameObject;  
    }
    void wallrun()
    {
        playermovement script = Player.GetComponent<playermovement>();
        script.gravity = -30f;
        script.velocity.y = 0f;
        script.speed = 16f;
    }
    void unwallrun()
    {
        playermovement script = Player.GetComponent<playermovement>();
        script.gravity = -15f;
        script.speed = 12f;
    }
    IEnumerator wallchecksmall()
    {
        isWalled = false;
        wallDistance = 0.001f;
        yield return new WaitForSeconds(1f); 
        wallDistance = 2f;
    }

    
}
