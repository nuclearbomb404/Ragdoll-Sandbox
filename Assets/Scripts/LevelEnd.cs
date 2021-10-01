using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public LayerMask EndMask;
    public GameObject player;
    public bool OnWinPlatform;
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        if(player.transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        playermovement Playermovement = player.GetComponent<playermovement>();
        OnWinPlatform = Physics.CheckSphere(Playermovement.groundCheck.position, 2f, EndMask);
    }
    void OnTriggerEnter()
    {
        if(OnWinPlatform)
        {
            EndLevel();
        }
    }
    void EndLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
