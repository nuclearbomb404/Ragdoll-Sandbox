using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public GameObject Player;
    public bool SniperUnlocked, GrenadeUnlocked;
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Player.transform.position, 2f);
    }
    void OnTriggerEnter(Collider other)
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 2);
        foreach(Collider hitCollider in hitColliders)
        {
            GameObject Inside = hitCollider.gameObject;
            if(Inside.GetComponent<Collider>().name == "Sniper_Unlock")
            {
                SniperUnlocked = true;
            }
            if(Inside.GetComponent<Collider>().name == "Grenade_Unlock")
            {
                GrenadeUnlocked = true;
            }
        }
    }
}
