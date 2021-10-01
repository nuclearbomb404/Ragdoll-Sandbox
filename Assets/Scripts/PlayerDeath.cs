using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public IEnumerator coroutine;
    public GameObject Line;

    public void playerdeath()
    {
        coroutine = DeathDelay();
        StartCoroutine(coroutine);
    }
    public IEnumerator DeathDelay()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<playermovement2d>().enabled = false;
        Line.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
