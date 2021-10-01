using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    public GameObject player;
    public bool OnLava;
    public LayerMask LavaMask;
    
    void Update()
    {
        playermovement Playermovement = player.GetComponent<playermovement>();
        OnLava = Physics.CheckSphere(Playermovement.groundCheck.position, 1f, LavaMask);
        if (OnLava)
        {
            PlayerDeath();
        }
    }


    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
