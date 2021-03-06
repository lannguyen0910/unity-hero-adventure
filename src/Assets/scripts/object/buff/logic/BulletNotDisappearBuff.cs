using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNotDisappearBuff : Buff
{
    public BulletNotDisappearBuff() : base(Global.BULLET_THROUGH_BUFF_CODE)
    {
        description = "MAGIC GOES THROUGH WALL";
    }

    public override void Process(GameObject target)
    {
        GameObject bullet = target.GetComponent<WeaponHolder>().GetWeapon(Global.MAGIC_WEAPON).gameObject.GetComponent<WeaponMagicFireAction>().bulletPrototype;

        bullet.AddComponent<BulletNotDisappearDealer>();
    }
}

