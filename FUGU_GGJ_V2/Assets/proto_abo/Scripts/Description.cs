using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour {
    [SerializeField]
    private AnimationCurve sizeCurve;

    [SerializeField]
    private AnimationCurve colorAlphaCurve;

    private Image image;
    private RectTransform rectTransform;
    private GameManager gameManager;

    //=============================================================
    private void Init () {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Awake () {
        Init();
    }

    private void Start () {
        StartCoroutine(AppearAndDisappear());
    }

    private void Update () {

    }

    private IEnumerator AppearAndDisappear () {

        float time = 0;
        while(true) {
            rectTransform.localScale = Vector3.one * sizeCurve.Evaluate(time);

            time += Time.deltaTime*2;
            if(time >= 1) {
                AboProto.AudioManager.Instance.PlaySE("conch1");
                time = 0;
                break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(3);

        while(true) {
            image.color = new Color(image.color.r,image.color.g,image.color.b,1 - time);

            time += Time.deltaTime;
            if(time >= 1) {
                time = 0;
                gameManager.StartedGame = true;
                break;
            }

            yield return null;
        }

        Destroy(this.gameObject);
    }
}