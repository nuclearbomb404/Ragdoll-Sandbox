using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_2_collision : MonoBehaviour
{
    void OnCollisionEnter(Collision collider)
    {
        GameObject other = collider.gameObject;
        if(other.tag != "Alive")
        {
            Destroy(gameObject);
        }
        if(other.GetComponent<Death>() != null)
        {
            Destroy(gameObject);            
            other.GetComponent<Death>().TakeDamage(100f);
        }
    }
}
