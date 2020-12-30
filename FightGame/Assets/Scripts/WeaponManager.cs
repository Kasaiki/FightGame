using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponData wdata;
    public int ATKID = 0;


    public float GetWeaponATK() {
        return wdata.ATK;
    }

    public void EQEnable() {
        wdata.wState = WeaponData.weaponSTATE.ACTIVE;
        ATKID++;
    }

    public void EQDisable() {
        wdata.wState = WeaponData.weaponSTATE.IDLE;
    }
}
