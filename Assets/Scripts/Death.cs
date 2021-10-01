using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    Vector3 pos;
    public float Health = 50f;
    public Text score;
    public float scorefloat = 0f;
    public GameObject Spawner;

 //TakeDamage      
    public void TakeDamage (float ammount)
    {
        Health -= ammount;
        if (Health <= 0f)
        {
            Die();
        }


    }
 //EnemyDie
    public void Die()
    {
        Health = 50f;
        Destroy(gameObject); 
    }
    
}
