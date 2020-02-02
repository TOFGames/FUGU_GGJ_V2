using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class BigHyahhaMan : MonoBehaviour {
    //=============================================================
    private GameManager gameManager;
    private bool once;

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
        if(gameManager.EndedEndingPerform2 && !once) {
            StartCoroutine(Death());
            once = false;
        }
    }

    private IEnumerator Death () {
        yield return new WaitForSeconds(2);

        GameObject.Find("Player").GetComponent<AboProto.Player>().BeatEff();

        Destroy(gameObject);
    }
}