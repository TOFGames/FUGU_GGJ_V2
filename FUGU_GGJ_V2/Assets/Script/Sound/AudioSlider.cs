using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSlider : MonoBehaviour
{
        Slider slider;
        string test;
        void Start()
        {
                test="a";
                slider=GetComponent<Slider>();
        }
        public void valueget(){
                Debug.Log(slider.value);
                AboProto.AudioManager.Instance.SetBGMVolume(test,slider.value);
                //音声のファイル名すべて入れる必要あり
        }
}
