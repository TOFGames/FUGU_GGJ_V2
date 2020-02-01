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

        [SerializeField]
        private GameObject attention; //注目オブジェクト

        private Camera cam; //カメラ

        //=============================================================
        private void Init () {
            CRef();
        }

        //=============================================================
        private void CRef () {
            cam = this.GetComponent<Camera>();
        }

        //=============================================================
        private void Awake () {
            Init();
        }

        private void Update () {
            if(attention == null) return;
            var goal = attention.transform.position + fixX + fixY + fixZ;
            transform.position = Vector3.Lerp(transform.position,goal,easingSpeed);
        }
    }
}