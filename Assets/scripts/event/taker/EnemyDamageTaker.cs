using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTaker : EventTaker
{
    EnemyStatus status;

    protected void Start()
    {
        eventCode = Global.DAMAGE_CODE;
        base.Start();

        status = gameObject.GetComponent<EnemyStatus>();
    }

    public override void process(GameObject source)
    {
        PlayerStatus playerStatus = source.GetComponent<PlayerStatus>();
        WeaponStatus weaponStatus = source.GetComponentInChildren<WeaponStatus>();

        float damage = weaponStatus.damage;
        status.health -= damage;
    }
}
