using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBlock : MonoBehaviour
{
    public LayerMask CharMask;
    public Rigidbody rb;
    public GameObject Spine;
    public GameObject CharacterRig;
    public GameObject explosion;
    void OnCollisionEnter (Collision collider) 
	{   
        GameObject other = collider.gameObject;
        if(other.tag == "Player")
        {
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 10f, CharMask);
            foreach (Collider hitCollider in hitColliders)
            {
                GameObject Inside = hitCollider.transform.gameObject;
                Destroy(gameObject);
                rb.AddExplosionForce(750,transform.position,10);
                if(Inside.GetComponent<Rigidbody>() != null && Inside != Spine)
                {
                    Inside.GetComponent<Rigidbody>().AddExplosionForce(750,transform.position,10f);
                    GameObject Explosion = Instantiate(explosion, transform.position, transform.rotation);
                }
            }
        }
    }
}
