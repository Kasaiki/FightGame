using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorData : MonoBehaviour
{
    [Header( "==== Maximum Data ====" )]
    [Range( 0, 200.0f )]
    public float HPMAX = 100.0f;

    [Header("==== Current Data ====")]
    public float HP = 100.0f;
    public float ATK = 10;
    public float DEF = 5;

    public Image uiBar;

    private void Start() {
        BarUpdate( );
    }

    /// <summary>
    /// 攻撃された時の、削るHPの計算を行う
    /// </summary>
    /// <param name="value">攻撃値</param>
    public void AddHP(float value) {
        //print( "AddHP method is called" );
        HP = Mathf.Clamp( HP - value, 0, HPMAX );
        BarUpdate( );
    }

    // HPBarの更新を行う
    private void BarUpdate() {
        uiBar.fillAmount = HP / HPMAX;
    }
}
