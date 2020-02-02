using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

namespace AboProto {
    public class CameraMover : MonoBehaviour {
        //=============================================================
        private float easingSpeed = 0.1f; //カメラ追従速度
        private Vector3 fixX = Vector3.right * 0; //x軸補正
        private Vector3 fixY = Vector3.up * 2f; //y軸補正(カメラを少し上にするため)
        private Vector3 fixZ = Vector3.back * 5f; //z軸補正(描画されなくなるため)

        private Vector3 fixXB = Vector3.right * 0; //x軸補正
        private Vector3 fixYB = Vector3.up * (-5); //y軸補正(カメラを少し上にするため)
        private Vector3 fixZB = Vector3.back * 5f; //z軸補正(描画されなくなるため)

        [SerializeField]
        private GameObject attention; //注目オブジェクト

        private GameObject attentionBoss; //注目オブジェクト(boss)

        private Camera cam; //カメラ
        private GameManager gameManager;

        //=============================================================
        private void Init () {
            CRef();
        }

        //=============================================================
        private void CRef () {
            cam = this.GetComponent<Camera>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            attentionBoss = Resources.Load("Big_HyahhaMan") as GameObject;
        }

        //=============================================================
        private void Awake () {
            Init();
        }

        private void Update () {
            if(gameManager.StartedGame && !gameManager.EndedGame) {
                if(attention == null) return;

                var goal = attention.transform.position + fixX + fixY + fixZ;
                transform.position = Vector3.Lerp(transform.position,goal,easingSpeed);

                var goalRotate = Vector3.zero;
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,goalRotate,easingSpeed);
                return;
            }

            if(gameManager.EndedGame) {
                if(attentionBoss == null) return;

                var goal = attentionBoss.transform.position + fixXB + fixYB + fixZB;
                transform.position = Vector3.Lerp(transform.position,goal,easingSpeed);

                transform.LookAt(attentionBoss.transform,Vector3.up);
                return;
            }
        }
    }
}