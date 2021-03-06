using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public GameObject[] weaponObjects = new GameObject[2];

    PlayerStatus status;

    Weapon[] weapons;
    int currentWeapon = 0;
    float changeDelay = 0;

    void Start()
    {
        status = gameObject.GetComponent<PlayerStatus>();

        // Get weapon props
        weapons = new Weapon[weaponObjects.Length];
        for (int i = 0; i < weapons.Length; ++i)
        {
            weapons[i] = weaponObjects[i].GetComponent<Weapon>();
        }
    }

    public void Reset()
    {
        for (int i = 0; i < weapons.Length; ++i)
        {
            weapons[i] = weaponObjects[i].GetComponent<Weapon>();
        }
    }

    void FixedUpdate()
    {
        if (changeDelay > Global.EPS)
        {
            changeDelay -= Time.deltaTime;    
        }
    }

    public void ChangeWeapon()
    {
        if (changeDelay > Global.EPS) return;
        currentWeapon = (currentWeapon + 1) % weapons.Length;
        changeDelay = 0.5f;
    }

    public int GetCurrentWeaponType()
    {
        return currentWeapon;
    }

    public void SetCurrentWeaponType(int type)
    {
        currentWeapon = type;
    }

    public Weapon GetWeapon(int type)
    {
        return weapons[type];    
    }

    public bool ProcessAction(int code)
    {
        return weapons[currentWeapon].ProcessAction(code);
    }
}
