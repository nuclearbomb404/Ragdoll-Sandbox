using UnityEngine;
using System.Collections; 

public class playermovement : MonoBehaviour
{   
    void Start()
    {
        Physics.IgnoreLayerCollision(11,18);
        Physics.IgnoreLayerCollision(18,11);
        Time.timeScale = 1.5f;
    }
    public GameObject player;
    public float jumpheight = 3f;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    public float gravity = -15f;
    public Vector3 velocity;
    public CharacterController controller;
    public float speed = 12f;
    private Vector3 scaleChange, positionChange;
    public bool JumpPeriod;
    public LayerMask groundMask2;
    public bool isCeilinged;
    public GameObject CeilingCheck;
    public LayerMask CeilingMask; 
    public float CeilingDistance = 0.001f;
    public float acceleration = 0f;
    public bool isPressed = false;
    public GameObject character;
    Vector3 direction;
    IEnumerator coroutine;
    IEnumerator coroutine2;
    float nextfiretime = 2f;
    float cooldownTime = 2f;
    public Animator anim;
    public bool isPressed2 = false;

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isCeilinged = Physics.CheckSphere(CeilingCheck.transform.position, CeilingDistance, CeilingMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            if(!isPressed)
            {
                velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
            }
        }
        if(!isPressed)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
        Vector3 x2 = player.transform.forward;
        
        if(Input.GetKeyDown(KeyCode.LeftControl)&& isGrounded)
        {
            Vector3 direction = Vector3.forward; 
            RaycastHit hit;
            if(!Physics.Raycast(character.transform.position, character.transform.forward, out hit, 2f))
            {
                if(hit.transform != null && hit.transform.GetComponent<Collider>().isTrigger)
                {     
                    if(isPressed)
                    {
                        if(Time.time > nextfiretime)
                        {     
                            anim.Play("Base Layer.Slide");               
                            nextfiretime = cooldownTime + Time.time;                    
                            mouselook Mouselook = Camera.main.GetComponent<mouselook>();
                            Mouselook.enabled = false;
                            transform.Translate(direction * acceleration * Time.deltaTime);
                            if(isPressed && acceleration <= 30f)
                            {
                                acceleration = acceleration + 30f;
                            }                                         
                        }
                    }
                }                    
                             
                coroutine = decelerate();
                StartCoroutine(coroutine);
                coroutine2 = JumpSlideTime();
                StartCoroutine(coroutine2);
                if(isPressed)
                {
                    if(Time.time > nextfiretime)
                    {     
                        anim.Play("Base Layer.Slide");               
                        nextfiretime = cooldownTime + Time.time;                    
                        mouselook Mouselook = Camera.main.GetComponent<mouselook>();
                        Mouselook.enabled = false;
                        transform.Translate(direction * acceleration * Time.deltaTime);
                        if(isPressed && acceleration <= 30f)
                        {
                            acceleration = acceleration + 30f;
                        }                 
                    }
                }

            }
        }
        if(!isPressed)
        {
            mouselook Mouselook = Camera.main.GetComponent<mouselook>();
            Mouselook.enabled = true; 
            Vector3 direction = Vector3.forward;                      
            transform.Translate(direction * acceleration * Time.deltaTime);
            isPressed = false;
            if(acceleration >= 0f)
            {
                acceleration = acceleration - 0.5f;
            }
            if(acceleration == -0.5f)
            {
                acceleration = acceleration + 0.5f;
            }
        }
        IEnumerator decelerate()
        {      
            isPressed = true; 
            yield return new WaitForSeconds(0.0001f); 
            isPressed = false;            
        }
        IEnumerator JumpSlideTime()
        {      
            isPressed2 = false; 
            yield return new WaitForSeconds(0.5f); 
            isPressed2 = true;            
        }
    }
}
