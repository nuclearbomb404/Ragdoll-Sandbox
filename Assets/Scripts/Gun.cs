using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gun : MonoBehaviour
{
    public GameObject Spawnplace;
    public float damage = 10f;
    public float range = 100f;
    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject line;
    public GameObject gun;
    public float ammo = 10f;
    public Text ammotext;
    public bool buttonIsDown;
    public Animator anim;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
          shoot();
        }
        ammotext.text = ("AMMO: " + ammo.ToString());
    }
    
      void shoot()
      {   
        if(ammo > 0) 
        {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);   
        RaycastHit hit;
        ammo -= 1;
        anim.Play("Base Layer.Recoil");   
        line.GetComponent<LineRenderer>().enabled = true;
        line.transform.rotation = Spawnplace.transform.rotation;
        Invoke("Trail", 0.1f);

        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
          line.GetComponent<LineRenderer>().enabled = true;
          line.transform.rotation = Spawnplace.transform.rotation;
          Invoke("Trail", 0.1f);
            
          Death death = hit.transform.GetComponent<Death>();
          if (death != null)
          {
            death.TakeDamage(10f);
          }
        }
      }   
      }

        void Trail()
        {
          line.GetComponent<LineRenderer>().enabled = false;
        }


  IEnumerator shootdelay()
  {
    yield return new WaitForSecondsRealtime(1);
    shoot();
    yield return new WaitForSecondsRealtime(1);
  }
}   
