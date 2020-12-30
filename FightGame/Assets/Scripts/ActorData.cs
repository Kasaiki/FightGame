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

    public void AddHP(float value) {
        //print( "AddHP method is called" );
        HP = ValueRegulate( HP - value, 0, HPMAX );
        BarUpdate( );
    }

    // regulate the value , make sure it is between [0,MAX]
    private float ValueRegulate(float value, float min, float max) {
        return Mathf.Clamp( value, min, max );
    }

    private void BarUpdate() {
        uiBar.fillAmount = HP / HPMAX;
    }
}
