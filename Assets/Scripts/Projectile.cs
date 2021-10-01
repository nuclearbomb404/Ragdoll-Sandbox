using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{      
    public GameObject Player;
    public Rigidbody rb;
    public GameObject alive;
    public GameObject projectile;
    public GameObject Joe;
    public GameObject spawnplace;
    public float cooldownTime = 1;
    public float nextfiretime = 0;
    public float grenades = 20f;
    public Text grenadeUI;
    public Animator anim;    
    
    void Start()
    {
        playermovement Playermovement = Player.GetComponent<playermovement>();
        CharacterController controller = Playermovement.controller;
        Physics.IgnoreCollision(Player.GetComponent<Collider>(), controller);
        Physics.IgnoreLayerCollision(11,13);
        Physics.IgnoreLayerCollision(13,11);
    }
    
    // Update is called once per frame
    void Update()
    {      
        grenadeUI.text = ("GRENADES: " + grenades.ToString());
            
        if(grenades > 0)
        {

            if(Time.time > nextfiretime)
            {
              if(Input.GetButtonDown("Fire1"))
                {
                    anim.Play("Base Layer.Recoil");
                    grenades -= 1f;
                    GameObject Joe = Instantiate(projectile, spawnplace.transform.position, Camera.main.transform.rotation );
                    Joe.GetComponent<Rigidbody>().AddForce((Camera.main.transform.forward * 150000 * Time.deltaTime));
                    Joe.tag = "Bullet";
                    nextfiretime = cooldownTime + Time.time;
                    Joe.transform.rotation = projectile.transform.rotation;
                }
            }
        }    
    }    
}  


