using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    /// <summary>
    /// ゲームが始まった判定
    /// </summary>
    private bool startedGame;
    public bool StartedGame {
        get { return startedGame; }
        set { startedGame = value; }
    }

    /// <summary>
    /// ゲームが終わった判定
    /// </summary>
    private bool endedGame;
    public bool EndedGame {
        get { return endedGame; }
        set { endedGame = value; }
    }

    private bool endedEndingPerform;
    public bool EndedEndingPerform {
        get { return endedEndingPerform; }
        set { endedEndingPerform = value; }
    }

    //=============================================================
    private void Init () {
    }

    private void Awake () {
        Init();
    }

    private void Start () {

    }

    private void Update () {

    }
}