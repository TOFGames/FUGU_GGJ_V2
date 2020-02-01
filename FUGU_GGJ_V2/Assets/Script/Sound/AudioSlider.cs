using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSlider : MonoBehaviour
{
        Slider slider;
        object[] bgmData;
        object[] seData;
        public bool swich=false;//どのスライダーか判断　trueならBGM
        void Start()
        {
                slider=GetComponent<Slider>();
                bgmData = Resources.LoadAll("Audio/BGM");//データ抽出
                seData = Resources.LoadAll("Audio/SE");
                //音声ファイルの場所をAudioManegerと合わせる必要あり
        }
        public void valueget(){
                //Debug.Log(slider.value);
                //音声のファイル名すべて入れる必要あり
                if(swich==true) {
                        foreach(AudioClip bgm in bgmData) {
                                //Debug.Log(bgm.name);//名前表示
                                AboProto.AudioManager.Instance.SetBGMVolume(bgm.name,slider.value);
                        }
                }else{
                        foreach(AudioClip bgm in seData) {
                                //Debug.Log(bgm.name);//名前表示
                                AboProto.AudioManager.Instance.SetBGMVolume(bgm.name,slider.value);
                        }
                }
        }
}
