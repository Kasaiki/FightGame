using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class FGUITester : MonoBehaviour
{
    public UIPanel myPanel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ゲーム開始後、「Battle Start」UIを呼び出すためのメソッド。
    /// sceneNameは呼び出し先の名前，transitionNameはUIアニメーションの名前
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="transitionName"></param>
   public void Play( string sceneName, string transitionName = "t3") {
        myPanel.ui.Dispose( );
        myPanel.componentName = sceneName;
        myPanel.CreateUI( );
        myPanel.ui.GetTransition( transitionName ).Play( );
    }
}
