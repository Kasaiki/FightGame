using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public enum weaponSTATE
    {
        IDLE,
        ACTIVE
    }
    public weaponSTATE wState;
    public float ATK = 10;
    public InteractionManager selfim;

    private void Start() {
        selfim = this.GetComponentInParent<InteractionManager>( );
    }

    private void OnTriggerEnter(Collider col) {
        //print( this.name + " is hitting " + col.name );
        if(wState == weaponSTATE.ACTIVE) {
            InteractionManager targetim = col.GetComponent<InteractionManager>( );
            if (targetim != null) {
                targetim.DoDamage( selfim );
            }
            print( targetim );
        }
    }
}
