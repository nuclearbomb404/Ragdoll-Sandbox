using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_2 : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float ammoGun2 = 11f;
    Vector3 playerOffset;
    public GameObject spawnplace;
    public float ShotDelay = 0.5f;
    private float nextFire = 0.0F;
    public Canvas canvas;
    public Text Ammotext;
    public Animator anim;
    public GameObject SniperModel;

    // Update is called once per frame
    void Update()
    {
        Ammotext.text =("AMMO: "+ ammoGun2);
        Image scope = canvas.GetComponent<Image>();
        mouselook Mouselook = Camera.main.GetComponent<mouselook>();
        if(Input.GetButton("Fire2"))
        {
            SniperModel.GetComponent<MeshRenderer>().enabled = false;
            scope.enabled = true;
            Mouselook.mousesensitivity = 75f;
            Camera.main.fieldOfView = 10f;
        }
        else
        {
            SniperModel.GetComponent<MeshRenderer>().enabled = true;            
            scope.enabled = false;
            Mouselook.mousesensitivity = 150f;
            Camera.main.fieldOfView = 75f;
        }
        float playerOffsetX = player.transform.position.x + 1f;
        float playerOffsetY = player.transform.position.y;
        float playerOffsetZ = player.transform.position.z;
        playerOffset = new Vector3(playerOffsetX,playerOffsetY,playerOffsetZ);
        nextFire = ShotDelay + Time.time;
        if(Input.GetButtonDown("Fire1") && ammoGun2 > 0f)
        {
            anim.Play("Base Layer.Recoil");
            GameObject Activebullet = Instantiate(bullet, spawnplace.transform.position, Camera.main.transform.rotation);
            Rigidbody rb = Activebullet.GetComponent<Rigidbody>();
            rb.AddForce((Camera.main.transform.forward * 750000 * Time.deltaTime));
            ammoGun2--;
        }
    }

}
