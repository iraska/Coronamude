using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        SetWeaponActive();
    }

void Update() 
{
    int previousWeapon = currentWeapon;

    ProcessKeyInput();
    ProcessScrollWhell();

    if (previousWeapon != currentWeapon)
    {
        SetWeaponActive();
    }
}

    
    void ProcessScrollWhell()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) //if we going up (scrool)
        {
            if (currentWeapon >= transform.childCount - 1) //we have 3 child/weapon but index 0, 1 and 2
            {
                currentWeapon = 0;  //if current weapon index is 2, then it will be 0 cause there is no 3
            }
            else
            {
                currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) //if we going down (scrool)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1; //if it s 0 then will be 2
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0; //first index
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }
}
