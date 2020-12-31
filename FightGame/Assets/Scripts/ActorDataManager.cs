using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorDataManager : MonoBehaviour
{
    [SerializeField]
    private ActorData aData;

    public float GetATK() {
        return aData.ATK;
    }

    public float GetRandomATK(float percentage = 0.3f) {
        return Random.Range( (1 - percentage) * aData.ATK, (1 + percentage) * aData.ATK );
    }

    public float GetDEF() {
        return aData.DEF;
    }

    public void AddHP(float value) {
        aData.AddHP( value );
    }
}
