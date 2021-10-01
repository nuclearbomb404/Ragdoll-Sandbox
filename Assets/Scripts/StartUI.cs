using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene ("Level01");
    }
    public void EndGame()
    {
        SceneManager.LoadScene ("Level01");        
    }
}
