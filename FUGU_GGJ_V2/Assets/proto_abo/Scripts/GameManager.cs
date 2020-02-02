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

    private bool onceGenerateBigHyahhaMan;

    //=============================================================
    private void Init () {
    }

    private void Awake () {
        Init();
    }

    private void Start () {

    }

    private void Update () {
        if(!onceGenerateBigHyahhaMan && EndedGame) {
            onceGenerateBigHyahhaMan = true;

            StartCoroutine(GenerateBigHyahhaMan(GameObject.Find("Player").transform.position + new Vector3(0,10,2)));
        }
    }

    //============================================================================
    /// <summary>
    /// でかすぎるヒャッハーな人の生成
    /// </summary>
    private IEnumerator GenerateBigHyahhaMan (Vector3 pos) {
        GameObject obj = Instantiate(Resources.Load("Big_HyahhaMan")) as GameObject;
        obj.transform.position = pos;
        yield return new WaitForSeconds(0.1f);
    }
}