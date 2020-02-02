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

    private bool endedEndingPerform2;
    public bool EndedEndingPerform2 {
        get { return endedEndingPerform2; }
        set { endedEndingPerform2 = value; }
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

            StartCoroutine(GenerateBigHyahhaMan(GameObject.Find("Player").transform.position + new Vector3(0,10,5)));
        }

        if(EndedEndingPerform) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                AboProto.AudioManager.Instance.PlaySE("slash");
            }
        }
    }

    //============================================================================
    /// <summary>
    /// でかすぎるヒャッハーな人の生成
    /// </summary>
    private IEnumerator GenerateBigHyahhaMan (Vector3 pos) {
        GameObject obj = Instantiate(Resources.Load("Big_HyahhaMan")) as GameObject;
        obj.transform.position = pos;

        yield return new WaitForSeconds(1.5f);

        AboProto.AudioManager.Instance.PlaySE("explosion");
        obj = Instantiate(Resources.Load("BossExplosion")) as GameObject;
        Vector3 v = pos + new Vector3(0,0,0.2f);
        obj.transform.position = new Vector3(v.x,1,v.z);

        yield return new WaitForSeconds(1f);
        EndedEndingPerform = true;

        GenerateDescription();
    }

    /// <summary>
    /// 説明画像2(rushspace)の生成
    /// </summary>
    private void GenerateDescription () {
        GameObject obj = Instantiate(Resources.Load("Description2")) as GameObject;
        obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
    }
}