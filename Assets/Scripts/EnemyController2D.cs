using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController2D : MonoBehaviour
{
    public GameObject player;
    public Vector3 playert;
    public GameObject Line;
    public LayerMask PlayerMask, GroundMask; 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkpointrange;
    public float attackcooldown;
    bool attacked;
    public float sightrange, attackrange;
    public bool playerinsight = false, playerinattackrange = false;
    public GameObject bullet;
    public Transform spawnplace;
    GameObject ActiveBullet;
    public GameObject PlayerInsideExplosion;
    Vector2 playerposX;
    float EnemyPosY;
    public float DeathTime;
    public IEnumerator coroutine;


    void Start()
    {
        EnemyPosY = transform.position.y;

    }
    // Update is called once per frame
    void Update()
    {
        var hitCollider = Physics2D.OverlapCircleAll(gameObject.transform.position, attackrange,PlayerMask);
        foreach(var PlayerInside in  hitCollider)
        {
            playerposX = new Vector2(player.transform.position.x, EnemyPosY);
            playerinattackrange = true;
            transform.position = Vector2.MoveTowards(transform.position,playerposX, 0.1f);
            coroutine = DeathTimer();
            StartCoroutine(coroutine);
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        GameObject other = collider.gameObject;
        if(other.tag == "Player")
        {
            GetComponent<BombDeath>().Die();
        }
    }
    void ResetAttack()
    {
        attacked = false;
    }    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackrange);  
    }
    public IEnumerator DeathTimer()
    {
        yield return new WaitForSecondsRealtime(DeathTime);
        GetComponent<BombDeath>().Die();
    }
}
