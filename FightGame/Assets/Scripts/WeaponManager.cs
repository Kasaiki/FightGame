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

    /// <summary>
    /// 乱数で攻撃力にランダム性を持たせる。
    /// </summary>
    /// <param name="percentage"></param>
    /// <returns></returns>
    public float GetWeaponRandomATK(float percentage = 0.3f) {
        return Random.Range((1-percentage) * wdata.ATK,( 1+percentage) * wdata.ATK);
    }

    public void EQEnable() {
        wdata.wState = WeaponData.weaponSTATE.ACTIVE;
        ATKID++;
    }

    public void EQDisable() {
        wdata.wState = WeaponData.weaponSTATE.IDLE;
    }
}
