using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
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
    public bool playerinsight = false, playerinattackrange;
    public GameObject bullet;
    public Transform spawnplace;
    GameObject ActiveBullet;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            if (other.tag == "Player")
            {
                playerinsight = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //randomshot
        float randomshotX = Random.Range(player.transform.position.x - 2, player.transform.position.x + 2);
        float randomshotY = player.transform.position.y;
        float randomshotZ = Random.Range(player.transform.position.z - 1, player.transform.position.z + 1);
        playert = new Vector3(randomshotX,randomshotY,randomshotZ);
        //randomshot end
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, PlayerMask);
        if (!playerinattackrange && !playerinsight)
        {
            Patroling();
        }
        if (playerinsight && !playerinattackrange)
        {
            ChasePlayer();
        }
        if(gameObject.GetComponent<Death>().Health < 50)
        {
            ChasePlayer();
        }
        if (playerinsight && playerinattackrange)
        {
            AttackPlayer();
        }
    }


    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Patroling()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            walkPointSet = false;
            searchwalkpoint();
        }
        if (!walkPointSet)
        {
            searchwalkpoint();
        }
        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distancetowalkpoint = transform.position - walkPoint;
        if(distancetowalkpoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }
    void searchwalkpoint()
    {
        RaycastHit hit;
        float randomZ = Random.Range(-walkpointrange,walkpointrange);
        float randomX = Random.Range(-walkpointrange,walkpointrange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + 0.5f, transform.position.z + randomZ);
        walkPointSet = true;
    }
    void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
    void AttackPlayer()
    {  
        agent.SetDestination(transform.position); 
        if(!attacked)
        {       
            transform.LookAt(playert);
            GameObject ActiveBullet = Instantiate(bullet,spawnplace.position, spawnplace.rotation);
            ActiveBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 150000 * Time.deltaTime);
            attacked = true;
            Invoke(nameof(ResetAttack), attackcooldown);
        }
    }
    void ResetAttack()
    {
        attacked = false;
    }
    void EnemyTrail()
    {
        Line.GetComponent<LineRenderer>().enabled = false;
    }
    

}
