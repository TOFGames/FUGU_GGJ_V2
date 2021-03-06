﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AboProto {
    /// <summary>
    /// テスト用プレイヤー
    /// </summary>
    public class TstPlayer : MonoBehaviour {
        private ParameterManager parameterManager;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private ParticleSystem _particleSystem;
        private GameObject _canvas;
        private GameObject beatEff;

        /// <summary>
        /// ノックバック中判定
        /// </summary>
        private bool isKnockBack;

        /// <summary>
        /// x軸方向のスピード
        /// </summary>
        private Vector3 xSpeed = new Vector3(0.1f,0,0);

        /// <summary>
        /// y軸方向のスピード
        /// </summary>
        private Vector3 ySpeed = new Vector3(0,3f,0);

        /// <summary>
        /// 位置制限
        /// </summary>
        private Vector3 posLimit = new Vector3(4,0,0);

        //============================================================================
        private void Awake () {
            parameterManager = GameObject.Find("ParameterManager").GetComponent<ParameterManager>();
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _particleSystem = transform.Find("Saturated").GetComponent<ParticleSystem>();
            _canvas = GameObject.Find("Canvas").gameObject;

            AudioManager.Instance.PlayBGM("aiwo",true);
        }

        private void Update () {
            Move();
        }

        private void OnCollisionEnter (Collision collision) {
            if(collision.gameObject.name.Equals("Plane") ||
                collision.gameObject.name.Equals("RoadMovingPlane") ||
                collision.gameObject.name.Equals("RoadMovingPlane(Clone)")) {
                _animator.SetBool("IsJump",false);
            }
        }

        private void OnTriggerEnter (Collider other) {
            if(other.gameObject.name.Equals("GenerateHyahaa(Clone)")) {
                BeatEff();
                GenerateNormalMan(other.transform.position);

                Destroy(other.gameObject);
            }
        }

        //============================================================================
        /// <summary>
        /// 動く
        /// </summary>
        private void Move () {
            if(IsLeft()) {
                _rigidbody.position -= xSpeed;
            }

            if(IsRight()) {
                _rigidbody.position += xSpeed;

            }

            if(IsUp()) {
                if(!_animator.GetBool("IsJump")) {
                    _rigidbody.position += ySpeed;
                    _animator.SetBool("IsJump",true);
                }
            }

            if(Input.GetKey(KeyCode.Space)) {
                SpeedUpState();
            } else {
                NormalState();
            }

            if(Input.GetKeyDown(KeyCode.A)) {
                BeatEff();
            }

            if(Input.GetKeyDown(KeyCode.B)) {
                StartCoroutine(Defeat(10));
            }

            if(_rigidbody.position.x <= -posLimit.x) {
                Vector3 attachPos = _rigidbody.position;
                attachPos.x = -posLimit.x;
                _rigidbody.position = attachPos;
            }

            if(_rigidbody.position.x >= posLimit.x) {
                Vector3 attachPos = _rigidbody.position;
                attachPos.x = posLimit.x;
                _rigidbody.position = attachPos;
            }
        }

        //============================================================================
        /// <summary>
        /// ダメージ
        /// </summary>
        private void Damage () {
            if(isKnockBack) return;
            parameterManager.Hp--;
            if(parameterManager.Hp > 0) {
                StartCoroutine(Defeat(10));
            } else {

            }
        }

        //============================================================================
        /// <summary>
        /// 通常時の状態
        /// </summary>
        private void NormalState () {
            _animator.SetFloat("AnimSpeed",1);
            _particleSystem.startSpeed = 5;
            _particleSystem.startLifetime = 5;

            parameterManager.BackgroundSpeed = 0.1f;
        }

        //============================================================================
        /// <summary>
        /// スピードアップ時の状態
        /// </summary>
        private void SpeedUpState () {
            _animator.SetFloat("AnimSpeed",3);
            _particleSystem.startSpeed = 10;
            _particleSystem.startLifetime = 0.5f;

            parameterManager.BackgroundSpeed = 0.3f;
        }

        //============================================================================
        /// <summary>
        /// 左にアクションをおこしたかどうか
        /// </summary>
        private bool IsLeft () {
            if(Input.GetKey(KeyCode.LeftArrow)) {
                return true;
            }

            if(InputUtil.GetTouchCanvasPosition(_canvas).x < 0 &&
                (InputUtil.GetTouch() == InputUtil.TouchInfo.Began || InputUtil.GetTouch() == InputUtil.TouchInfo.Moved)) {
                return true;
            }

            return false;
        }

        //============================================================================
        /// <summary>
        /// 右にアクションをおこしたかどうか
        /// </summary>
        private bool IsRight () {
            if(Input.GetKey(KeyCode.RightArrow)) {
                return true;
            }

            if(InputUtil.GetTouchCanvasPosition(_canvas).x > 0 &&
                (InputUtil.GetTouch() == InputUtil.TouchInfo.Began || InputUtil.GetTouch() == InputUtil.TouchInfo.Moved)) {
                return true;
            }

            return false;
        }

        //============================================================================
        /// <summary>
        /// 左にアクションをおこしたかどうか
        /// </summary>
        private bool IsUp () {
            if(Input.GetKey(KeyCode.UpArrow)) {
                return true;
            }

            return false;
        }

        //============================================================================
        /// <summary>
        /// 撃退エフェクトの生成
        /// </summary>
        private GameObject GenerateBeatEff () {
            GameObject obj = Instantiate(Resources.Load("BeatEff")) as GameObject;
            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
            return obj;
        }

        /// <summary>
        /// 撃退エフェクトの発動
        /// </summary>
        private void BeatEff () {
            if(beatEff) {
                ActivateBeatEff();
            } else {
                beatEff = GenerateBeatEff();
            }
        }

        /// <summary>
        /// 撃退エフェクトのアクティベート
        /// </summary>
        private void ActivateBeatEff () {
            beatEff.SetActive(true);
            transform.eulerAngles = Vector3.zero;
        }

        //============================================================================
        /// <summary>
        /// 普通の人の生成
        /// </summary>
        private GameObject GenerateNormalMan (Vector3 pos) {
            GameObject obj = Instantiate(Resources.Load("NormalMan")) as GameObject;
            obj.GetComponent<Man>().IsRepair = true;
            obj.transform.position = pos;
            return obj;
        }

        //============================================================================
        /// <summary>
        /// 打ち負かされたら
        /// </summary>
        private IEnumerator Defeat (float rate) {
            isKnockBack = true;
            GameObject obj = transform.Find("Dummy").gameObject;

            float time = 0;
            float count = 0;

            while(true) {
                if(time >= count / rate) {
                    count++;
                }

                time += Time.deltaTime;
                if(time >= 1) {
                    time = 0;
                    break;
                }

                obj.SetActive(count % 2 == 0 ? true : false);

                yield return null;
            }

            isKnockBack = false;
            yield return null;
        }
    }
}
