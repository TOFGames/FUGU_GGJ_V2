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

    private bool endedEndingPerform3;
    public bool EndedEndingPerform3 {
        get { return endedEndingPerform3; }
        set { endedEndingPerform3 = value; }
    }

    private bool onceGenerateBigHyahhaMan;
    private bool onceCallRanking;

    private GameObject boss;
    private ParameterManager parameterManager;

    private float localTime = 0;

    //=============================================================
    private void Init () {
        parameterManager = GameObject.Find("ParameterManager").GetComponent<ParameterManager>();
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

        if(EndedEndingPerform && !EndedEndingPerform2) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                //AboProto.AudioManager.Instance.PlaySE("slash");
                GenerateExplosion(boss.transform.position + Vector3.one * Random.Range(0,10));
            }

            localTime += Time.deltaTime;
            if(localTime >= 10) {
                parameterManager.Score += 10;
                EndedEndingPerform2 = true;
            }
        }

        if(EndedEndingPerform3 && !onceCallRanking) {
            onceCallRanking = true;
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(parameterManager.Score);
        }
    }

    //============================================================================
    /// <summary>
    /// でかすぎるヒャッハーな人の生成
    /// </summary>
    private IEnumerator GenerateBigHyahhaMan (Vector3 pos) {
        GameObject obj = Instantiate(Resources.Load("Big_HyahhaMan")) as GameObject;
        obj.transform.position = pos;

        boss = obj;

        yield return new WaitForSeconds(1.5f);

        GenerateExplosion(pos);

        yield return new WaitForSeconds(1f);
        EndedEndingPerform = true;

        GenerateDescription();
    }

    /// <summary>
    /// 爆発の生成
    /// </summary>
    private void GenerateExplosion (Vector3 pos) {
        AboProto.AudioManager.Instance.PlaySE("explosion");
        GameObject obj = Instantiate(Resources.Load("BossExplosion")) as GameObject;
        Vector3 v = pos + new Vector3(0,0,0.2f);
        obj.transform.position = new Vector3(v.x,1,v.z);
    }

    /// <summary>
    /// 説明画像2(rushspace)の生成
    /// </summary>
    private void GenerateDescription () {
        GameObject obj = Instantiate(Resources.Load("Description2")) as GameObject;
        obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
    }
}