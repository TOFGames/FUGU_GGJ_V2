using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Button : MonoBehaviour
{
        public bool StartButton=false;
        public bool HplayButton=false;
        public bool RankingButton=false;
        void Start()
        {

        }
        void Update()
        {

        }
        public void OnClick()
        { //押されたときの処理
                if(StartButton==true) {
                        AboProto.AudioManager.Instance.PlaySE("iyahaaaa");
                        Title_Image.Blackout=true;
                }
                if(HplayButton==true) {

                }
                if(RankingButton==true) {
                        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0);
                }
        }
}
