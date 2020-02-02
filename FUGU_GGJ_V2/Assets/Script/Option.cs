using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[DefaultExecutionOrder(-100)]
public class Option : MonoBehaviour {
    private GameManager gameManager;
    public GameObject Slider;
    public static bool Option_swich = false;
    private Vector2 this_position;
    Vector2 mouseposition;
    private Image image;
    private Text text;

    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this_position = this.transform.position;
        image = GetComponent<Image>();
        text = transform.Find("Text").GetComponent<Text>();
    }

    void Update () {
        if(gameManager.StartedGame && !gameManager.EndedGame) {
            image.enabled = true;
            text.enabled = true;
        } else {
            image.enabled = false;
            text.enabled = false;
        }

        mouseposition = Input.mousePosition;
        float distance = Vector2.Distance(mouseposition,this_position);
        if(EventSystem.current.IsPointerOverGameObject() && distance < 30) {
            Option_swich = true;//ボタンにマウスを合わせるとtrueになる
        } else {
            Option_swich = false;
        }
        //Debug.Log(distance);
    }

    public void OnClick () { //押されたときの処理
        if(Time.timeScale != 0f) {  //時止め
            Slider.gameObject.SetActive(true);
            Time.timeScale = 0f;
        } else {  //解除
            Slider.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
