using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class InteractionFrame : MonoBehaviour {
    //=============================================================
    private GameManager gameManager;
    private GameObject _child;

    //=============================================================
    private void Init () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _child = transform.Find("Child").gameObject;
    }

    private void Awake () {
        Init();
    }

    private void Start () {

    }

    private void Update () {
        if(gameManager.EndedEndingPerform2) {
            _child.SetActive(true);
        } else {
            _child.SetActive(false);
        }
    }
}