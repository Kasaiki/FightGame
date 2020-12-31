using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public ActorController ac;
    public ActorDataManager adm;
    public WeaponManager wm;

    [Header( "==== EFXs ====" )]
    public GameObject blockEFX;

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

    /// <summary>
    /// 武器の当たり判定が発生時の処理。
    /// ATKIDとlastATKIDの比較により、１回の攻撃にあたって１回のみのダメージ判定を保証する。
    /// </summary>
    /// <param name="attacker">攻撃者の攻撃力と武器の攻撃力が記載しているクラス</param>
    public void DoDamage(InteractionManager attacker) {
        //print( "attacker ATK :" + attacker.ac.actorData.ATK );
        //print( "attacker:" + attacker.name + " hit:" + this.name );
        //print( "my HP :" + this.ac.actorData.HP );

        if(attacker.wm.ATKID != lastATKID) {
            // ActorDataManagerとWeaponManagerから、それぞれキャラと武器の攻撃力を読み取って、DMGを計算する
            float damage = Mathf.Max( attacker.adm.GetRandomATK(0.3f) + attacker.wm.GetWeaponRandomATK(0.3f) - this.adm.GetDEF( ), 1 );
            float blockChance = Random.Range( 0.0f, 1.0f );
            if(blockChance < 0.5f) {    // blockChanceというランダム変数により、ガード判定を行う。
                print( "Damage" + damage );
                adm.AddHP( damage );
                ac.anim.SetTrigger( "hit" );
            } else {
                ac.anim.SetTrigger( "block" );
                Instantiate( blockEFX, transform.position + transform.up * 1.2f + transform.forward * 0.4f, transform.rotation );
            }

            CheckHP( );
            //print( attacker.wm.ATKID );
            lastATKID = attacker.wm.ATKID;
        }
    }

    // HPが０になったら、ゲームオーバー処理を行う。
    public void CheckHP() {
        if (this.ac.aData.HP <= 0) {
            this.ac.anim.SetTrigger( "dead" );
        }
    }
}
