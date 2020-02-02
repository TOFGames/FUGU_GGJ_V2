using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {
    //=============================================================
    private TestParameterManager tParameterManager;
    private GameManager gameManager;

    private Text text;
    private Image image;

    int minutes;
    int seconds;

    //=============================================================
    private void Init () {
        text = transform.Find("Text").GetComponent<Text>();
        image = transform.Find("Image").GetComponent<Image>();
        tParameterManager = GameObject.Find("TestParameterManager").GetComponent<TestParameterManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Awake () {
        Init();
    }

    private void Start () {

    }

    private void Update () {
        if(gameManager.StartedGame && !gameManager.EndedGame) {
            text.enabled = true;
            image.enabled = true;
        } else {
            text.enabled = false;
            image.enabled = false;
        }

        minutes = (int)((tParameterManager.GameTime + 0.9f) / 60f);
        seconds = (int)(tParameterManager.GameTime + 0.9f - minutes * 60f);
        text.text = string.Format("{0:0}:{1:00}",minutes,seconds);
    }
}