using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class NormalMan : MonoBehaviour {
    private FlowController flowController;

    private float speed = 0.05f;
    private float angle = 0;

    public bool IsRepair;

    //=============================================================
    private void Init () {
        flowController = GetComponent<FlowController>();
    }

    private void Awake () {
        Init();
    }

    private void Start () {
        if(IsRepair) {
            Destroy(flowController);
            StartCoroutine(Walk(3));
        }
    }

    private void Update () {

    }

    private IEnumerator Walk (float life) {
        angle = Random.Range(90 + 15,270 - 15);

        float time = 0;
        while(true) {
            transform.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle - 90)),0,-Mathf.Sin(Mathf.Deg2Rad * (angle - 90))) * speed;
            transform.eulerAngles = new Vector3(0,angle,0);

            time += Time.deltaTime;
            if(time >= life) {
                Destroy(this.gameObject);
                break;
            }
            yield return null;
        }
    }
}