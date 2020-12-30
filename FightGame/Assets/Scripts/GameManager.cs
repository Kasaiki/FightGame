using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        PLAYERA,
        PLAYERB,
        FINISHED
    }

    [Header( "==== Parameters Settings ====" )]
    [Range( 0, 10.0f )]
    public float i = 0.1f;

    [Header( "==== String Setting ====" )]
    public string str1;

    [Header( "==== ActorController Settings ====" )]
    public ActorController ac1;
    public ActorController ac2;
    public InteractionManager im1;
    public InteractionManager im2;

    [Header( "==== Game State ====" )]
    public STATE state;

    private bool firstEnter = true; // As a FLAG signal 

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
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

    IEnumerator TaskIDLE() {
        yield return new WaitForSeconds( 1.0f );
        state = STATE.PLAYERA;
        ac1.anim.SetTrigger( "atk" );
        firstEnter = true;
    }

    IEnumerator TaskPLAYERA() {
        yield return new WaitForSeconds( 1.0f );
        state = STATE.PLAYERB;
        ac2.anim.SetTrigger( "atk" );
        firstEnter = true;
    }

    IEnumerator TaskPLAYERB() {
        yield return new WaitForSeconds( 1.0f );
        state = STATE.PLAYERA;
        ac1.anim.SetTrigger( "atk" );
        firstEnter = true;
    }
}