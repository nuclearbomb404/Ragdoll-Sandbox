using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class Building : MonoBehaviour
{
    public Vector3 touchpos;
    public GameObject Cube;  
    public GameObject Platform; 
    public float BlocksLeft = 2f;
    public int selectedBlock = 0;
    public GameObject Explosive;
    public GameObject Canvas;
    public GameObject ScoreScript,reuf;
    public Rigidbody Spine;
    public IEnumerator KillDelay;
    public IEnumerator BounceDelay;
    public GameObject SwitchButton;
    public float ExplosivesLeft = 5f;
    public float CubesLeft = 5f;
    public GameObject InstantPlatform;
    public Rigidbody rb;
    public bool bounced = false;
    
    public void RotateButton()
    {
            InstantPlatform.transform.Rotate(2,0,0);
    }
    void Update()
    {  
        Camera.main.transform.position = new Vector3(reuf.transform.position.x,Camera.main.transform.position.y,Camera.main.transform.position.z);
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
                                    GameObject InstantCube = Instantiate(Cube, touchpos, Camera.main.transform.rotation);
                                    InstantCube.transform.LookAt(Camera.main.transform.position);
                                    CubesLeft--;

                                }
                                //Checks which block is active(2/2)
                                if(gameObject.name == "Explosive")
                                {

                                    GameObject InstantBomb = Instantiate(Explosive, touchpos, Camera.main.transform.rotation);
                                    InstantBomb.transform.LookAt(Camera.main.transform.position);
                                    ExplosivesLeft--;

                                }
                                if(gameObject.name == "Platform")
                                {
                                    InstantPlatform = Instantiate(Platform, touchpos, Camera.main.transform.rotation);
                                    InstantPlatform.transform.LookAt(Camera.main.transform.position);
                                    ExplosivesLeft--;
                                }
                                    
                            }
                        }
                    }
                }
            }
            if(Canvas.GetComponent<Ui>().Started == 2 && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)  
            {
                if(!bounced)
                {
                    rb.AddForce(0,Spine.velocity.y + 25000,0);
                    StartCoroutine(BounceDelay());
                }
                else
                {
                    Debug.Log("bruh");
                }
            }      
        }
        //1 Second timer that starts when the velocity.y is under 0.5f or over -0.5f 
        IEnumerator KillDelay()
        {
            yield return new WaitForSeconds(1);
            if(Spine.velocity.y < 0.5f && Spine.velocity.y > -0.25f && Canvas.GetComponent<Ui>().Started > 1 )
            {
                SaveScoreData.SaveCurrentScore();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Advertisement.Show("Interstitial_Android");
            }
        }
        IEnumerator BounceDelay()
        {
            bounced = true;
            yield return new WaitForSeconds(3);
            bounced =false;
        }
    }
}

