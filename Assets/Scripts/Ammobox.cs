using UnityEngine;

public class Ammobox : MonoBehaviour
{
    
    
    void OnTriggerEnter(Collider collider)
    {
        Projectile grenade = GameObject.Find("First Person Player").GetComponent<Projectile>();
        Gun gun = GameObject.Find("First Person Player").GetComponent<Gun>();
        if(gun.ammo != 10 )
        {
            gun.ammo = 10;
            Destroy(gameObject); 
        }
        if(grenade.grenades != 20)
        {
            grenade.grenades = 20;
            Destroy(gameObject);
        }
        else if(grenade.grenades != 20 && gun.ammo != 10)
        {
            gun.ammo = 10;
            grenade.grenades = 20;
            Destroy(gameObject);
        }
    }
}
