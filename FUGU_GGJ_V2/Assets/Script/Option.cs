using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[DefaultExecutionOrder(-100)]
public class Option : MonoBehaviour
{
        public GameObject Slider;
        public static bool swich=false;
        void Update()
        {
                if(EventSystem.current.IsPointerOverGameObject()) {
                        swich=true;
                        //ボタンにマウスを合わせるとtrueになる
                }
                //Debug.Log(swich);
        }

        public void OnClick()
        {//押されたときの処理
                Debug.Log(swich);              //名前表示
                if(Time.timeScale != 0f ) {//時止め
                        Slider.gameObject.SetActive(true);
                        Time.timeScale = 0f;
                }else{                      //解除
                        Slider.gameObject.SetActive(false);
                        Time.timeScale = 1f;
                        swich=false;
                }
                return;
        }
        //var _eventSystem = FindObjectOfType<EventSystem>();//イベントシステムを取得
//Debug.Log(Option.swich);
//if(_eventSystem.currentSelectedGameObject == SettingButton) return false; //オプションボタンを押したなら右へ移動しない

}
