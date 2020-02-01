using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

namespace AboProto {
    public class ParameterManager : MonoBehaviour {
        private float maxHp = 4;

        /// <summary>
        /// 体力
        /// </summary>
        private float hp;

        /// <summary>
        /// 体力(プロパティ)
        /// </summary>
        public float Hp {
            get { return hp; }
            set { hp = value; }
        }

        /// <summary>
        /// 速度(背景や敵の)
        /// </summary>
        private float backgroundSpeed;

        /// <summary>
        /// 速度(プロパティ)
        /// </summary>
        public float BackgroundSpeed {
            get { return backgroundSpeed; }
            set { backgroundSpeed = value; }
        }

        //====================================================
        private void Awake () {
            hp = maxHp;
        }
    }
}