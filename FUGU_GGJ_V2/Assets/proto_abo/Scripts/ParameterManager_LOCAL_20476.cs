using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;


public class ParameterManager : MonoBehaviour {
    private GameManager gameManager;

    private float maxHp = 4;

    /// <summary>
    /// 体力
    /// </summary>
    private float hp;

    /// <summary>
    /// 体力(プロパティ)
    /// </summary>
    public float Hp {
        get { return hp; }
        set { hp = value; }
    }

    /// <summary>
    /// 速度(背景や敵の)
    /// </summary>
    private float backgroundSpeed;

    /// <summary>
    /// 速度(プロパティ)
    /// </summary>
    public float BackgroundSpeed {
        get { return backgroundSpeed; }
        set { backgroundSpeed = value; }
    }


    /// <summary>
    /// スコア
    /// </summary>
    private int score;

    /// <summary>
    /// 速スコア(プロパティ)
    /// </summary>
    public int Score {
        get { return score; }
        set { score = value; }
    }

    /// <summary>
    /// ゲームの時間
    /// </summary>
    private float gameTime = 10;

    /// <summary>
    /// ゲームの時間(プロパティ)
    /// </summary>
    public float GameTime {
        get { return gameTime; }
        set { gameTime = value; }
    }


    //====================================================
    private void Awake () {
        hp = maxHp;

        backgroundSpeed = 0.1f;//for Test

        score = 0;

        if(GameObject.Find("GameManager")) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update () {
        GameTimer();
    }

    //=============================================================
    /// <summary>
    /// タイマー
    /// </summary>
    private void GameTimer () {
        if(gameManager) {
            if(gameManager.StartedGame) {
                GameTime -= Time.deltaTime;

                if(gameTime <= 0) {
                    gameTime = 0;
                    gameManager.EndedGame = true;
                }
            }
        }
    }
}