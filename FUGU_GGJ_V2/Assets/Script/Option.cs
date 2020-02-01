using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[DefaultExecutionOrder(-100)]
public class Option : MonoBehaviour
{
        public GameObject Slider;
        public static bool Option_swich=false;
        void Update()
        {
                if(EventSystem.current.IsPointerOverGameObject()) {
                        Option_swich=true;  //ボタンにマウスを合わせるとtrueになる
                }else{
                        Option_swich=false;
                }
                Debug.Log(Option_swich);
        }

        public void OnClick()
        { //押されたときの処理
                if(Time.timeScale != 0f ) {  //時止め
                        Slider.gameObject.SetActive(true);
                        Time.timeScale = 0f;
                }else{  //解除
                        Slider.gameObject.SetActive(false);
                        Time.timeScale = 1f;
                }
        }
}
