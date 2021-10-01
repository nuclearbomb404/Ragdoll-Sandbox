using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement2d : MonoBehaviour
{
    float PlayerSpeed2d = 7.5f;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded2d = false;
    public GameObject arm;
    public GameObject LinePivot;
    public GameObject line;
    public GameObject armSprite;
    Vector3 CameraOffset;
    float OffsetZ;
    public LayerMask IgnorePlayer;
    public GameObject Explosion;



    void Start()
    {
        OffsetZ = Camera.main.transform.position.z -5f;
    }
    void Update()
    {
       //Kill the player if position(Y) is under -5//
        if(transform.position.y < -5)
        {
            GetComponent<PlayerDeath>().playerdeath();
        }
       //Make the camera follow the player//
        CameraOffset = new Vector3(transform.position.x, transform.position.y, OffsetZ);
        Camera.main.transform.position = CameraOffset;
       //Detect mouse input//
        if(Input.GetButtonDown("Fire1"))
        {
            shoot2d();
        }
      //Rotate the gun and the arm to face the cursor//
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(LinePivot.transform.position);
        var angle = Mathf.Atan2(dir.y,dir.x) *Mathf.Rad2Deg;
        LinePivot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        arm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       //Check if the player is grounded ( (FIXED)Broke when rotated 180 degrees )//
        isGrounded2d = Physics2D.CircleCast(groundCheck.position, 0.01f, groundCheck.up ,groundMask);
        SpriteRenderer astronautSprite = gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer ArmSprite = armSprite.GetComponent<SpriteRenderer>();
      //Actual movement//
        if(Input.GetKey("d"))
        {
            transform.Translate(transform.right * PlayerSpeed2d * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if(Input.GetKey("a"))
        {
            transform.Translate(-transform.right * PlayerSpeed2d * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        //Jump//
        if(isGrounded2d)
        {
            if(Input.GetKeyDown("w"))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 12.5f, ForceMode2D.Impulse); 
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, 0.01f);   
    }
    //Shooting (Add ammo dumbass)//
    void shoot2d()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(LinePivot.transform.position);
        var angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        line.GetComponent<LineRenderer>().enabled = true;
        Invoke("LineDisable", 0.1f);
        RaycastHit2D hit = (Physics2D.Raycast(LinePivot.transform.position,Input.mousePosition - Camera.main.WorldToScreenPoint(LinePivot.transform.position) , 100f, IgnorePlayer));
        if(hit.collider != null)
        {
            Death death = hit.collider.gameObject.GetComponent<Death>();
            BombDeath bombdeath = hit.collider.gameObject.GetComponent<BombDeath>();
            if(death != null)
            {
                death.TakeDamage(5f);
            }
            if(bombdeath != null)
            {
                bombdeath.TakeDamage(1f);
            }
        }
    }
    void LineDisable()
    {
        line.GetComponent<LineRenderer>().enabled = false;
    }
    
}
