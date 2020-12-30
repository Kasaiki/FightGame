using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public ActorController ac;
    public ActorDataManager adm;
    public WeaponManager wm;

    private int lastATKID = 0;

    // Start is called before the first frame update
    void Awake()
    {
        ac = GetComponent<ActorController>( );
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown( KeyCode.A )) {
        //    print( "currentHP :" + ac.actorData.HP );
        //    print( "MAXHP :" + ac.actorData.HPMAX );
        //    ac.actorData.AddHP(10 );
        //}
    }

    public void DoDamage(InteractionManager attacker) {
        //print( "attacker ATK :" + attacker.ac.actorData.ATK );
        //print( "attacker:" + attacker.name + " hit:" + this.name );
        //print( "my HP :" + this.ac.actorData.HP );

        //ac.actorData.HP = ac.actorData.HP - attacker.ac.actorData.ATK;

        if(attacker.wm.ATKID != lastATKID) {
            adm.AddHP( Mathf.Max( attacker.adm.GetATK( ) + attacker.wm.GetWeaponATK( ) - this.adm.GetDEF( ), 1 ) );
            ac.anim.SetTrigger( "hit" );
            CheckHP( );
            print( attacker.wm.ATKID );
            lastATKID = attacker.wm.ATKID;
        }
    }

    public void CheckHP() {
        if (this.ac.aData.HP <= 0) {
            this.ac.anim.SetTrigger( "dead" );
        }
    }
}
