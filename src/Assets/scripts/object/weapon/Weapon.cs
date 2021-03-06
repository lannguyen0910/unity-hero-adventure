using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Dictionary<int, WeaponAction> weaponActionDict;

    private void Awake()
    {
        weaponActionDict = new Dictionary<int, WeaponAction>();
    }

    public void AddAction(int code, WeaponAction action)
    {
        weaponActionDict.Add(code, action);
    }

    public void RemoveAction(int code)
    {
        if (weaponActionDict.ContainsKey(code))
        {
            weaponActionDict[code].RemoveSelf();
            weaponActionDict.Remove(code);
        }
    }

    public bool ProcessAction(int code)
    {
        if (weaponActionDict.ContainsKey(code))
        {
            weaponActionDict[code].Process();
            return true;
        }
        return false;
    }
}
