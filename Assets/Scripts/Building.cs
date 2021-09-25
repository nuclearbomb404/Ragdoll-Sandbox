using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public Vector3 touchpos;
    public GameObject Cube;  
    public float BlocksLeft = 2f;
    public int selectedBlock = 0;
    public GameObject Explosive;
    public GameObject Canvas;
    public GameObject ScoreScript;
    public Rigidbody Spine;
    public IEnumerator KillDelay;
    public float ExplosivesLeft = 5f;
    public float CubesLeft = 5f;
    
    void Update()
    {  
        //Checks the velocity on the main bone of the ragdoll
        if(Spine.velocity.y < 0.5f && Spine.velocity.y > -0f && Canvas.GetComponent<Ui>().Started > 1 )
        {
            StartCoroutine(KillDelay());  
        }
        if(Spine.velocity.y !< 0.5f && Spine.velocity.y !> -0.5f && Canvas.GetComponent<Ui>().Started > 1 )
        {
            StopCoroutine(KillDelay());
        }
        //Checks if the game is paused
        if(!Canvas.GetComponent<Ui>().Paused)
        {
            //Check if the game is in the building phase
            if(Canvas.GetComponent<Ui>().Started > 0 && Canvas.GetComponent<Ui>().Started < 2)
            {
                //Checks the touch inputs
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit, 1000f))
                    {
                        if(hit.collider != null)
                        {
                            Vector3 touchpos = new Vector3(hit.point.x,hit.point.y, 0f);                   
                            Color newcolor = new Color(Random.Range(0,1),Random.Range(0,1),Random.Range(0,1) , 1f);
                            //Checks if the object that was hit is the background by looking at the object's name  
                            if(hit.collider.name == "Background")
                            {
                                //Checks which block is active(1/2)
                                if(gameObject.name == "Cube")
                                {
                                    if(CubesLeft > 0)
                                    {
                                        GameObject InstantCube = Instantiate(Cube, touchpos, Camera.main.transform.rotation);
                                        InstantCube.transform.LookAt(Camera.main.transform.position);
                                        CubesLeft--;
                                    }

                                }
                                //Checks which block is active(2/2)
                                if(gameObject.name == "Explosive")
                                {
                                    if(ExplosivesLeft > 0)
                                    {
                                        GameObject InstantBomb = Instantiate(Explosive, touchpos, Camera.main.transform.rotation);
                                        InstantBomb.transform.LookAt(Camera.main.transform.position);
                                        ExplosivesLeft--;
                                    }

                                }
                                    
                            }
                        }
                    }
                }
            }
        }

        //7 Second timer that starts when the velocity.y is under 0.5f or over -0.5f 
        IEnumerator KillDelay()
        {
            yield return new WaitForSeconds(3);
            if(Spine.velocity.y < 0.5f && Spine.velocity.y > -0.25f && Canvas.GetComponent<Ui>().Started > 1 )
            {
                SaveScoreData.SaveCurrentScore();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

