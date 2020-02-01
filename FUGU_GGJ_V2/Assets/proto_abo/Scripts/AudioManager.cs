using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

namespace AboProto {
    [DefaultExecutionOrder(-100)]
    public class AudioManager : SingletonMonoBehaviour<AudioManager> {
        private const int BGM_NUM = 3;
        private const int SE_NUM = 1;

        private List<AudioSource> bgmSourceList = new List<AudioSource>();
        private List<AudioSource> seSourceList = new List<AudioSource>();

        private Dictionary<string,AudioClip> bgmDic = new Dictionary<string,AudioClip>();
        private Dictionary<string,AudioClip> seDic = new Dictionary<string,AudioClip>();

        public Dictionary<string,float> bgmBPM = new Dictionary<string,float>();

        //=============================================================
        private void Init () {
            //SE、BGMの数分だけAudioSourceを追加
            for(int i = 0;i < BGM_NUM + SE_NUM;i++) {
                gameObject.AddComponent<AudioSource>();
            }

            AudioSource[] audioSourceArray = GetComponents<AudioSource>();

            for(int i = 0;i < audioSourceArray.Length;i++) {
                audioSourceArray[i].playOnAwake = false;

                //BGM、SE設定
                if(i < BGM_NUM) {
                    audioSourceArray[i].loop = true;
                    bgmSourceList.Add(audioSourceArray[i]);
                } else {
                    seSourceList.Add(audioSourceArray[i]);
                }
            }

            object[] bgmData = Resources.LoadAll("Audio/BGM");
            object[] seData = Resources.LoadAll("Audio/SE");

            foreach(AudioClip bgm in bgmData) {
                bgmDic[bgm.name] = bgm;
                bgmBPM[bgm.name] = AddBPM();
            }

            foreach(AudioClip se in seData) {
                seDic[se.name] = se;
            }
        }

        private void Awake () {
            //Instance化をすでにしてるなら
            if(this != Instance) {
                Destroy(this);
                return;
            }

            DontDestroyOnLoad(this.gameObject);
            Init();
        }

        //=============================================================
        //bpmデータ追加用
        private int addbmpNum;
        private float[] addbpmData = { 178,999,999,999,999 };
        private float AddBPM () {
            addbmpNum++;
            return addbpmData[addbmpNum - 1];
        }

        //=============================================================
        /// <summary>
        /// seをならす
        /// </summary>
        public void PlaySE (string name) {
            if(!seDic.ContainsKey(name)) {
                return;
            }

            foreach(AudioSource se in seSourceList) {
                se.PlayOneShot(seDic[name] as AudioClip);
                return;
            }
        }

        //=============================================================
        /// <summary>
        /// bgmをならす
        /// </summary>
        public void PlayBGM (string name,bool isLoop) {
            if(!bgmDic.ContainsKey(name)) {
                return;
            }


            for(int i = 0;i < bgmSourceList.Count;i++) {
                if(!bgmSourceList[i].isPlaying) {
                    bgmSourceList[i].clip = bgmDic[name] as AudioClip;
                    bgmSourceList[i].loop = isLoop;
                    bgmSourceList[i].Play();
                    return;
                }
            }
        }

        //=============================================================
        /// <summary>
        /// bgmを止める
        /// </summary>
        public void StopBGM () {
            foreach(AudioSource bgm in bgmSourceList) {
                bgm.Stop();
            }
        }

        //=============================================================
        /// <summary>
        /// bgmのボリュームを変える
        /// </summary>
        public void SetBGMVolume (string name,float volume) {
            if(!bgmDic.ContainsKey(name)) {
                return;
            }

            int containIndex = -1;
            for(int i = 0;i < bgmSourceList.Count;i++) {
                if(bgmSourceList[i].clip) {
                    if(bgmSourceList[i].clip.name == name) {
                        containIndex = i;
                    }
                }
            }

            if(containIndex == -1) {
                return;
            }

            bgmSourceList[containIndex].volume = volume;
        }

        //=============================================================
        /// <summary>
        /// bgmの現在時間を取得
        /// </summary>
        public float GetBGMTime (int index) {
            return bgmSourceList[index].time;
        }

        //=============================================================
        /// <summary>
        /// bgmの時間の長さを取得
        /// </summary>
        public float GetBGMTimeLength (string name) {
            if(!bgmDic.ContainsKey(name)) {
                return -1;
            }

            return bgmDic[name].length;
        }

        //=============================================================
        /// <summary>
        /// bpmから逆算してタイミングを取得する
        /// </summary>
        public float GetBGMTimingFromBPM (string name,int index) {
            if(!bgmDic.ContainsKey(name)) {
                return -1;
            }

            return GetBGMTime(index) / (60 / bgmBPM[name]);
        }
    }
}