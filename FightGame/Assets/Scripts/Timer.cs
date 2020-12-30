using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float duration;
    public float elapsedTime;

    [SerializeField]
    private bool pause = true;

    public delegate void OnTimerSignature(string value);
    public OnTimerSignature OnTimer;

    // Update is called once per frame
    void Update()
    {
        if(pause == false) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > duration) {
                elapsedTime -= duration;
                //print( "worked" );
                OnTimer.Invoke( "working" );
            }
        }
    }

    public void StartTimer(float _duration) {
        duration = _duration;
        elapsedTime = 0;
        pause = false;
    }

    public void StopTimer() {
        duration = 0;
        elapsedTime = 0;
        pause = true;
    }

    public void PauseTimer() {
        pause = true;
    }

    public void ResumeTimer() {
        pause = false;
    }
}
