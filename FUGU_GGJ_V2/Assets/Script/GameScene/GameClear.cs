using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameClear : MonoBehaviour {
    public GameObject Button;
    public GameObject Maneger;
    GameManager flag;
    Image image_component;
    float title_color = 0.0f;//タイトルを黒くする
    float title_clear = 0.5f;//タイトルを透明化
    void Start () {
        flag = Maneger.GetComponent<GameManager>();
        image_component = GetComponent<Image>();
    }

    void Update () {
        //float title_clear=0.5f;
        if(flag.EndedEndingPerform3 == true) {//ゲームクリアするとtrueになる
            Button.gameObject.SetActive(true);
            image_component.color = new Color(title_color,title_color,title_color,title_clear);
        }
    }
    public void Click () {
        SceneManager.LoadScene("Title");
    }
}
