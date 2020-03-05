using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Title_Button : MonoBehaviour
{
        public bool StartButton=false;
        public bool HplayButton=false;
        public bool RankingButton=false;
        public GameObject How_to_Play;
        void Start()
        {
           AboProto.AudioManager.Instance.PlayBGM("OpningBGM",true);
        }
        void Update()
        {

        }
        public void OnClick()
        { //押されたときの処理
                if(StartButton==true) {
                        AboProto.AudioManager.Instance.PlaySE("iyahaaaa");
                        AboProto.AudioManager.Instance.StopBGM();
                        Title_Image.Blackout=true;
                }
                if(HplayButton==true) {
                        How_to_Play.gameObject.SetActive(true);
                }
                if(RankingButton==true) {
                        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0);
                }
        }
}
