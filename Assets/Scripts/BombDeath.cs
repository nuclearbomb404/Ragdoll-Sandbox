using UnityEngine;
using UnityEngine.UI;

public class BombDeath : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    Vector3 pos;
    public float Health = 3f;
    public Text score;
    public float scorefloat = 0f;
    public GameObject Spawner;
    public GameObject explosion;
    float DestroyTime = 1f;
    public LayerMask PlayerMask;
    public GameObject player;

 //TakeDamage//      
    public void TakeDamage(float ammount)
    {
        Health -= ammount;
        if (Health <= 0f)
        {
            Die();
        }


    }
 //EnemyDie//
    public void Die()
    {
        Health = 2f;
        Destroy(gameObject);
        GameObject Explosion = Instantiate(explosion, transform.position, transform.rotation); 
        Destroy(Explosion,DestroyTime);
        var hitCollider = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f,PlayerMask);
        foreach(var PlayerInside in  hitCollider)
        {
            if(PlayerInside.tag == "Player")
            {
                player.GetComponent<PlayerDeath>().playerdeath();
            }
        }
    }
    
}
