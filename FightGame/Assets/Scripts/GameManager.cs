using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// ゲームは４つのステージからなる。
    /// IDLEはゲーム開始の直後
    /// PLAYERAとPLAYERBはそれぞれPlayerAとPlayerBが攻撃するターン
    /// FINISHEDはゲーム終了状態
    /// </summary>
    public enum STATE
    {
        IDLE,
        PLAYERA,
        PLAYERB,
        FINISHED
    }

    [Header("==== FGUI Settings ====")]
    public FGUITester fgui;


    [Header( "==== ActorController Settings ====" )]
    public ActorController ac1;
    public ActorController ac2;
    public InteractionManager im1;
    public InteractionManager im2;

    [Header( "==== Game State ====" )]
    public STATE state;
    private bool firstEnter = true; // 

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //if (Input.GetKeyDown( KeyCode.A )) {
        //    fgui.Play( "SceneBattleScene" );
        //}

        if (state == STATE.IDLE) {
            if (firstEnter == true) {
                // Trigger once
                StartCoroutine( "TaskIDLE" );
                firstEnter = false;
            } else {
                // Regular tasks
                CheckDeath( );
            }
        } else if (state == STATE.PLAYERA) {
            if (firstEnter == true) {
                // Trigger once
                StartCoroutine( "TaskPLAYERA" );
                firstEnter = false;
            } else {
                // Regular tasks
                CheckDeath( );
            }
        } else if (state == STATE.PLAYERB) {
            if (firstEnter == true) {
                // Trigger once
                StartCoroutine( "TaskPLAYERB" );
                firstEnter = false;
            } else {
                // Regular tasks
                CheckDeath( );
            }
        } else if (state == STATE.FINISHED) {
            if ( firstEnter == true ) {
                StopCoroutine( "TaskIDLE" );
                StopCoroutine( "TaskPLAYERA" );
                StopCoroutine( "TaskPLAYERB" );
            }
        }
    }

    void CheckDeath() {
        if (ac1.aData.HP <= 0 || ac2.aData.HP <= 0) {
            state = STATE.FINISHED;
            firstEnter = true;
        }
    }

    /// <summary>
    /// 「Battle Start」画面に移って、PlayerAが先攻として、ゲームを開始する
    /// </summary>
    IEnumerator TaskIDLE() {
        fgui.Play( "SceneBattleScene" );
        yield return new WaitForSeconds( 1.2f );
        state = STATE.PLAYERA;
        firstEnter = true;
    }

    /// <summary>
    /// PlayerAが攻撃し、PlayerBのターンに移る
    /// </summary>
    IEnumerator TaskPLAYERA() {
        yield return new WaitForSeconds( 1.2f );
        state = STATE.PLAYERB;
        ac1.anim.SetTrigger( "atk" );
        firstEnter = true;
    }

    /// <summary>
    /// PlayerBが攻撃し、PlayerAのターンに移る
    /// </summary>
    IEnumerator TaskPLAYERB() {
        yield return new WaitForSeconds( 1.5f );
        state = STATE.PLAYERA;
        ac2.anim.SetTrigger( "atk" );
        firstEnter = true;
    }
}