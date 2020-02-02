using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ScreenCover : MonoBehaviour {
    //=============================================================
    private GameManager gameManager;
    private RectTransform up;
    private RectTransform down;

    private Vector2[] upPos = new Vector2[2];
    private Vector2[] downPos = new Vector2[2];

    private bool onceReCycleCover;

    //=============================================================
    private void Init () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        up = transform.Find("Up").GetComponent<RectTransform>();
        down = transform.Find("Down").GetComponent<RectTransform>();
        upPos[0] = new Vector2(0,450);
        upPos[1] = new Vector2(0,600);
        downPos[0] = new Vector2(0,-450);
        downPos[1] = new Vector2(0,-600);
    }

    private void Awake () {
        Init();
    }

    private void Start () {
        StartCoroutine(Move(3));
    }

    private void Update () {
        if(gameManager.EndedGame) {
            if(!onceReCycleCover) {
                StartCoroutine(Move(3));
                onceReCycleCover = true;
            }
        }
    }

    private IEnumerator Move (float speed) {
        float time = 0;
        while(true) {
            down.anchoredPosition = Vector3.Lerp(upPos[1],upPos[0],time);
            up.anchoredPosition = Vector3.Lerp(downPos[1],downPos[0],time);

            time += Time.deltaTime * speed;
            if(time >= 1f) {
                time = 0;
                break;
            }

            yield return null;
        }

        yield return new WaitWhile(() => !gameManager.StartedGame);
        if(gameManager.EndedGame) yield return new WaitWhile(() => !gameManager.EndedEndingPerform);

        while(true) {
            down.anchoredPosition = Vector3.Lerp(upPos[0],upPos[1],time);
            up.anchoredPosition = Vector3.Lerp(downPos[0],downPos[1],time);

            time += Time.deltaTime * speed;
            if(time >= 1f) {
                time = 0;
                break;
            }

            yield return null;
        }
    }
}