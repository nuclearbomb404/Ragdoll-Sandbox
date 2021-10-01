using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunDestroy : MonoBehaviour
{
    public GameObject enemy;
    void OnCollisionEnter(Collision collider)
    {
        GameObject other = collider.gameObject;
        if(other.tag != "Player")
        {
            Destroy(gameObject);
        }
        if(other.tag == "Player")
        {
            Destroy(gameObject);            
            enemy.GetComponent<EnemyController>().PlayerDeath();
        }
    }
}
