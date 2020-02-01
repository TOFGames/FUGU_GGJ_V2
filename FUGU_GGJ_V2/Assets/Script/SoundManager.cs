using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
        public AudioClip sound1;//
        public AudioClip sound2;//
        public AudioClip sound3;//
        public AudioClip sound4;//
        public static int Mswich=0;//０:デフォルト 1: 2:
        private AudioSource[] sources;//0:BGM1:SE用AudioSorce

        public GameObject Main;
        Slider Mainslider;
        public GameObject BGM;
        Slider BGMslider;
        public GameObject SEffect;
        Slider SEslider;
        void Start()
        {
                sources = GetComponents<AudioSource>();
                Mainslider=Main.GetComponent<Slider>();
                BGMslider=BGM.GetComponent<Slider>();
                SEslider=SEffect.GetComponent<Slider>();
                sources[0].volume=1*Mainslider.value*BGMslider.value;//BGMvolume初期値
                sources[1].volume=1*Mainslider.value*SEslider.value;//SEvolume初期値
        }

        void Update()
        {
                if(Mswich!=0) {//Mswichを変えるだけで特定の動作をする
                        SE(Mswich);
                }
                //Debug.Log(Mainslider.value);
        }
        void SE(int se){
                if(se==1) sources[1].PlayOneShot(sound3);
                if(se==2) {
                        sources[0].Stop();
                        sources[0].clip = sound2;//BGM変更
                        sources[0].Play();
                }
                if(se==3) sources[1].PlayOneShot(sound4);
                Mswich =0;
        }
        public void valueget(){
                Debug.Log(Mainslider.value);
                sources[0].volume=1*Mainslider.value*BGMslider.value;
                sources[1].volume=1*Mainslider.value*SEslider.value;
        }
}
