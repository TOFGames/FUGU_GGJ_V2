using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
        public GameObject Slider;
        void Start()
        {

        }

        void Update()
        {
        }
        public void OnClick()
        {//押されたときの処理
                if(Time.timeScale != 0f ) {//時止め
                        Slider.gameObject.SetActive(true);
                        Time.timeScale = 0f;
                }else{                      //解除
                        Slider.gameObject.SetActive(false);
                        Time.timeScale = 1f;
                }
                return;
        }
}
