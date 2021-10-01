using UnityEngine;
using System.Collections;

public class ProjectileDestroy : MonoBehaviour
{   
    public GameObject Player;
    public GameObject explosion;  
    public GameObject fire;
    public float DestroyTime = 0.5f;
    public Transform aliveCheck;
    public float radius = 5f;
    public LayerMask aliveMask;
    public bool aliveinside;
    public LayerMask playerMask;
    public bool playerinside;
    public Rigidbody Rbp;
    public bool Decalissed;
    public bool playerinside2;
    public GameObject GrenadeLauncher;

    void Update()
    {
        playermovement Playermovement = Player.GetComponent<playermovement>();
        CharacterController controller = Playermovement.controller;
        aliveinside = Physics.CheckSphere(aliveCheck.position, radius, aliveMask);
        playerinside = Physics.CheckSphere(aliveCheck.position, radius, playerMask); 
    }
    void OnCollisionEnter (Collision collider) 
	{   
        GameObject other = collider.gameObject;
        ParticleSystem ps = fire.GetComponent<ParticleSystem>();
        playermovement movement = Player.GetComponent<playermovement>();
        Projectile projectileScript = GrenadeLauncher.GetComponent<Projectile>();
		if (other.tag != "Alive")
		{
            playermovement Playermovement = Player.GetComponent<playermovement>();
            GameObject Explosion = Instantiate(explosion, aliveCheck.position, aliveCheck.rotation);
            Destroy(gameObject); 
            Destroy(Explosion,DestroyTime);  
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
            foreach (Collider hitCollider in hitColliders)
            {
                GameObject Inside = hitCollider.gameObject;
                if(Inside.tag == "Alive")
                {
                    Death death2 = Inside.gameObject.GetComponent<Death>();
                    death2.TakeDamage(25f);
                    Rigidbody rb = Inside.GetComponent<Rigidbody>();
                }
                if(Inside.tag == "Player")
                {
                   Playermovement.velocity.y = Mathf.Sqrt(25f * -2f * -15f);
                }
            }
		}
        if (other.tag == "Alive")
        {
            GameObject Explosion = Instantiate(explosion, aliveCheck.position, aliveCheck.rotation);
            Destroy(gameObject); 
            Destroy(Explosion,DestroyTime);
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
            foreach (Collider hitCollider in hitColliders)
            {
                GameObject Enemy = hitCollider.gameObject;
                if(Enemy.tag == "Alive")
                {
                    Death death2 = Enemy.gameObject.GetComponent<Death>();
                    death2.TakeDamage(50f);
                }
            }    
        } 
    }  
}
