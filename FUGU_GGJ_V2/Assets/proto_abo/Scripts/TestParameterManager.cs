using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class TestParameterManager : MonoBehaviour {
    private GameManager gameManager;

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

    //=============================================================
    private void Init () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Awake () {
        Init();
    }

    private void Start () {

    }

    private void Update () {
        GameTimer();
    }

    //=============================================================
    /// <summary>
    /// タイマー
    /// </summary>
    private void GameTimer () {
        if(gameManager.StartedGame) {
            GameTime -= Time.deltaTime;

            if(gameTime <= 0) {
                gameTime = 0;
                gameManager.EndedGame = true;
            }
        }
    }
}