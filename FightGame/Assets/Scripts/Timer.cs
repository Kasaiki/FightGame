using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 時間を計測するキットクラス。
/// </summary>
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

    /// <summary>
    /// 時間計測が始まって、_duration時間が経過したら、delegateにより、関数を呼び出す
    /// </summary>
    /// <param name="_duration"></param>
    public void StartTimer(float _duration) {
        duration = _duration;
        elapsedTime = 0;
        pause = false;
    }

    /// <summary>
    /// 経過時間と目標時間を０として、タイマーをリセットする
    /// </summary>
    public void StopTimer() {
        duration = 0;
        elapsedTime = 0;
        pause = true;
    }

    /// <summary>
    /// タイマーをパウスする
    /// </summary>
    public void PauseTimer() {
        pause = true;
    }

    /// <summary>
    /// タイマーのパウス状態を解除し、時間計測を続ける
    /// </summary>
    public void ResumeTimer() {
        pause = false;
    }
}
