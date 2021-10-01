using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedweapon = 0;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       SelectWeapon(); 
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedweapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Unlocker unlocker = player.GetComponent<Unlocker>();
        int previousSelectedweapon = selectedweapon;
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedweapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            if(unlocker.SniperUnlocked)
            {
                selectedweapon = 1;                
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            if(unlocker.GrenadeUnlocked)
            {
                selectedweapon = 2;                
            }
        }
        if(previousSelectedweapon != selectedweapon)
        {
            SelectWeapon();
        }
    }
}

