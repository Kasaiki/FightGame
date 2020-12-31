using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    public Timer timer1;

    // Start is called before the first frame update
    void Start()
    {
        timer1.OnTimer += TimerTest01;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TimerTest01(string value) {
        print( "test01 is called, value is :" + value);
    }
}
