using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public Animator anim;
    public ActorData aData;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>( );
        aData = GetComponent<ActorData>( );
    }
}
