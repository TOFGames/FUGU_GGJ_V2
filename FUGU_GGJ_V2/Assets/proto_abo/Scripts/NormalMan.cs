using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class NormalMan : MonoBehaviour {
    private float speed = 0.05f;
    private float angle = 0;

    public bool IsRepair;

    //=============================================================
    private void Init () {
    }

    private void Awake () {
        Init();
    }

    private void Start () {
        if(IsRepair) {
            StartCoroutine(Walk());
        }
    }

    private void Update () {

    }

    private IEnumerator Walk () {
        angle = Random.Range(90,270);
        while(true) {
            transform.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle - 90)),0,-Mathf.Sin(Mathf.Deg2Rad * (angle - 90))) * speed;
            transform.eulerAngles = new Vector3(0,angle,0);
            yield return null;
        }
    }
}